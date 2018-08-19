using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contatos.Models.BLL
{
    interface IStrategy
    {
        string Processar(Entidade entidade);
    }
}
