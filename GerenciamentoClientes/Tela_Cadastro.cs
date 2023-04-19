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

        public bool ValidacaoCampoGeral()
        {
            var tamanhoNome = Txt_Nome.Text.Length;
            var tamanhoEmail = Txt_Email.Text.Length;
            var tamanhoCpf = Txt_Cpf.Text.Length;
            var tamanhoDataNascimento = Txt_DataNasc.Text.Length;
            if (tamanhoNome < 1 || ValidacaoEmail() || tamanhoCpf < 14 || ValidacaoDataNascimento())
            {
                string message = "Certifique-se que: \n *Nome não fique em branco \n *Email válido \n * CPF igual a 11 \n * Data de nascimento válida";
                string title = "Campos Inválidos!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons);
                
                return false;
            }
            else
            {
                return true;            
            }
        }

        public bool ValidacaoEmail()
        {
            bool emailOk = Regex.IsMatch(Txt_Email.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            
            return !emailOk;
        }

        public bool ValidacaoDataNascimento()
        {
            const int TamanhoDataSemMascara = 8;
            var dia = 0;
            var mes = 0;
            var ano = 0;

            string dataSemMascara = Txt_DataNasc.Text.Replace("/","");
            bool dataSemMascaraOk = Regex.IsMatch(dataSemMascara, "^[0-9]+$");

            if (dataSemMascaraOk && dataSemMascara.Length == TamanhoDataSemMascara)
            {
                dia = Convert.ToInt32(Txt_DataNasc.Text.Substring(0, 2));
                mes = Convert.ToInt32(Txt_DataNasc.Text.Substring(3, 2));
                ano = Convert.ToInt32(Txt_DataNasc.Text.Substring(6, 4));
            }
            else
            {
                return true;
            }

            if (dia > 31 || mes > 12 || ano > DateTime.Now.Year)
            {
                return true;
            }

            DateTime dataNascimento = Convert.ToDateTime(Txt_DataNasc.Text);
            var difencaAnos = DateTime.Now.Year - dataNascimento.Year;

            if (difencaAnos > 120)
            {
                return true;
            }
            else
            {
                return false;
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
