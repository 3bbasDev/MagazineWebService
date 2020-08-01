using AutoMapper;
using JwtAuth;
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
    public class AuthController : ControllerBase
    {
        private readonly IGenericRepo<User> _userRepo;
        private readonly IMapper _mapper;
        private readonly UserManager _userManager;
        public AuthController(IMapper mapper, IGenericRepo<User> userRepo, UserManager userManager)
        {
            _mapper = mapper;
            _userRepo = userRepo;
            _userManager = userManager;
        }

        [HttpPost()]
        public async Task<IActionResult> Login(AuthModel model)
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

            var User = await _userRepo.CheckByFilter(f => f.Username == model.Username);
            if (User == null) return NotFound("User Dose Not Exist OR invalid User password");

            if (!JwtAuth.Tools.Hasher.Compare(User.Password, model.Password)) return NotFound("User Dose Not Exist OR invalid User password"); ;


            Dictionary<string, object> cl = new Dictionary<string, object>();
            cl.Add("UserID", User.Id);
            cl.Add("PolicyId", User.PolicyId);


            return StatusCode(200, new
            {
                code = 200,
                message = "user is exsits",
                result = new
                {
                    UserId = User.Id,
                    User.FullName,
                    User.Email,
                    Token = _userManager.GenerateToken(User.Id, cl)
                    //CountAlert = CountAlert
                }
            });

        }
    }
}
