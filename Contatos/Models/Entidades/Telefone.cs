using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Contatos.Models
{
    public class Telefone :Entidade
    {
        [DataType(DataType.PhoneNumber)]
        public String Numero { get; set; }
        
        public enums.TiposTelefone Tipo { get; set; }

        public Contato Contato { get; set; }
    }
}