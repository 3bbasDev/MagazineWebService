using AutoMapper;
using MagazineWebService.AuthFilterAPI;
using MagazineWebService.DTO.Generic;
using MagazineWebService.Infrastructure;
using MagazineWebService.Model.Comment;
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
    public class CommentController : ControllerBase
    {
        private readonly IGenericRepo<Comment> _commentRepo;
        private readonly IGenericRepo<Post> _postRepo;
        private readonly IMapper _mapper;
        public CommentController(IMapper mapper, IGenericRepo<Comment> commentRepo, IGenericRepo<Post> postRepo)
        {
            _mapper = mapper;
            _commentRepo = commentRepo;
            _postRepo = postRepo;
        }

        [HttpPost()]
        public async Task<IActionResult> Insert([FromBody] CreateCommentModel model)
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

            if (await _postRepo.CheckByFilter(f => f.Id == model.PostId)==null)
                return NotFound();
            
            if (await _commentRepo.Insert(null, _mapper.Map<Comment>(model)))
                return Ok();
            return BadRequest();
        }
       
        [HttpGet()]
        public async Task<IActionResult> Get(Guid PostId, int Take = 5, int Skip = 0)
        {                                //         select                                                                        where                order by                        take skip 
            return Ok(await _commentRepo.Get(f => new { f.Id, f.Name,f.Text,f.Issued,f.Email,f.Country }, f => f.PostId==PostId, f => f.OrderByDescending(f => f.Issued), Take, Skip));

        }

        [FilterAPI(Role = 3, Delete = true)]
        [HttpDelete()]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var Comment = await _commentRepo.CheckByFilter(f => f.Id == Id);
            if (Comment == null) return NotFound();

            if (await _commentRepo.Remove(Id))
                return Ok();
            return BadRequest();
        }
    }
}
