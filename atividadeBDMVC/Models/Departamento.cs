using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace atividadeBDMVC.Models
{
    public class Departamento
    {
        [Key]
        public long? DepartamentoID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        public string Campus { get; set; }

        // ASSOCIACAO DA TABLE INSTITUICAO COM A DEPARTAMENTO 1 - n; 1(instituicao)p/ n(departamento)
        public long? InstituicaoID { get; set; }
        public Instituicao Instituicao { get; set; }

        // ASSOCIACAO DA TABLE CURSOS COM A DEPARTAMENTO 1 - n; 1(departamento)p/ n(cursos)
        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
