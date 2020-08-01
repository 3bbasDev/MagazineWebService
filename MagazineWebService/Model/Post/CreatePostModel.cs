using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineWebService.Model.Post
{
    public class CreatePostModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public List<string> Photo { get; set; }
        public List<string> Link { get; set; }
        public DateTime Issued { get; set; }
        public Guid SectionId { get; set; }
    }
    public class CreatePostModelValidator : AbstractValidator<CreatePostModel>
    {
        public CreatePostModelValidator()
        {
            RuleFor(f => f.Title).NotEmpty().MaximumLength(150);
            RuleFor(f => f.Body).NotEmpty();
            RuleFor(f => f.Issued).NotEmpty();
            RuleFor(f => f.SectionId).NotEmpty();
        }
    }
}
