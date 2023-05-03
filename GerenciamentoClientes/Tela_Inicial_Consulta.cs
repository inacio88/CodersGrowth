namespace GerenciamentoClientes
{

    public partial class Tela_Inicial_Consulta : Form
    {
        RepositorListaPessoa repositorPessoa = new RepositorListaPessoa();
        RepositorioSqlPessoa repositorioSql = new RepositorioSqlPessoa();
        public Tela_Inicial_Consulta()
        {
            InitializeComponent();
            dataGridViewListaPessoa.DataSource = null;
            dataGridViewListaPessoa.DataSource = repositorioSql.ObterTodasPessoas();

        }

        private void AoClicarEmNovo(object sender, EventArgs e)
        {
            try
            {
                
                var telaCadastro = new Tela_Cadastro(null);
                var resultado = telaCadastro.ShowDialog(null);
                if (resultado == DialogResult.OK)
                {
                    repositorioSql.CriarPessoa(telaCadastro.pessoa);
                }
                dataGridViewListaPessoa.DataSource = null;
                dataGridViewListaPessoa.DataSource = repositorioSql.ObterTodasPessoas();

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
                var listaDePessoas = repositorioSql.ObterTodasPessoas();

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
                    repositorioSql.AtualizarPessoa(tela_Cadastro.pessoa);
                    if (resultado == DialogResult.OK)
                    {
                        dataGridViewListaPessoa.DataSource = null;
                        dataGridViewListaPessoa.DataSource = repositorioSql.ObterTodasPessoas();
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
                var listaDePessoas = repositorioSql.ObterTodasPessoas();

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
                        repositorioSql.RemoverPessoa(clienteSelecionado.Id);
                        dataGridViewListaPessoa.DataSource = null;
                        dataGridViewListaPessoa.DataSource = repositorioSql.ObterTodasPessoas();
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
