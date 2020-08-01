using AutoMapper;
using MagazineWebService.Infrastructure;
using MagazineWebService.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineWebService.MapperProfiles
{
    public class UserProfile:AutoMapper.Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserModel, User>();
            CreateMap<User, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null && srcMember.ToString() != ""));
            CreateMap<EditUserModel, User>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null && srcMember.ToString() != ""));
            //CreateMap<User, CreateUserModel>();
            //.ForMember(dest=>dest.FirstName,opt=>opt.MapFrom(f=>f.FirstName+"@gmail.com"));
        }
    }
}
