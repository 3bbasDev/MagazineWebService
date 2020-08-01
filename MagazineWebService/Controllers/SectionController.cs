using AutoMapper;
using MagazineWebService.AuthFilterAPI;
using MagazineWebService.DTO.Generic;
using MagazineWebService.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly IGenericRepo<Section> _sectionRepo;
        private readonly IMapper _mapper;
        public SectionController(IMapper mapper, IGenericRepo<Section> sectionRepo)
        {
            _mapper = mapper;
            _sectionRepo = sectionRepo;
        }
        [HttpGet()]
        public async Task<IActionResult> Get(int Take = 5, int Skip = 0)
        {                           
            return Ok(await _sectionRepo
                .Get(f =>new 
                        { 
                            f.Id,
                            f.Name,
                            ChildSection=f.Sections
                                .Where(d=>d.IsDeleted.Value==false)
                                .Select(d=>new {d.Id,d.Name,d.IsDeleted }),f.IsDeleted 
                        },
                    f =>f.ParentId==null&& f.IsDeleted.Value == false,
                    null,
                    Take,
                    Skip
                    ));

        }
        
        [FilterAPI(Role = 3, Delete = true)]
        [HttpDelete()]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var Section = await _sectionRepo.CheckByFilter(f => f.Id == Id);
            if (Section == null) return NotFound();
            Section.IsDeleted = Section.IsDeleted == false;

            if (await _sectionRepo.Update(f => f.Id == Section.Id, _mapper.Map<Section>(Section)))
                return Ok();
            return BadRequest();
        }

    }
}
