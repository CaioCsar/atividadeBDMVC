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
        [Column("DEPID")]
        public long? DepartamentoID { get; set; }

        [Required]
        [StringLength(100)]
        [Column("DEPNOME")]
        public string Nome { get; set; }
    }
}
