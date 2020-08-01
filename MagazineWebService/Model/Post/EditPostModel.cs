using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineWebService.Model.Post
{
    public class EditPostModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public List<string> Photo { get; set; }
        public List<string> Link { get; set; }
        public DateTime Issued { get; set; }
        public Guid SectionId { get; set; }
    }
    public class EditPostModelValidator : AbstractValidator<EditPostModel>
    {
        public EditPostModelValidator()
        {
            RuleFor(f => f.Title);
            RuleFor(f => f.Body);
            RuleFor(f => f.Issued);
            RuleFor(f => f.SectionId);
        }
    }
}
