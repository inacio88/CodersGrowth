using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infraestrutura
{
    internal class RepositorListaPessoa : IRepositorioPessoa
    {
        protected List<Pessoa> listaDePessoas = ListaPessoasSingleTon.obterInstancia();

        public List<Pessoa> ObterTodasPessoas()
        {            
            return listaDePessoas;
        }

        public int CriarPessoa(Pessoa pessoa)
        {
            listaDePessoas.Add(pessoa);
            return pessoa.Id;
        }

        public void RemoverPessoa(int Id)
        {
            var pessoa = ObterPessoaPorId(Id);

            listaDePessoas.Remove(pessoa);
        }

        public Pessoa ObterPessoaPorId(int Id)
        {
            var pessoaBuscada = listaDePessoas.Find(x => x.Id == Id);

            return pessoaBuscada;
        }

        public void AtualizarPessoa(Pessoa pessoa)
        {
            var pessoaBuscada = ObterPessoaPorId(pessoa.Id);

            pessoaBuscada = pessoa;

        }

        public bool ObterPessoaPorCpf(string Cpf, int Id)
        {
            return false;
        }
    }
}
