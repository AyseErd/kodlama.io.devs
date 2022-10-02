using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.LanguageFrameworks.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.LanguageFrameworks.Models
{
    public class ListLanguageFrameworkModel:BasePageableModel
    {
        public IList<LanguageFrameworkListDto> Items { get; set; }
    }
}
