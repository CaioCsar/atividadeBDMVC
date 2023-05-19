using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace atividadeBDMVC.Models
{
    public class Academico
    {
        public long? AcademicoID { get; set; }
        public string Nome { get; set; }
        //insercao de imagem
        //tipo
        public string imgType { get; set; }
        //convertido em byte
        public byte[] img { get; set; }

        //dado recebido pelo input
        [NotMapped]
        public IFormFile formfile {get;set;}
    }
}
