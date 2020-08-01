using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineWebService.Infrastructure
{
    public class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public List<string> SlidShow { get; set; }
        public int Views { get; set; }
        public List<string> PhoneNumber { get; set; }
        public List<string> Link { get; set; }
        public string AccreditationNumber { get; set; }
    }
    public class ProfileConfigurations : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> c)
        {
            c.HasKey(f=>f.Id);
            c.Property(f => f.Id).ValueGeneratedOnAdd();

            c.Property(f => f.Logo).HasDefaultValue(null);
            c.Property(f => f.Views).IsRequired().HasDefaultValue(0);
            c.Property(f => f.SlidShow).IsRequired().HasConversion(
                v => string.Join(';', v),
                v => v.Split(';', StringSplitOptions.None).ToList());
            c.Property(f => f.PhoneNumber).IsRequired().HasConversion(
                v => string.Join(';', v),
                v => v.Split(';', StringSplitOptions.None).ToList());
            c.Property(f => f.Link).IsRequired().HasConversion(
                v => string.Join(';', v),
                v => v.Split(';', StringSplitOptions.None).ToList());
            c.Property(f => f.AccreditationNumber).HasMaxLength(10).HasDefaultValue(null);

            var ss = new List<string>();
            ss.Add("asdasda");
            ss.Add("123wqeq");

            c.HasData(new Profile
            {
                Id = 1,
                Name = "asdasd",
                Logo = "1111111111",
                SlidShow = ss,
                Views = 0,
                PhoneNumber = ss,
                Link = ss,
                AccreditationNumber="12301"
            });
        }
    }
}
