using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura
{
    public interface IRepositorioPessoa
    {
        public List<Pessoa> ObterTodasPessoas();
        public void CriarPessoa(Pessoa pessoa);
        public void RemoverPessoa(int Id);
        public Pessoa ObterPessoaPorId(int Id);
        public Pessoa AtualizarPessoa(Pessoa pessoa);

    }
}
