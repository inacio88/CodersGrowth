using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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
                Txt_DataNasc.Text = pessoa.DataNascimento; 
        }
        public void MensagemValidacao(string message)
        {
            //string message = "Certifique-se que: \n *Nome não fique em branco \n *Email válido \n * CPF igual a 11 \n * Data de nascimento válida";
            string title = "Campos Inválidos!";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result = MessageBox.Show(message, title, buttons);

        }

        public bool ValidacaoCampoGeral()
        {
            var tamanhoNome = Txt_Nome.Text.Length;
            var tamanhoCpf = Txt_Cpf.Text.Length;
            
            if (tamanhoNome < 1)
            {
                MensagemValidacao("* Nome não pode ficar em branco!");
                return false;
            }
            else if (ValidacaoEmail())
            {
                MensagemValidacao("* Email inválido!");
                return false;
            }
            else if (ValidacaoDataNascimento())
            {
                MensagemValidacao("* Data de nascimento inválida!");
                return false;
            }
            else if (ValidacaoCpf())
            {
                MensagemValidacao("* CPF inválido!");
                return false;
            }
            else
            {
                return true;            
            }
        }

        public bool ValidacaoCpf()
        {
            return false;
        }

        public bool ValidacaoEmail()
        {
            bool emailOk = Regex.IsMatch(Txt_Email.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            
            return !emailOk;
        }

        public bool ValidacaoDataNascimento()
        {
            
            try
            {
                DateTime dataNascimento = Convert.ToDateTime(Txt_DataNasc.Text);
                var diferencaAnos = DateTime.Now.Year - dataNascimento.Year;
                //var dife
                if (diferencaAnos > 120)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return true;
            }

        }

        private void AoClicarEmSalvar(object sender, EventArgs e)
        {
            if (pessoa.Id == Decimal.Zero)
            {
                pessoa.Id = Pessoa.GerarId();
            }
            
            pessoa.Nome = Txt_Nome.Text;
            pessoa.Email = Txt_Email.Text;
            pessoa.Cpf = Txt_Cpf.Text;
            pessoa.DataNascimento = Txt_DataNasc.Text;

            if (ValidacaoCampoGeral())
            {
                pessoa.Nome = Txt_Nome.Text;
                pessoa.Email = Txt_Email.Text;
                pessoa.Cpf = Txt_Cpf.Text;
                pessoa.DataNascimento = Txt_DataNasc.Text;

                DialogResult = DialogResult.OK;
            }
        }

        private void AoClicarEmCancelar(object sender, EventArgs e)
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
    }
}
