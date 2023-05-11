using System;
using LinqToDB.Mapping;

namespace Dominio
{
    [Table("Pessoa")]
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

        [PrimaryKey, Identity]
        public int Id { get; set; }

        [Column("Nome"), NotNull]
        public string Nome { get; set; }

        [Column("Email"), NotNull]
        public string Email { get; set; }

        [Column("DataNascimento"), NotNull]
        public DateTime DataNascimento { get; set; }

        [Column("CPF"), NotNull]
        public string Cpf { get; set; }

    }

}
