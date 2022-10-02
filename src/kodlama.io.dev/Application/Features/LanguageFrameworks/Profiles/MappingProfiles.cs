using Application.Features.LanguageFrameworks.Commands.CreateLanguageFramework;
using Application.Features.LanguageFrameworks.Commands.DeleteLanguageFramework;
using Application.Features.LanguageFrameworks.Commands.UpdateLanguageFramework;
using Application.Features.LanguageFrameworks.Dtos;
using Application.Features.LanguageFrameworks.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.LanguageFrameworks.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<LanguageFramework, LanguageFrameworkListDto>().ForMember(pl=>pl.ProgrammingLanguageName,
                opt=>opt.MapFrom(pl=>pl.ProgrammingLanguage.Name)).ReverseMap();
            CreateMap<IPaginate<LanguageFramework>, ListLanguageFrameworkModel>().ReverseMap();
            CreateMap<LanguageFramework, CreateLanguageFrameworkCommand>().ReverseMap();
            CreateMap<LanguageFramework, CreatedLanguageFrameworkDto>()
                .ForMember(lf => lf.ProgrammingLanguageName, lf => lf.MapFrom(pl => pl.ProgrammingLanguage.Name))
                .ReverseMap();
            CreateMap<LanguageFramework, UpdateLanguageFrameworkCommand>().ReverseMap();

            CreateMap<LanguageFramework, UpdatedLanguageFrameworkDto>()
                .ForMember(lf => lf.ProgrammingLanguageName, lf => lf.MapFrom(pl => pl.ProgrammingLanguage.Name))
                .ReverseMap();

            CreateMap<LanguageFramework, DeleteLanguageFrameworkCommand>().ReverseMap();

            CreateMap<LanguageFramework, DeletedLanguageFrameworkDto>().ReverseMap();
        }
    }
}
