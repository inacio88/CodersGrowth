using System.Configuration;
using Dominio;
using FluentMigrator.Runner;
using Infraestrutura;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GerenciamentoClientes
{
    internal static class Program
    {
        private static string StringDeConexao = ConfigurationManager.ConnectionStrings["invent018.bancoDeDadosCG.dbo"].ConnectionString;
 
        [STAThread]
        static void Main()
        {
            var builder = CriaHostBuilder();
            var servicesProvider = builder.Build().Services;
            var repositorio = servicesProvider.GetService<IRepositorioPessoa>();
            var validacao = servicesProvider.GetService<ValidacaoPessoa>();
            using (var serviceProvider = CreateServices())
            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new Tela_Inicial_Consulta(repositorio, validacao));
        }
        static IHostBuilder CriaHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddScoped<IRepositorioPessoa, RepositorioLinq2Db>();
                    services.AddScoped<ValidacaoPessoa, ValidacaoPessoa>();
                });
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