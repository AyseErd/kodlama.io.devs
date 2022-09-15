using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Commands;
using Application.Features.Dtos;
using Application.Features.Models;
using Application.Features.Queries.GetByIdProgLanguage;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Profiles
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
