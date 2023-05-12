using System.Collections.Generic;

namespace Dominio
{
    public interface IRepositorioPessoa
    {
        public List<Pessoa> ObterTodasPessoas();
        public void CriarPessoa(Pessoa pessoa);
        public void RemoverPessoa(int Id);
        public Pessoa ObterPessoaPorId(int Id);
        public void AtualizarPessoa(Pessoa pessoa);
        public bool ObterPessoaPorCpf(string Cpf, int Id);

    }
}
