using AutoMapper;
using MagazineWebService.AuthFilterAPI;
using MagazineWebService.Data;
using MagazineWebService.DTO.Generic;
using MagazineWebService.Infrastructure;
using MagazineWebService.Model.User;
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
    public class AccountController : ControllerBase
    {
        private readonly IGenericRepo<User> _userRepo;
        private readonly IMapper _mapper;
        public AccountController(IMapper mapper, IGenericRepo<User> userRepo)
        {
            _mapper = mapper;
            _userRepo = userRepo;
        }
        [FilterAPI(Role = 1, Add  = true)]
        [HttpPost()]
        public async Task<IActionResult> Insert([FromBody] CreateUserModel model)
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
            if (await _userRepo.Insert(f=>f.Username==model.Username,_mapper.Map<User>(model)))
                    return Ok();
            return BadRequest();
            
        }
        
        [FilterAPI(Role = 1, View = true)]
        [HttpGet()]
        public async Task<IActionResult> Get(int Take=5,int Skip=0)
        {                                //         select                                                                        where                order by                        take skip 
            return Ok(await _userRepo.Get(f=>new {f.Id,f.FullName,f.Email,f.PolicyId,f.Username,f.Policy.Name ,f.IsDeleted},f=>f.IsDeleted.Value==false,f=>f.OrderByDescending(f=>f.Email),Take,Skip));

        }
        
        [FilterAPI(Role = 1, Update  = true)]
        [HttpPut()]
        public async Task<IActionResult> Update(Guid Id,[FromBody] EditUserModel model)
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

            if (await _userRepo.Update(f => f.Id == Id && (f.Id!=Id && f.Username==model.Username), _mapper.Map<User>(model)))
                return Ok();
            return BadRequest();
        }
        
        [FilterAPI(Role = 1, Delete = true)]
        [HttpDelete()]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var User = await _userRepo.CheckByFilter(f => f.Id == Id);
            if (User==null) return NotFound();
            User.IsDeleted = User.IsDeleted == false;

            if (await _userRepo.Update(f => f.Id == User.Id, _mapper.Map<User>(User)))
                return Ok();
            return BadRequest();
        }

    }
}
