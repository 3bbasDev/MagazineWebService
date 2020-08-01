using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineWebService.Model.User
{
    public class CreateUserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PolicyId { get; set; }
    }
    public class CreateUserValidator : AbstractValidator<CreateUserModel>
    {
        public CreateUserValidator()
        {
            RuleFor(f => f.Username).NotEmpty().MinimumLength(4).MaximumLength(20);
            RuleFor(f => f.Password).NotEmpty().MinimumLength(4).MaximumLength(20);
            RuleFor(f => f.FirstName).NotEmpty().MinimumLength(2).MaximumLength(20);
            RuleFor(f => f.LastName).NotEmpty().MinimumLength(2).MaximumLength(20);
            RuleFor(f => f.Email);
            RuleFor(f => f.PolicyId).NotEmpty();
        }
    }
}
