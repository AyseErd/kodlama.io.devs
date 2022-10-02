using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageFrameworks.Dtos
{
    public class UpdatedLanguageFrameworkDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string ProgrammingLanguageName { get; set; }
    }
}
