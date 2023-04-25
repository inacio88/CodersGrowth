using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoClientes
{
    public sealed class ListaPessoasSingleTon
    {
        private static List<Pessoa> instancia;
        
        public static List<Pessoa> getInstance()
        {
            if (instancia == null)
            {
                instancia = new List<Pessoa>();
            }

            return instancia;
        }

    }

}
