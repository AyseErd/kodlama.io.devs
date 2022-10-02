using Application.Features.ProgrammingLanguages.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.ProgrammingLanguages.Models
{
    public class ProgLanguageListModel:BasePageableModel
    {
        public IList<ProgLanguageListDto> Items { get; set; }
    }
}
