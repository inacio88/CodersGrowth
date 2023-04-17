namespace GerenciamentoClientes
{
    public class Pessoa
    {
        public static int GerarId()
        {
            Pessoa.RefenciaId = Pessoa.RefenciaId + 1;
            return Pessoa.RefenciaId;
        }
        public static int RefenciaId = 0;

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string DataNascimento { get; set; }
        public string Cpf { get; set; }

    }

}
