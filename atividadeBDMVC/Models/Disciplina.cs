using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace atividadeBDMVC.Models
{
    public class Disciplina
    {
        public long? DisciplinaID { get; set; }
        public string Nome { get; set; }

        //Associacao de Curso e Disciplina

        public virtual ICollection<CursoDisciplina> CursoDisciplinas { get; set; }
    }
}
