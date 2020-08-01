using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineWebService.Infrastructure
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsDeleted { get; set; }
        public ICollection<PolicyRole> PolicyRoles { get; set; }
    }
    public class RoleConfigurations : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(f => f.Id).ValueGeneratedOnAdd();

            builder.Property(f => f.Name).IsRequired().HasMaxLength(30);
            builder.Property(f => f.IsDeleted).IsRequired().HasDefaultValue(false);

            builder.HasData(new Role
            { Id = 1, Name = "User", IsDeleted = false });
            builder.HasData(new Role
            { Id = 2, Name = "Post", IsDeleted = false });
            builder.HasData(new Role
            { Id = 3, Name = "Comment", IsDeleted = false });
            builder.HasData(new Role
            { Id = 4, Name = "Section", IsDeleted = false });
            builder.HasData(new Role
            { Id = 5, Name = "Upload", IsDeleted = false });
        }
    }
}
