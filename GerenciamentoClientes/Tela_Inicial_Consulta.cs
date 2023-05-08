using Dominio;
using Infraestrutura;

namespace GerenciamentoClientes
{

    public partial class Tela_Inicial_Consulta : Form
    {
        private readonly IRepositorioPessoa _repositorioPessoa;
        public Tela_Inicial_Consulta(IRepositorioPessoa repositorioPessoa)
        {
            InitializeComponent();
            _repositorioPessoa = repositorioPessoa;
            dataGridViewListaPessoa.DataSource = null;
            dataGridViewListaPessoa.DataSource = repositorioPessoa.ObterTodasPessoas();

        }

        private void AoClicarEmNovo(object sender, EventArgs e)
        {
            try
            {
                
                var telaCadastro = new Tela_Cadastro(null);
                var resultado = telaCadastro.ShowDialog(null);
                if (resultado == DialogResult.OK)
                {
                    _repositorioPessoa.CriarPessoa(telaCadastro.pessoa);
                }
                dataGridViewListaPessoa.DataSource = null;
                dataGridViewListaPessoa.DataSource = _repositorioPessoa.ObterTodasPessoas();

            }
            catch
            {
                throw new Exception("Erro inesperado, entrar em contato com o adm do sistema");
            }

        }

        private void AoClicarEmEditar(object sender, EventArgs e)
        {
            try
            {
                var listaDePessoas = _repositorioPessoa.ObterTodasPessoas();

                if (listaDePessoas.Count == decimal.Zero)
                {
                    MessageBox.Show("Não há nada selecionado", "Vazio", MessageBoxButtons.OK);
                }
                else
                {
                    var indexSelecionado = dataGridViewListaPessoa.CurrentCell.RowIndex;
                    var clienteSelecionado = dataGridViewListaPessoa.Rows[indexSelecionado].DataBoundItem as Pessoa;
                    var tela_Cadastro = new Tela_Cadastro(clienteSelecionado);
                    var resultado = tela_Cadastro.ShowDialog();
                    _repositorioPessoa.AtualizarPessoa(tela_Cadastro.pessoa);
                    if (resultado == DialogResult.OK)
                    {
                        dataGridViewListaPessoa.DataSource = null;
                        dataGridViewListaPessoa.DataSource = _repositorioPessoa.ObterTodasPessoas();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Erro inesperado, entrar em contato com o adm do sistema", "Erro", MessageBoxButtons.OK);
            }
        }

        private void AoClicarEmExcluir(object sender, EventArgs e)
        {
            try
            {
                var listaDePessoas = _repositorioPessoa.ObterTodasPessoas();

                if (listaDePessoas.Count == decimal.Zero)
                {
                    MessageBox.Show("Não há nada selecionado", "Vazio", MessageBoxButtons.OK);
                }
                else
                {
                    var indexSelecionado = dataGridViewListaPessoa.CurrentCell.RowIndex;
                    var clienteSelecionado = dataGridViewListaPessoa.Rows[indexSelecionado].DataBoundItem as Pessoa;
                    DialogResult result = MessageBox.Show("Deseja excluir selecionado?", "Excluir", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        _repositorioPessoa.RemoverPessoa(clienteSelecionado.Id);
                        dataGridViewListaPessoa.DataSource = null;
                        dataGridViewListaPessoa.DataSource = _repositorioPessoa.ObterTodasPessoas();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Erro inesperado, entrar em contato com o adm do sistema", "Erro", MessageBoxButtons.OK);
            }
        }
    }
}
