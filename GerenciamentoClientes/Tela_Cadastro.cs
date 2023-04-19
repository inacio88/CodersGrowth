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
            if (tamanhoNome < 1 || ValidacaoEmail() || tamanhoCpf < 14 || tamanhoDataNascimento < 10)
            {
                string message = "Certifique-se que: \n *Nome seja maior que 2 \n *Email maior que 4 \n * CPF igual a 11 \n * Data de nascimento completa";
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
