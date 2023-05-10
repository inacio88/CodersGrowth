using System;

namespace Dominio
{
    public class Pessoa
    {
        const int InicialReferenciaID = 0;
        const int IncrementoID = 1;
        public static int RefenciaId = InicialReferenciaID;
        public static int GerarId()
        {
            Pessoa.RefenciaId = Pessoa.RefenciaId + IncrementoID;
            return Pessoa.RefenciaId;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }

    }

}
