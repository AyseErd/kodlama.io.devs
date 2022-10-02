using Application.Features.ProgrammingLanguages.Commands;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguages.Queries.GetByIdProgLanguage;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ProgrammingLanguages.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgLanguage, CreatedProgLanguageDto>().ReverseMap();
            CreateMap<ProgLanguage, CreateProgLanguageCommand>().ReverseMap();
            CreateMap<IPaginate<ProgLanguage>, ProgLanguageListModel>().ReverseMap();
            CreateMap<ProgLanguage, ProgLanguageListDto>().ReverseMap();
            CreateMap<ProgLanguage, ProgLanguageGetByIdDto>().ReverseMap();
            CreateMap<ProgLanguage, GetByIdProgLanguageQuery>().ReverseMap();
            CreateMap<ProgLanguage, UpdateProgLanguageCommand>().ReverseMap();
            CreateMap<ProgLanguage, UpdatedProgLanguageDto>().ReverseMap();
            CreateMap<ProgLanguage, DeleteProgLanguageCommand>().ReverseMap();
            CreateMap<ProgLanguage, DeletedProgLanguageDto>().ReverseMap();
        }
    }
}
