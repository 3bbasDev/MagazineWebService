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
    public class Section
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        [ForeignKey(nameof(ParentId))]
        public Section Parent { get; set; }
        public bool? IsDeleted { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Section> Sections { get; set; }
    }
    public class SectionConfigurations : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> c)
        {
            c.Property(f => f.Id).ValueGeneratedOnAdd();


            c.Property(f => f.Name).IsRequired().HasMaxLength(150);
            c.Property(f => f.ParentId).HasDefaultValue(null);
            c.Property(f => f.IsDeleted).IsRequired().HasDefaultValue(false);

            c.HasOne(u => u.Parent)
             .WithMany(b => b.Sections)
             .HasForeignKey(f => f.ParentId)
             .OnDelete(DeleteBehavior.Restrict);

            //اخبار
            c.HasData(new Section
            {
                Id = new Guid("9edcd3e6-f364-4a06-9ce1-87fa6e057874"),
                Name = "الاخبار",
                ParentId = null,
                IsDeleted = false
            });
            c.HasData(new Section
            {
                Id = new Guid("9dccd319-4a8b-404a-9f91-fce8b279b19d"),
                Name = "اخبار محلية",
                ParentId = new Guid("9edcd3e6-f364-4a06-9ce1-87fa6e057874"),
                IsDeleted = false
            });
            c.HasData(new Section
            {
                Id = new Guid("2f515dea-9a94-4a57-bcb6-2562b0ee60f5"),
                Name = "اخبار دولية",
                ParentId = new Guid("9edcd3e6-f364-4a06-9ce1-87fa6e057874"),
                IsDeleted = false
            });
            c.HasData(new Section
            {
                Id = new Guid("8223eeed-3df2-4d1f-9b04-9d1ec6ad1c3d"),
                Name = "اخبار عربية",
                ParentId = new Guid("9edcd3e6-f364-4a06-9ce1-87fa6e057874"),
                IsDeleted = false
            });
            c.HasData(new Section
            {
                Id = new Guid("bae1e65f-4bff-4627-a39e-8807f7005c47"),
                Name = "اخبار امنية",
                ParentId = new Guid("9edcd3e6-f364-4a06-9ce1-87fa6e057874"),
                IsDeleted = false
            });
            c.HasData(new Section
            {
                Id = new Guid("d1de1f0c-74d7-482d-814e-c82e5693fc9c"),
                Name = "اخبار سياسية",
                ParentId = new Guid("9edcd3e6-f364-4a06-9ce1-87fa6e057874"),
                IsDeleted = false
            });
            //****
            //ثقاقة
            c.HasData(new Section
            {
                Id = new Guid("2f6d3098-ede5-4125-b8e5-6131327b876d"),
                Name = "ثقافة",
                ParentId = null,
                IsDeleted = false
            });
            //****
            //رياضة
            c.HasData(new Section
            {
                Id = new Guid("680dbcab-7a33-47ca-9fea-0b2f19ae11f6"),
                Name = "رياضة",
                ParentId = null,
                IsDeleted = false
            });
            c.HasData(new Section
            {
                Id = new Guid("7d9ee551-aec3-4b17-826c-7df954b12375"),
                Name = "رياضة محلية",
                ParentId = new Guid("680dbcab-7a33-47ca-9fea-0b2f19ae11f6"),
                IsDeleted = false
            });
            c.HasData(new Section
            {
                Id = new Guid("7be8a042-e4ca-499b-8068-d3af75f259e7"),
                Name = "رياضة عربية",
                ParentId = new Guid("680dbcab-7a33-47ca-9fea-0b2f19ae11f6"),
                IsDeleted = false
            });
            c.HasData(new Section
            {
                Id = new Guid("bd03554e-5c70-49d1-8fba-09bd326a4091"),
                Name = "رياضة دولية",
                ParentId = new Guid("680dbcab-7a33-47ca-9fea-0b2f19ae11f6"),
                IsDeleted = false
            });
            //****
            //اقتصاد
            c.HasData(new Section
            {
                Id = new Guid("fe22da2e-9b47-44e4-911c-3e225ac69e76"),
                Name = "اقتصاد",
                ParentId = null,
                IsDeleted = false
            });
            c.HasData(new Section
            {
                Id = new Guid("a338c36f-febf-454e-85ce-6ba80037272e"),
                Name = "اقتصاد محلي",
                ParentId = new Guid("fe22da2e-9b47-44e4-911c-3e225ac69e76"),
                IsDeleted = false
            });
            c.HasData(new Section
            {
                Id = new Guid("0d19070c-caa5-4097-af84-398635e62b78"),
                Name = "اقتصاد عربي",
                ParentId = new Guid("fe22da2e-9b47-44e4-911c-3e225ac69e76"),
                IsDeleted = false
            });
            c.HasData(new Section
            {
                Id = new Guid("589c4332-3207-4a99-a386-1e136f8f2535"),
                Name = "اقتصاد عالمي",
                ParentId = new Guid("fe22da2e-9b47-44e4-911c-3e225ac69e76"),
                IsDeleted = false
            });
            //****
            //تحقيقات واستطلاعات
            c.HasData(new Section
            {
                Id = new Guid("794019be-ca17-4f39-bc39-ba3aeb6abbed"),
                Name = "تحقيقات واستطلاعات",
                ParentId = null,
                IsDeleted = false
            });
            //****
            //حوارات
            c.HasData(new Section
            {
                Id = new Guid("11a9dc6d-45e8-4ba0-a6f5-db294afbcf1b"),
                Name = "حوارات",
                ParentId = null,
                IsDeleted = false
            });
            //****
            //منوعات
            c.HasData(new Section
            {
                Id = new Guid("24c15152-ec93-4fb7-b94b-ffab71b8f64f"),
                Name = "منوعات",
                ParentId = null,
                IsDeleted = false
            });
            //****
            //مقالات
            c.HasData(new Section
            {
                Id = new Guid("af677486-1e9b-4526-96be-8a70fcc5788a"),
                Name = "مقالات",
                ParentId = null,
                IsDeleted = false
            });
            //****
            //اثار ومواقع
            c.HasData(new Section
            {
                Id = new Guid("12555e70-5bde-4b12-82fd-0584bd74aa8b"),
                Name = "اثار ومواقع",
                ParentId = null,
                IsDeleted = false
            });/*
            c.HasData(new Section
            {
                Id = new Guid("7e6493a2-04e6-4599-ad02-1158b6665207"),
                Name = "admin",
                ParentId = null,
                IsDeleted = false
            });
            c.HasData(new Section
            {
                Id = new Guid("ff495115-4189-4db8-9dcd-91119d7019b6"),
                Name = "admin",
                ParentId = null,
                IsDeleted = false
            });
            c.HasData(new Section
            {
                Id = new Guid("3a7b5fcd-1d03-42d7-845f-62180439ded3"),
                Name = "admin",
                ParentId = null,
                IsDeleted = false
            });
            c.HasData(new Section
            {
                Id = new Guid("3b8968f9-b247-4a47-b6bd-bf40f46b4c8e"),
                Name = "admin",
                ParentId = null,
                IsDeleted = false
            });
            c.HasData(new Section
            {
                Id = new Guid("7207f808-d8b9-49e3-b7f0-cdd5e1e7fe91"),
                Name = "admin",
                ParentId = null,
                IsDeleted = false
            });
            c.HasData(new Section
            {
                Id = new Guid("61d52927-ffa1-4fcb-aa44-65a2b4e7df0f"),
                Name = "admin",
                ParentId = null,
                IsDeleted = false
            });
            c.HasData(new Section
            {
                Id = new Guid("6459c1f6-4dce-4a2b-b5e4-3ad1b57df507"),
                Name = "admin",
                ParentId = null,
                IsDeleted = false
            });
            */

        }
    }
}
