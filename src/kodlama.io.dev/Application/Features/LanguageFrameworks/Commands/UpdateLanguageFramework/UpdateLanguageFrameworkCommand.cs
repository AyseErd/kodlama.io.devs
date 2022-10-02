using Application.Features.LanguageFrameworks.Commands.CreateLanguageFramework;
using Application.Features.LanguageFrameworks.Dtos;
using Application.Features.LanguageFrameworks.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageFrameworks.Commands.UpdateLanguageFramework
{
    public class UpdateLanguageFrameworkCommand : IRequest<UpdatedLanguageFrameworkDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public class UpdateLanguageFrameworkCommandHandler : IRequestHandler<UpdateLanguageFrameworkCommand, UpdatedLanguageFrameworkDto>
        {
            private readonly LanguageFrameworkBusinessRules _LanguageFrameworkBusinessRules;
            private readonly ILanguageFrameworkRepository _languageFrameworkRepository;
            private readonly IMapper _mapper;

            public UpdateLanguageFrameworkCommandHandler(LanguageFrameworkBusinessRules languageFrameworkBusinessRules, ILanguageFrameworkRepository languageFrameworkRepository, IMapper mapper)
            {
                _LanguageFrameworkBusinessRules = languageFrameworkBusinessRules;
                _languageFrameworkRepository = languageFrameworkRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedLanguageFrameworkDto> Handle(UpdateLanguageFrameworkCommand request, CancellationToken cancellationToken)
            {
                await _LanguageFrameworkBusinessRules.LanguageShouldExistWhenAsked(request.ProgrammingLanguageId);
                await _LanguageFrameworkBusinessRules.LanguageNameCannotBeDuplicatedWhenInserted(request.Name);

                LanguageFramework foundLanguageFramework =
                    await _languageFrameworkRepository.GetAsync(lf => lf.Id == request.Id);
                foundLanguageFramework.Name = request.Name;
                LanguageFramework updatedLanguageFramework = await 
                    _languageFrameworkRepository.UpdateAsync(foundLanguageFramework);


                UpdatedLanguageFrameworkDto createdLanguageFramework =
                    _mapper.Map<UpdatedLanguageFrameworkDto>(updatedLanguageFramework);
                return createdLanguageFramework;
            }
        }
    }
}
