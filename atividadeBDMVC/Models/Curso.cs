using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace atividadeBDMVC.Models
{
    public class Curso
    {
        [Key]
        public long? CursoID { get; set; }

        public string Nome { get; set; }
        public string Turno { get; set; }
        public int NumeroAlunos { get; set; }

        // ASSOCIACAO DA TABLE CURSOS COM A DEPARTAMENTO 1 - n; 1(departamento)p/ n(cursos)
        public long? DepartamentoID { get; set; }
        public Departamento Departamento { get; set; }
    }
}
