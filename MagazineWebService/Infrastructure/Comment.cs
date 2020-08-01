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
    public class Comment
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }
        public DateTime Issued { get; set; }

        public Guid PostId { get; set; }
        [ForeignKey(nameof(PostId))]
        public Post Post { get; set; }
    }
    public class CommentConfigurations : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> c)
        {
            c.Property(f => f.Id).ValueGeneratedOnAdd();


            c.Property(f => f.Name).IsRequired().HasMaxLength(150);
            c.Property(f => f.Country).HasMaxLength(50).HasDefaultValue(null);
            c.Property(f => f.Email).HasMaxLength(50).HasDefaultValue(null);
            c.Property(f => f.Text).IsRequired();
            c.Property(f => f.Issued).IsRequired();
            c.Property(f => f.PostId).IsRequired();

            c.HasOne(u => u.Post)
             .WithMany(b => b.Comments)
             .HasForeignKey(f => f.PostId)
             .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
