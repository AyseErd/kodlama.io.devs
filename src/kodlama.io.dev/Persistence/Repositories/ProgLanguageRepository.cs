
using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class ProgLanguageRepository:EfRepositoryBase<ProgLanguage,BaseDbContext>,IProgLanguageRepository
    {
        public ProgLanguageRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
