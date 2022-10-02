using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Application.Features.LanguageFrameworks.Constants;
using Application.Features.ProgrammingLanguages.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.LanguageFrameworks.Rules
{
    public class LanguageFrameworkBusinessRules
    {
        private readonly IProgLanguageRepository _progLanguageRepository;
        private readonly ILanguageFrameworkRepository _languageFrameworkRepository;
        
        public LanguageFrameworkBusinessRules(IProgLanguageRepository progLanguageRepository, ILanguageFrameworkRepository languageFrameworkRepository)
        {
            _progLanguageRepository = progLanguageRepository;
            _languageFrameworkRepository = languageFrameworkRepository;
        }

        public async Task LanguageNameCannotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<LanguageFramework>
                result = await _languageFrameworkRepository.GetListAsync(lf => lf.Name == name);
            if (result.Items.Any()) throw new BusinessException(Messages.LanguageFrameworkDuplicate);
        }

        public async Task LanguageShouldExistWhenAsked(int progLangId)
        {
            ProgLanguage result = await _progLanguageRepository.GetAsync(b => b.Id == progLangId);
            if (result == null) throw new BusinessException(Messages.ProgLanguageNotFound);

        }

        public void LanguageFrameworkShouldBeExistedWhenAsked(LanguageFramework languageFramework)
        {
            if (languageFramework == null) throw new BusinessException(Messages.LanguageFrameworkNotFound);
        }


    }
}
