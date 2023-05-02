namespace GerenciamentoClientes
{

    public partial class Tela_Inicial_Consulta : Form
    {
        RepositorPessoa repositorPessoa = new RepositorPessoa();
        RepositorioSqlPessoa repositorioSql = new RepositorioSqlPessoa();
        public Tela_Inicial_Consulta()
        {
            InitializeComponent();

        }

        private void AoClicarEmNovo(object sender, EventArgs e)
        {
            try
            {
                repositorioSql.ObterTodasPessoas();
                var telaCadastro = new Tela_Cadastro(null);
                var resultado = telaCadastro.ShowDialog(null);
                if (resultado == DialogResult.OK)
                {
                    repositorPessoa.CriarPessoa(telaCadastro.pessoa);
                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = repositorPessoa.ObterTodasPessoas();

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
                var listaDePessoas = repositorPessoa.ObterTodasPessoas();

                if (listaDePessoas.Count == decimal.Zero)
                {
                    MessageBox.Show("Não há nada selecionado", "Vazio", MessageBoxButtons.OK);
                }
                else
                {
                    var indexSelecionado = dataGridView1.CurrentCell.RowIndex;
                    var clienteSelecionado = dataGridView1.Rows[indexSelecionado].DataBoundItem as Pessoa;
                    repositorPessoa.AtualizarPessoa(clienteSelecionado);
                    var tela_Cadastro = new Tela_Cadastro(clienteSelecionado);
                    var resultado = tela_Cadastro.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = listaDePessoas;
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
                var listaDePessoas = repositorPessoa.ObterTodasPessoas();

                if (listaDePessoas.Count == decimal.Zero)
                {
                    MessageBox.Show("Não há nada selecionado", "Vazio", MessageBoxButtons.OK);
                }
                else
                {
                    var indexSelecionado = dataGridView1.CurrentCell.RowIndex;
                    var clienteSelecionado = dataGridView1.Rows[indexSelecionado].DataBoundItem as Pessoa;
                    DialogResult result = MessageBox.Show("Deseja excluir selecionado?", "Excluir", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        repositorPessoa.RemoverPessoa(clienteSelecionado.Id);
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = listaDePessoas;
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
