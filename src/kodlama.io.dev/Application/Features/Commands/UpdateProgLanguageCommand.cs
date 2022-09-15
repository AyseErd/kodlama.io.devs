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
    public class UpdateProgLanguageCommand:IRequest<UpdatedProgLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class UpdateProgLanguageCommandHandler:IRequestHandler<UpdateProgLanguageCommand, UpdatedProgLanguageDto>
        {
            private readonly IProgLanguageRepository _progLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgLanguageBusinessRules _businessRules;

            public UpdateProgLanguageCommandHandler(IProgLanguageRepository progLanguageRepository, IMapper mapper, ProgLanguageBusinessRules businessRules)
            {
                _progLanguageRepository = progLanguageRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<UpdatedProgLanguageDto> Handle(UpdateProgLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgLanguage? progLanguage = await _progLanguageRepository.GetAsync(l=>l.Id==request.Id);
                await _businessRules.ProgrammingLanguageNAmeShouldBeUniqueWhileUpdating(request.Name);
                progLanguage.Name = request.Name;
                await _progLanguageRepository.UpdateAsync(progLanguage);
                UpdatedProgLanguageDto updatedProgLanguageDto = _mapper.Map<UpdatedProgLanguageDto>(progLanguage);
                return updatedProgLanguageDto;
            }
        }
    }
}
