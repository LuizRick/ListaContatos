using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contatos.Models.BLL
{
    public class ValidarNomeUnico : IStrategy
    {
        public string Processar(Entidade entidade)
        {
            var contato = (Models.Contato)entidade;
            DAL.ContatoDAL contatoDAL = new DAL.ContatoDAL();

            var contatos = contatoDAL.Consultar(contato);
            foreach(var ct in contatos)
            {
                if(ct.Nome == contato.Nome)
                {
                    return "Nome já existe na lista de contatos";
                }
            }
            return null;
        }
    }
}