using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Commands
{
    public class CreateProgLanguageCommand:IRequest<CreatedProgLanguageDto>
    {
        public string Name { get; set; }
        public class CreateProgLanguageCommandHandler:IRequestHandler<CreateProgLanguageCommand, CreatedProgLanguageDto>
        {
            private readonly IProgLanguageRepository _progLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgLanguageBusinessRules _progLanguageBusinessRules;

            public CreateProgLanguageCommandHandler(IProgLanguageRepository progLanguageRepository, IMapper mapper, ProgLanguageBusinessRules progLanguageBusinessRules)
            {
                _progLanguageRepository = progLanguageRepository;
                _mapper = mapper;
                _progLanguageBusinessRules = progLanguageBusinessRules;
            }

            public async Task<CreatedProgLanguageDto
            > Handle(CreateProgLanguageCommand request, CancellationToken cancellationToken)
            {

                await _progLanguageBusinessRules.ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

                ProgLanguage mappedProgLanguage = _mapper.Map<ProgLanguage>(request);

                ProgLanguage addedProgLanguage = await _progLanguageRepository.AddAsync(mappedProgLanguage);

                CreatedProgLanguageDto createProgLanguageResult = _mapper.Map<CreatedProgLanguageDto>(addedProgLanguage);

                return createProgLanguageResult;
            }
        }
    }
}
