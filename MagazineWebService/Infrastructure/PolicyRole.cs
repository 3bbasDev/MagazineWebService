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
    public class PolicyRole
    {
        public int Id { get; set; }
        public int PolicyId { get; set; }
        [ForeignKey(nameof(PolicyId))]
        public Policy Policy { get; set; }
        public int RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }
        public bool? Add { get; set; }
        public bool? Update { get; set; }
        public bool? View { get; set; }
        public bool? Delete { get; set; }
        public bool? IsDeleted { get; set; }
    }
    public class PolicyRoleConfigurations : IEntityTypeConfiguration<PolicyRole>
    {
        public void Configure(EntityTypeBuilder<PolicyRole> builder)
        {
            builder.Property(f => f.Id).ValueGeneratedOnAdd();
            builder.HasIndex(f => f.Id);

            builder.Property(f => f.PolicyId).IsRequired();
            builder.Property(f => f.RoleId).IsRequired();
            builder.Property(f => f.Add).IsRequired();
            builder.Property(f => f.Update).IsRequired();
            builder.Property(f => f.View).IsRequired();
            builder.Property(f => f.Delete).IsRequired();
            builder.Property(f => f.IsDeleted).IsRequired().HasDefaultValue(false);

            builder
                .HasOne(r => r.Policy)
                .WithMany(p => p.PolicyRoles)
                .HasForeignKey(f => f.PolicyId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(r => r.Role)
                .WithMany(p => p.PolicyRoles)
                .HasForeignKey(f => f.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
            //41

            #region Admin
            builder.HasData(new PolicyRole
            {
                Id = 1,
                PolicyId = 1,
                RoleId = 1,
                Add = true,
                Update = true,
                Delete = true,
                View = true,
                IsDeleted = false
            });
            builder.HasData(new PolicyRole
            {
                Id = 2,
                PolicyId = 1,
                RoleId = 2,
                Add = true,
                Update = true,
                Delete = true,
                View = true,
                IsDeleted = false
            });
            builder.HasData(new PolicyRole
            {
                Id = 3,
                PolicyId = 1,
                RoleId = 3,
                Add = true,
                Update = true,
                Delete = true,
                View = true,
                IsDeleted = false
            });
            builder.HasData(new PolicyRole
            {
                Id = 4,
                PolicyId = 1,
                RoleId = 4,
                Add = true,
                Update = true,
                Delete = true,
                View = true,
                IsDeleted = false
            });
            builder.HasData(new PolicyRole
            {
                Id = 5,
                PolicyId = 1,
                RoleId = 5,
                Add = true,
                Update = true,
                Delete = true,
                View = true,
                IsDeleted = true
            });
            #endregion


        }
    }
}
