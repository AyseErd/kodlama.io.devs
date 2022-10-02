using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.LanguageFrameworks.Dtos;
using Application.Features.LanguageFrameworks.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.LanguageFrameworks.Commands.CreateLanguageFramework
{
    public class CreateLanguageFrameworkCommand:IRequest<CreatedLanguageFrameworkDto>
    {
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public class CreateLanguageFrameworkCommandHandler:IRequestHandler<CreateLanguageFrameworkCommand, CreatedLanguageFrameworkDto>
        {
            private readonly LanguageFrameworkBusinessRules _LanguageFrameworkBusinessRules;
            private readonly ILanguageFrameworkRepository _languageFrameworkRepository;
            private readonly IMapper _mapper;

            public CreateLanguageFrameworkCommandHandler(LanguageFrameworkBusinessRules languageFrameworkBusinessRules, ILanguageFrameworkRepository languageFrameworkRepository, IMapper mapper)
            {
                _LanguageFrameworkBusinessRules = languageFrameworkBusinessRules;
                _languageFrameworkRepository = languageFrameworkRepository;
                _mapper = mapper;
            }

            public async Task<CreatedLanguageFrameworkDto> Handle(CreateLanguageFrameworkCommand request, CancellationToken cancellationToken)
            {
                await _LanguageFrameworkBusinessRules.LanguageShouldExistWhenAsked(request.ProgrammingLanguageId);
               await _LanguageFrameworkBusinessRules.LanguageNameCannotBeDuplicatedWhenInserted(request.Name);
               LanguageFramework mappedLanguageFramework = _mapper.Map<LanguageFramework>(request);
               LanguageFramework languageFramework =
                   await _languageFrameworkRepository.AddAsync(mappedLanguageFramework);
               CreatedLanguageFrameworkDto createdLanguageFramework =
                   _mapper.Map<CreatedLanguageFrameworkDto>(languageFramework);
               return createdLanguageFramework;
            }
        }
    }
}
