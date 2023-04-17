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
    public partial class Tela_Cad : Form
    {
        public Pessoa pessoa { get; set; }
        public Tela_Cad()
        {
            InitializeComponent();
            if (pessoa == null)
            {
                pessoa = new Pessoa();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Btn_Salvar_Click(object sender, EventArgs e)
        {
            pessoa.Id = Pessoa.GerarId();
            pessoa.Nome = Txt_Nome.Text;
            pessoa.Email = Txt_Email.Text;
            pessoa.Cpf = Txt_Cpf.Text;
            pessoa.DataNascimento = Txt_DataNasc.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
