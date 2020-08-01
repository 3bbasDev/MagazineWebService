using AutoMapper;
using MagazineWebService.AuthFilterAPI;
using MagazineWebService.DTO.Generic;
using MagazineWebService.Infrastructure;
using MagazineWebService.Model.Profile;
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
    public class ProfileController : ControllerBase
    {
        private readonly IGenericRepo<Infrastructure.Profile> _profileRepo;
        private readonly IMapper _mapper;
        public ProfileController(IMapper mapper, IGenericRepo<Infrastructure.Profile> profileRepo)
        {
            _mapper = mapper;
            _profileRepo = profileRepo;
        }

        [HttpGet()]
        public async Task<IActionResult> Get(int Take = 1, int Skip = 0)
        {        
            return Ok(await _profileRepo.Get(f => f,null, null, Take, Skip));

        }

        [FilterAPI(Role = 1, Update = true)]
        [HttpPut()]
        public async Task<IActionResult> Update( [FromBody] EditProfileModel model)
        {

            if (!ModelState.IsValid)
            {
                return StatusCode(400, new
                {
                    code = 400.1,
                    message = "invalid parameters",
                    result = ModelState.Values.Select(f => f.Errors.Select(d => d.ErrorMessage))
                });
            }

            if (await _profileRepo.Update(f => f.Id == 1 , _mapper.Map<Infrastructure.Profile>(model)))
                return Ok();
            return BadRequest();
        }
    }
}
