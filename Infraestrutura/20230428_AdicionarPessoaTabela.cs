using FluentMigrator;

namespace Infraestrutura
{
    [Migration(20230428100800)]
    public class AdicionarPessoaTabela : Migration
    {
        public override void Up()
        {
            Create.Table("Pessoa")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Nome").AsString(50)
                .WithColumn("Email").AsString(150)
                .WithColumn("DataNascimento").AsString(10)
                .WithColumn("CPF").AsString(15);
        }

        public override void Down()
        {
            Delete.Table("Pessoa");
        }
    }
}