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
        public Tela_Cadastro()
        {
            InitializeComponent();
            if (pessoa == null)
            {
                pessoa = new Pessoa();
            }
        }


        private void AoClicarEmSalvar(object sender, EventArgs e)
        {
            pessoa.Id = Pessoa.GerarId();
            pessoa.Nome = Txt_Nome.Text;
            pessoa.Email = Txt_Email.Text;
            pessoa.Cpf = Txt_Cpf.Text;
            pessoa.DataNascimento = Txt_DataNasc.Text;
            DialogResult = DialogResult.OK;
        }

        private void AoClicarEmCancelar(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
