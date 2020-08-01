using JwtAuth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineWebService.AuthFilterAPI
{
    public class FilterAPI : ActionFilterAttribute
    {
        public int Role { get; set; }
        public bool Add { get; set; }
        public bool Delete { get; set; }
        public bool Update { get; set; }
        public bool View { get; set; }
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            base.OnActionExecuting(context);
            if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                context.Result = new UnauthorizedResult();
            }
            else
            {
                var _userManager = (UserManager)context.HttpContext.RequestServices.GetService(typeof(UserManager));
                var _dbContext = (Data.MagazineContext)context.HttpContext.RequestServices.GetService(typeof(Data.MagazineContext));

                bool check = false;

                if (Delete == true) check = _dbContext.PolicyRoles.AsNoTracking().AnyAsync(f => f.PolicyId == int.Parse(_userManager.GetClaims()["PolicyId"].ToString()) && f.RoleId == _dbContext.Roles.AsNoTracking().FirstOrDefault(d => d.Id == Role && d.IsDeleted.Value == false).Id && f.Delete == Delete).Result;
                else if (Update == true) check = _dbContext.PolicyRoles.AsNoTracking().AnyAsync(f => f.PolicyId == int.Parse(_userManager.GetClaims()["PolicyId"].ToString()) && f.RoleId == _dbContext.Roles.AsNoTracking().FirstOrDefault(d => d.Id == Role && d.IsDeleted.Value == false).Id && f.Update == Update).Result;
                else if (Add == true) check = _dbContext.PolicyRoles.AsNoTracking().AnyAsync(f => f.PolicyId == int.Parse(_userManager.GetClaims()["PolicyId"].ToString()) && f.RoleId == _dbContext.Roles.AsNoTracking().FirstOrDefault(d => d.Id == Role && d.IsDeleted.Value == false).Id && f.Add == Add).Result;
                else if (View == true) check = _dbContext.PolicyRoles.AsNoTracking().AnyAsync(f => f.PolicyId == int.Parse(_userManager.GetClaims()["PolicyId"].ToString()) && f.RoleId == _dbContext.Roles.AsNoTracking().FirstOrDefault(d => d.Id == Role && d.IsDeleted.Value == false).Id && f.View == View).Result;

                if (check == false)
                {
                    context.Result = new UnauthorizedResult();
                }
            }
        }
    }
}
