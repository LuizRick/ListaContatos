using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Contatos.Models
{
    public class Contato : Entidade
    {
        public String Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public List<Telefone> Telefones { get; set; }

        public List<Email> Emails { get; set; }
    }
}