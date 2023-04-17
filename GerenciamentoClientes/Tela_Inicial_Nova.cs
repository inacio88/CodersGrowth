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

    public partial class Tela_Inicial_Nova : Form
    {
        List<Pessoa> pessoas = new List<Pessoa>();
        public Tela_Inicial_Nova()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            var tela_cad = new Tela_Cadastro();
            var resultado = tela_cad.ShowDialog(null);
                if (resultado == DialogResult.OK)
                {
                    pessoas.Add(tela_cad.pessoa);
                }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = pessoas;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Tela_Inicial_Nova_Load(object sender, EventArgs e)
        {

        }
    }
}
