using FluentMigrator;

namespace GerenciamentoClientes
{
    [Migration(20230428113300)]
    public class AlterarColunaPessoaTabela : Migration
    {
        public override void Down()
        {
            Alter.Column("DataNascimento")
                .OnTable("Pessoa")
                .AsString();
        }
        public override void Up()
        {
            Alter.Column("DataNascimento")
                .OnTable("Pessoa")
                .AsDateTime()
                .NotNullable();
        }
        
    }
}