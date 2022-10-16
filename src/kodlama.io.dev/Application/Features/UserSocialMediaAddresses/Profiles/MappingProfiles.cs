using Application.Features.LanguageFrameworks.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Application.Features.UserSocialMediaAddresses.Commands.CreateSocialMediaAddress;
using Application.Features.UserSocialMediaAddresses.Commands.DeleteSocialMediaAddress;
using Application.Features.UserSocialMediaAddresses.Commands.UpdateSocialMediaAddress;
using Application.Features.UserSocialMediaAddresses.Dtos;

namespace Application.Features.UserSocialMediaAddresses.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserSocialMediaAddress, CreateSocialMediaAddressCommand>().ReverseMap();
            CreateMap<UserSocialMediaAddress, CreatedSocialMediaAddressDto>().ReverseMap();

            CreateMap<UserSocialMediaAddress, UpdateUserMediaAddressCommand>().ReverseMap();
            CreateMap<UserSocialMediaAddress, UpdatedUserSocialMediaAddressDto>().ForMember(m => m.UserEmail,m=>m.MapFrom(m=>m.User.Email)).ReverseMap();

            CreateMap<UserSocialMediaAddress, DeleteUserSocialMediaAddressCommand>().ReverseMap();
            CreateMap<UserSocialMediaAddress, DeletedLanguageFrameworkDto>().ReverseMap();
        }
    }
}
