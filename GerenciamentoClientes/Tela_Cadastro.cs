using System.Text.RegularExpressions;
using Dominio;

namespace GerenciamentoClientes
{
    public partial class Tela_Cadastro : Form
    {

        public Pessoa pessoa { get; set; }
        public Tela_Cadastro(Pessoa pessoaSelecionada)
        {
            InitializeComponent();
            if (pessoaSelecionada == null)
            {
                pessoa = new Pessoa();
            }
            else
            {
                PreencherCampos(pessoaSelecionada);
                pessoa = pessoaSelecionada;
            }
        }
        public void PreencherCampos(Pessoa pessoa)
        {
            Txt_Nome.Text = pessoa.Nome;
            Txt_Email.Text = pessoa.Email;
            Txt_Cpf.Text = pessoa.Cpf;
            Txt_DataNasc.Text = pessoa.DataNascimento.ToString();
        }
        public void MensagemValidacao(string message)
        {
            string title = "Campos Inválidos!";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result = MessageBox.Show(message, title, buttons);
        }

        public bool ValidacaoCampoGeral()
        {

            if (ValidarNome())
            {
                MensagemValidacao("* Nome inválido!");
                return false;
            }
            if (ValidacaoEmail())
            {
                MensagemValidacao("* Email inválido!");
                return false;
            }
            if (ValidacaoCpf())
            {
                MensagemValidacao("* CPF inválido!");
                return false;
            }
            if (ValidacaoDataNascimento())
            {
                MensagemValidacao("* Data de nascimento inválida!");
                return false;
            }

            return true;
        }

        public bool ValidarNome()
        {
            bool nomeOk = Regex.IsMatch(Txt_Nome.Text, @"^[a-zA-ZÀ-ÖØ-öø-ÿ ]+$");
            if (Txt_Nome.Text == "" || !nomeOk)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidacaoCpf()
        {
            const int tamanhoCpfSemMascara = 11;
            string cpfSemMascara = Txt_Cpf.Text.Replace(".", "").Replace("-", "").Replace(" ", "");
            bool cpfSemMascaraOk = Regex.IsMatch(cpfSemMascara, "^[0-9]+$");

            if (cpfSemMascara.Length != tamanhoCpfSemMascara || !cpfSemMascaraOk)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool ValidacaoEmail()
        {
            bool emailOk = Regex.IsMatch(Txt_Email.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return !emailOk;
        }

        public bool ValidacaoDataNascimento()
        {
            const int IdadeMaximaEmAnos = 120;
            const int IdadeMinimaEmDias = 1;
            try
            {
                DateTime dataNascimento = Convert.ToDateTime(Txt_DataNasc.Text);
                var diferencaAnos = DateTime.Now.Year - dataNascimento.Year;
                var diferencaDias = DateTime.Now - dataNascimento;
                if (diferencaAnos > IdadeMaximaEmAnos || diferencaDias.Days < IdadeMinimaEmDias)
                {
                    MensagemValidacao("A idade deve ser entre 1 e 120 anos");
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                MensagemValidacao(e.Message);
            }
            return false;

        }

        private void AoClicarEmSalvar(object sender, EventArgs e)
        {

            try
            {
                if (pessoa.Id == Decimal.Zero)
                {
                    pessoa.Id = Pessoa.GerarId();
                }


                if (ValidacaoCampoGeral())
                {
                    pessoa.Nome = Txt_Nome.Text;
                    pessoa.Email = Txt_Email.Text;
                    pessoa.Cpf = Txt_Cpf.Text;
                    pessoa.DataNascimento = DateTime.Parse(Txt_DataNasc.Text);

                    DialogResult = DialogResult.OK;
                }
            }
            catch
            {
                throw new Exception("Entrar em contato com o adm do sistema");
            }


        }

        private void AoClicarEmCancelar(object sender, EventArgs e)
        {
            try
            {
                string message = "Se fechar os dados preenchidos serão pedidos. Tem certeza?";
                string title = "Tem certeza?";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    DialogResult = DialogResult.Cancel;
                }


            }
            catch (Exception)
            {

                throw new Exception("Entrar em contato com o adm do sistema");
            }

        }
    }
}
