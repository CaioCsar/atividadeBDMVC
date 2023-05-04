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

        public long? InstituicaoID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(100)]
        public string Endereco { get; set; }

        // associacao de instituicao para departamento, 1-n, aonde uma instituicao pode ter varios departamentos
        public virtual ICollection<Departamento> Departamentos { get; set; }

    /*"Nessa listagem, a propriedade Departamentos é uma ICollection<Departamento> , e é definida como virtual . Definir
    elementos como virtual possibilita a sua sobrescrita, o que, para o EF Core, é necessário.Assim, ele poderá fazer o
    Lazy Load(carregamento tardio), por meio de um padrão de projeto conhecido como Proxy." */
    }
}
