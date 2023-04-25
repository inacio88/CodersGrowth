using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoClientes
{
    internal interface IRepositorioPessoa
    {
        public List<Pessoa> ObterTodos();
        public void CriarPessoa();
        public void Remover(int Id);
        public Pessoa ObterPorId(int Id);

        public Pessoa Atualizar(int Id);

    }
}
