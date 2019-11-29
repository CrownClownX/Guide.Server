using AutoMapper;
using Guide.BLL.Models;
using Guide.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guide.Services.Settings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<NewUserDto, User>();
            CreateMap<Marker, MarkerDto>()
                .ForMember(m => m.Shortcut, opt => opt.MapFrom(
                    m2 => m2.Category != null ? m2.Category.Shortcut : ""));
            CreateMap<MarkerDto, Marker>();
            CreateMap<User, Password>();
        }
    }
}
