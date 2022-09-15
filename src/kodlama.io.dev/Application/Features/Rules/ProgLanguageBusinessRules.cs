using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Application.Features.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Rules
{
    public class ProgLanguageBusinessRules
    {
        private readonly IProgLanguageRepository _progLanguageRepository;

        public ProgLanguageBusinessRules(IProgLanguageRepository progLanguageRepository)
        {
            _progLanguageRepository = progLanguageRepository;
        }

        public async Task ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgLanguage> result = await _progLanguageRepository.GetListAsync(
                b=>b.Name==name);
            if(result.Items.Any()) throw new BusinessException(BusinessErrorMessages.ProgLanguageDuplicate);
        }

        public void ProgrammingLanguageShouldBeExistWhenAsked(ProgLanguage progLanguage)
        {if(progLanguage==null) throw new BusinessException(BusinessErrorMessages.ProgLanguageNotFound);    
        }

        public async Task ProgrammingLanguageNAmeShouldBeUniqueWhileUpdating(string name)
        {
            ProgLanguage? result = await _progLanguageRepository.GetAsync(
                b => b.Name == name);
            if(result!=null) throw new BusinessException(BusinessErrorMessages.ProgLanguageDuplicate);
        }
    }
}
