using System;
using System.Configuration;
using System.Linq;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciamentoClientes
{
    internal static class Program
    {
        private static string StringDeConexao = ConfigurationManager.ConnectionStrings["invent018.bancoDeDadosCG.dbo"].ConnectionString;
 
        [STAThread]
        static void Main()
        {
            using (var serviceProvider = CreateServices())
            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new Tela_Inicial_Consulta());
        }
        private static ServiceProvider CreateServices()
        {
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(StringDeConexao)
                    .ScanIn(typeof(AlterarColunaPessoaTabela).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }

    }
}