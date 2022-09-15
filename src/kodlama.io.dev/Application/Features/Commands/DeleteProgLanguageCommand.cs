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

namespace Application.Features.Commands
{
    public class DeleteProgLanguageCommand:IRequest<DeletedProgLanguageDto>
    {
        public int Id { get; set; }
        public class DeleteProgLanguageCommandHandler:IRequestHandler<DeleteProgLanguageCommand, DeletedProgLanguageDto>
        {
            private readonly IProgLanguageRepository _progLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgLanguageBusinessRules _businessRules;

            public DeleteProgLanguageCommandHandler(IProgLanguageRepository progLanguageRepository, IMapper mapper, ProgLanguageBusinessRules progLanguageBusinessRules)
            {
                _progLanguageRepository = progLanguageRepository;
                _mapper = mapper;
                _businessRules = progLanguageBusinessRules;
            }

            public async Task<DeletedProgLanguageDto> Handle(DeleteProgLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgLanguage? programmingLanguage = await _progLanguageRepository.GetAsync(p => p.Id == request.Id);

                _businessRules.ProgrammingLanguageShouldBeExistWhenAsked(programmingLanguage);

                ProgLanguage deletedProgrammingLanguage = await _progLanguageRepository.DeleteAsync(programmingLanguage);
                DeletedProgLanguageDto deletedProgrammingLanguageDto = _mapper.Map<DeletedProgLanguageDto>(deletedProgrammingLanguage);

                return deletedProgrammingLanguageDto;
            }
        }
    }
}
