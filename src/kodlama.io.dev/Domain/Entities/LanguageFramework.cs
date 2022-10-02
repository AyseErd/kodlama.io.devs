using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class LanguageFramework:Entity
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public ProgLanguage? ProgrammingLanguage { get; set; }

        public LanguageFramework()
        {
                
        }

        public LanguageFramework(int id, int programmingLanguageId, string name,string version)
        {
            Id = id;
            ProgrammingLanguageId = programmingLanguageId;
            Name = name;
            Version = version;
        }
    }
}
