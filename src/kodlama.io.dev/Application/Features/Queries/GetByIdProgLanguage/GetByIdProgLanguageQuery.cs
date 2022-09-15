using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Dtos;
using Application.Features.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.GetByIdProgLanguage
{
    public class GetByIdProgLanguageQuery:IRequest<ProgLanguageGetByIdDto>
    {
        public int Id{ get; set; }
        public class GetByIdProgLanguageQueryHandler:IRequestHandler<GetByIdProgLanguageQuery, ProgLanguageGetByIdDto>
        {
            private readonly IProgLanguageRepository _progrLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgLanguageBusinessRules _businessRules;

            public GetByIdProgLanguageQueryHandler(IProgLanguageRepository progrLanguageRepository, IMapper mapper, ProgLanguageBusinessRules businessRules)
            {
                _progrLanguageRepository = progrLanguageRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<ProgLanguageGetByIdDto> Handle(GetByIdProgLanguageQuery request, CancellationToken cancellationToken)
            {
                ProgLanguage? progLanguage = await _progrLanguageRepository.GetAsync(p => p.Id == request.Id);
                _businessRules.ProgrammingLanguageShouldBeExistWhenAsked(progLanguage);
                ProgLanguageGetByIdDto progLanguageGetByIdDto = _mapper.Map<ProgLanguageGetByIdDto>(progLanguage);
                return progLanguageGetByIdDto;
            }
        }
    }
}
