using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public bool Validacao()
        {
            return true;
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
            DialogResult = DialogResult.OK;
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
