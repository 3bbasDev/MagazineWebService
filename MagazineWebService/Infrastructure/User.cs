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
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => String.Join(' ', FirstName, LastName);
        public bool? IsDeleted { get; set; }
        public string Email { get; set; }
        public int PolicyId { get; set; }
        [ForeignKey(nameof(PolicyId))]
        public Policy Policy { get; set; }

    }
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> c)
        {
            c.Property(f => f.Id).ValueGeneratedOnAdd();

            c.HasIndex(f => f.Username).IsUnique();

            c.Property(f => f.Username).IsRequired().HasMaxLength(20);
            c.Property(f => f.Password).IsRequired().HasMaxLength(150).HasConversion(v => JwtAuth.Tools.Hasher.Hash(v), v => v);
            c.Property(f => f.FirstName).IsRequired().HasMaxLength(20);
            c.Property(f => f.LastName).IsRequired().HasMaxLength(20);
            c.Property(f => f.Email).HasMaxLength(100).HasDefaultValue(null);
            c.Property(f => f.IsDeleted).IsRequired().HasDefaultValue(false);
            c.Property(f => f.PolicyId).IsRequired();

            c.HasOne(u => u.Policy)
             .WithMany(b => b.Users)
             .HasForeignKey(f => f.PolicyId)
             .OnDelete(DeleteBehavior.Restrict);


            c.HasData(new User
            {
                Id = new Guid("86c70521-b68b-4f77-88fa-a4478bca59c1"),
                Username = "admin",
                Password = "123@root",
                FirstName = "ahmed",
                LastName = "Ali",
                PolicyId = 1,
                IsDeleted = false
            });

        }
    }
}
