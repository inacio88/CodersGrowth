using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoClientes
{
    public class Pessoa
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public DateTime data_nascimento { get; set; }
        public int cpf { get; set; }

    }
}
