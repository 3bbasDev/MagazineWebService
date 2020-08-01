using AutoMapper;
using MagazineWebService.Infrastructure;
using MagazineWebService.Model.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineWebService.MapperProfiles
{
    public class CommentProfile : AutoMapper.Profile
    {
        public CommentProfile()
        {
            CreateMap<CreateCommentModel, Comment>();
            CreateMap<Comment, Comment>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null && srcMember.ToString() != ""));
            //.ForMember(dest=>dest.FirstName,opt=>opt.MapFrom(f=>f.FirstName+"@gmail.com"));
        }
    }
}
