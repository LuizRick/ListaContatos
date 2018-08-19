using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contatos.Models.enums;

namespace Contatos.Helpers
{
    public static class EnumExtensions
    {
        public static string TelefoneTypeName(TiposTelefone tipo)
        {
            string type = "";
            switch (tipo)
            {   
                case TiposTelefone.Residencial:
                    type =  "(Residencial)";
                    break;
                case TiposTelefone.Comercial:
                    type = "(Comercial)";
                    break;
                case TiposTelefone.Celular:
                    type = "(Celular)";
                    break;
                case TiposTelefone.Fax:
                    type = "Fax";
                    break;
                case TiposTelefone.Outros:
                    type = "outros";
                    break;
                default:
                    type = "--";
                    break;
            }
            return type;
        }

        public static string EmailTypeName(TiposEmail tipos)
        {
            string typeName = "";
            switch (tipos)
            {
                case TiposEmail.Profissional:
                    typeName = "(Profissional)";
                    break;
                case TiposEmail.Pessoal:
                    typeName = "(Pessoal)";
                    break;
                default:
                    typeName = "--";
                    break;
            }
            return typeName;
        }
    }
}