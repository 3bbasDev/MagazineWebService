using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineWebService.Infrastructure
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int Views { get; set; }
        public List<string> Rating { get; set; }
        public List<string> Photo { get; set; }
        public List<string> Link { get; set; }
        public DateTime Issued { get; set; }
        public Guid SectionId { get; set; }
        [ForeignKey(nameof(SectionId))]
        public Section Section { get; set; }
        public bool? IsDeleted { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
    public class PostConfigurations : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> c)
        {
            c.Property(f => f.Id).ValueGeneratedOnAdd();


            c.Property(f => f.Title).IsRequired().HasMaxLength(150);
            c.Property(f => f.Body).IsRequired();
            c.Property(f => f.Views).IsRequired().HasDefaultValue(0);
            c.Property(f => f.Rating).IsRequired().HasConversion(
                v => string.Join(';', v),
                v =>v.Split(';', StringSplitOptions.None).ToList());
            c.Property(f => f.Photo).IsRequired().HasConversion(
                v => string.Join(';', v),
                v => v.Split(';', StringSplitOptions.None).ToList());
            c.Property(f => f.Link).IsRequired().HasConversion(
                v => string.Join(';', v),
                v => v.Split(';', StringSplitOptions.None).ToList());
            c.Property(f => f.Issued).IsRequired();
            c.Property(f => f.SectionId).IsRequired();
            c.Property(f => f.IsDeleted).IsRequired().HasDefaultValue(false);

            c.HasOne(u => u.Section)
             .WithMany(b => b.Posts)
             .HasForeignKey(f => f.SectionId)
             .OnDelete(DeleteBehavior.Restrict);

        }
    }

}
