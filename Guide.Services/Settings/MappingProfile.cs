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
            CreateMap<Marker, MarkerDto>().ReverseMap();
        }
    }
}
