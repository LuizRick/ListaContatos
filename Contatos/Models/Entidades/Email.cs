using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Contatos.Models
{
    public class Email : Entidade
    {
        [DataType(DataType.EmailAddress)]
        public String Endereco { get; set; }

        public enums.TiposEmail Tipo { get; set; }

        public Contato Contato { get; set; }
    }
}