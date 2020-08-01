using AutoMapper;
using MagazineWebService.AuthFilterAPI;
using MagazineWebService.DTO.Generic;
using MagazineWebService.Infrastructure;
using MagazineWebService.Model.Post;
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
    public class PostController : ControllerBase
    {
        private readonly IGenericRepo<Post> _postRepo;
        private readonly IMapper _mapper;
        public PostController(IMapper mapper, IGenericRepo<Post> userRepo)
        {
            _mapper = mapper;
            _postRepo = userRepo;
        }
        
        [FilterAPI(Role = 2, Add = true)]
        [HttpPost()]
        public async Task<IActionResult> Insert([FromBody] CreatePostModel model)
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
            // where                         map
            if (await _postRepo.Insert(null, _mapper.Map<Post>(model)))
                return Ok();
            return BadRequest();

        }
       
        [HttpGet()]
        public async Task<IActionResult> Get(Guid? SectionId, int Take = 5, int Skip = 0)
        {                                //         select                                                                        where                order by                        take skip 
            return Ok(await _postRepo.Get(f => new { f.Id, f.Body,f.Issued,f.Link,f.Photo,f.Rating,SectionName=f.Section.Name,f.SectionId,f.Title,f.Views, f.IsDeleted }, f =>(SectionId.HasValue?f.SectionId==SectionId:true)&& f.IsDeleted.Value == false, f => f.OrderByDescending(f => f.Issued), Take, Skip));

        }
        
        [FilterAPI(Role = 2, Update = true)]
        [HttpPut()]
        public async Task<IActionResult> Update(Guid Id, [FromBody] EditPostModel model)
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
            if (await _postRepo.Update(f => f.Id == Id , _mapper.Map<Post>(model)))
                return Ok();
            return BadRequest();
        }

        [FilterAPI(Role = 2, Delete = true)]
        [HttpDelete()]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var Post = await _postRepo.CheckByFilter(f => f.Id == Id);
            if (Post == null) return NotFound();
            Post.IsDeleted = Post.IsDeleted == false;

            if (await _postRepo.Update(f => f.Id == Post.Id, _mapper.Map<Post>(Post)))
                return Ok();
            return BadRequest();
        }
    }
}
