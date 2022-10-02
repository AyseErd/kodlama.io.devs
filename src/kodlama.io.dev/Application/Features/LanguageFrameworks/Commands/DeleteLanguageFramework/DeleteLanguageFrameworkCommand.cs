using Application.Features.ProgrammingLanguages.Commands;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.LanguageFrameworks.Dtos;
using Application.Features.LanguageFrameworks.Rules;

namespace Application.Features.LanguageFrameworks.Commands.DeleteLanguageFramework
{
    public class DeleteLanguageFrameworkCommand : IRequest<DeletedLanguageFrameworkDto>
    {
        public int Id { get; set; }
        public class DeleteLanguageFrameworkCommandHandler : IRequestHandler<DeleteLanguageFrameworkCommand, DeletedLanguageFrameworkDto>
        {
            private readonly ILanguageFrameworkRepository _languageFrameworkRepository;
            private readonly IMapper _mapper;
            private readonly LanguageFrameworkBusinessRules _businessRules;

            public DeleteLanguageFrameworkCommandHandler(ILanguageFrameworkRepository ILanguageFrameworkRepository, IMapper mapper, LanguageFrameworkBusinessRules progLanguageBusinessRules)
            {
                _languageFrameworkRepository = ILanguageFrameworkRepository;
                _mapper = mapper;
                _businessRules = progLanguageBusinessRules;
            }

            public async Task<DeletedLanguageFrameworkDto> Handle(DeleteLanguageFrameworkCommand request, CancellationToken cancellationToken)
            {
                LanguageFramework? languageFramework = await _languageFrameworkRepository.GetAsync(p => p.Id == request.Id);

                _businessRules.LanguageFrameworkShouldBeExistedWhenAsked(languageFramework);

                LanguageFramework deletedProgrammingLanguage = await _languageFrameworkRepository.DeleteAsync(languageFramework);
                DeletedLanguageFrameworkDto deletedLanguageFrameworkDto = _mapper.Map<DeletedLanguageFrameworkDto>(deletedProgrammingLanguage);

                return deletedLanguageFrameworkDto;
            }
        }
    }
}