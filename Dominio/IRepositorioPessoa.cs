using System.Collections.Generic;

namespace Dominio
{
    public interface IRepositorioPessoa
    {
        public List<Pessoa> ObterTodasPessoas();
        public void CriarPessoa(Pessoa pessoa);
        public void RemoverPessoa(int Id);
        public Pessoa ObterPessoaPorId(int Id);
        public Pessoa AtualizarPessoa(Pessoa pessoa);
        public Pessoa ObterPessoaPorCpf(string Cpf);

    }
}
