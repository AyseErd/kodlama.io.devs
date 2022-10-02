using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.LanguageFrameworks.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Persistence.Repositories;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.LanguageFrameworks.Queries.GetListLanguageFramework
{
    public class GetListLanguageFrameworkQuery:IRequest<ListLanguageFrameworkModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListLanguageFrameworkQueryHandler:IRequestHandler<GetListLanguageFrameworkQuery,ListLanguageFrameworkModel>
        {
            private readonly IMapper _mapper;
            private readonly ILanguageFrameworkRepository _languageFrameworkRepository;

            public GetListLanguageFrameworkQueryHandler(IMapper mapper, ILanguageFrameworkRepository languageFrameworkRepository)
            {
                _mapper = mapper;
                _languageFrameworkRepository = languageFrameworkRepository;
            }

            public async Task<ListLanguageFrameworkModel> Handle(GetListLanguageFrameworkQuery request, CancellationToken cancellationToken)
            {
                IPaginate<LanguageFramework> languageFrameworks = await _languageFrameworkRepository.GetListAsync(include:
                    l=>l.Include(pl=>pl.ProgrammingLanguage),
                    index:request.PageRequest.Page,
                    size:request.PageRequest.PageSize);

                ListLanguageFrameworkModel mappedModel = _mapper.Map<ListLanguageFrameworkModel>(languageFrameworks);
                return mappedModel;
            }
        }
    }
}
