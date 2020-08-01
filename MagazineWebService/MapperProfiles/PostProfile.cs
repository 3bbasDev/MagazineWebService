using MagazineWebService.Infrastructure;
using MagazineWebService.Model.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineWebService.MapperProfiles
{
    public class PostProfile : AutoMapper.Profile
    {
        public PostProfile()
        {
            CreateMap<CreatePostModel, Post>();
            CreateMap<Post, Post>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null && srcMember.ToString() != ""));
            CreateMap<EditPostModel, Post>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null && srcMember.ToString() != ""));
        }
    }
}
