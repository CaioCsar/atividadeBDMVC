using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace atividadeBDMVC.Models
{
    public class CursoDisciplina
    {
        public long? CursoID { get; set; }
        public long? DisciplinaID { get; set; }
        public Curso Curso { get; set; }
        public Disciplina Disciplina { get; set; }

    }
}
