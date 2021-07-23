using API.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Account, Account1>().ForMember(dest => dest.fname, opt => opt.MapFrom(x => x.Firstname))
                .ForMember(dest => dest.lname, opt => opt.MapFrom(x => x.Lastname))
                .ForMember(dest => dest.gender, opt => opt.MapFrom(x => x.Gender))
                .ForMember(dest => dest.email, opt => opt.MapFrom(x => x.Email))
                .ForMember(dest => dest.user, opt => opt.MapFrom(x => x.Username))
                .ForMember(dest => dest.pass, opt => opt.MapFrom(x => x.Password));
        }
    }
}
