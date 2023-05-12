using Dominio;
using Infraestrutura;

namespace GerenciamentoClientes
{

    public partial class Tela_Inicial_Consulta : Form
    {
        public IRepositorioPessoa _repositorioPessoa;
        private readonly ValidacaoPessoa _validacao;
        public Tela_Inicial_Consulta(IRepositorioPessoa repositorioPessoa, ValidacaoPessoa validacao)
        {
            _repositorioPessoa = repositorioPessoa;
            _validacao = validacao;
            InitializeComponent();
            AtualizaLista();
        }

        public void AtualizaLista()
        {
            dataGridViewListaPessoa.DataSource = null;
            dataGridViewListaPessoa.DataSource = _repositorioPessoa.ObterTodasPessoas();
        }

        private void AoClicarEmNovo(object sender, EventArgs e)
        {
            try
            {
                
                var telaCadastro = new Tela_Cadastro(null);
                var resultado = telaCadastro.ShowDialog(null);
                var resultadoValidacao = _validacao.Validate(telaCadastro.pessoa);
                if (resultado == DialogResult.OK && resultadoValidacao.IsValid)
                {
                    _repositorioPessoa.CriarPessoa(telaCadastro.pessoa);
                }
                if (!resultadoValidacao.IsValid)
                {
                    MessageBox.Show(resultadoValidacao.ToString(), "Erro", MessageBoxButtons.OK);
                }
                AtualizaLista();
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
                    var resultadoValidacao = _validacao.Validate(tela_Cadastro.pessoa);
                    if (resultado == DialogResult.OK && resultadoValidacao.IsValid)
                    {
                        _repositorioPessoa.AtualizarPessoa(tela_Cadastro.pessoa);
                        MessageBox.Show("Salvo com sucesso!", "Sucesso", MessageBoxButtons.OK);
                    }
                    if (!resultadoValidacao.IsValid)
                    {
                        MessageBox.Show(resultadoValidacao.ToString(), "Erro", MessageBoxButtons.OK);
                    }
                    AtualizaLista();
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
                        AtualizaLista();
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
