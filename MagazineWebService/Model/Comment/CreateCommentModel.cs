using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineWebService.Model.Comment
{
    public class CreateCommentModel
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }
        public DateTime Issued { get; set; }
        public Guid PostId { get; set; }
    }
    public class CreateCommentModelValidator : AbstractValidator<CreateCommentModel>
    {
        public CreateCommentModelValidator()
        {
            RuleFor(f => f.Name).NotEmpty().MaximumLength(150);
            RuleFor(f => f.Text).NotEmpty();
            RuleFor(f => f.PostId).NotEmpty();
        }
    }
}
