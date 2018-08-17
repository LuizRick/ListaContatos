using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contatos.Models
{
    public class Telefone :Entidade
    {
        public String Numero { get; set; }
        
        public enums.TiposTelefone Tipo { get; set; }

        public Contato Contato { get; set; }
    }
}