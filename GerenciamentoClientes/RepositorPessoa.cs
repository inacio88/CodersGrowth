using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoClientes
{
    internal class RepositorPessoa : IRepositorioPessoa
    {
        protected List<Pessoa> listaDePessoas = ListaPessoasSingleTon.obterInstancia();

        public List<Pessoa> ObterTodasPessoas()
        {
            
            return listaDePessoas;
        }

        public void CriarPessoa(Pessoa pessoa)
        {
            listaDePessoas.Add(pessoa);
        }
        public void RemoverPessoa(int Id)
        {
            Pessoa pessoa = ObterPessoaPorId(Id);

            listaDePessoas.Remove(pessoa);
        }
        public Pessoa ObterPessoaPorId(int Id)
        {
            Pessoa pessoaBuscada = listaDePessoas.Find(x => x.Id == Id);

            return pessoaBuscada;
        }

        public void AtualizarPessoa(int Id)
        {
            var pessoaBuscada = ObterPessoaPorId(pessoa.Id);

            pessoaBuscada = pessoa;

            return pessoaBuscada;
        }
    }
}
