using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contatos.Models
{
    public class Email : Entidade
    {
        public String Endereco { get; set; }

        public enums.TiposEmail Tipo {get;set;}

        public Contato Contato { get; set; }
    }
}