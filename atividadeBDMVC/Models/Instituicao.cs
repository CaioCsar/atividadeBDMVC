using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace atividadeBDMVC.Models
{
    public class Instituicao
    {
        [Key]
        [Column("INSTID")]
        public long? InstituicaoID { get; set; }

        [Required]
        [StringLength(100)]
        [Column("INSTNOME")]
        public string Nome { get; set; }

        [Required]
        [StringLength(100)]
        [Column("INSTENDERECO")]
        public string Endereco { get; set; }
    }
}
