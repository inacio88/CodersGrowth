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

    public partial class Tela_Inicial_Consulta : Form
    {
        List<Pessoa> pessoas = new List<Pessoa>();
        public Tela_Inicial_Consulta()
        {
            InitializeComponent();

        }

        private void AoClicarEmNovo(object sender, EventArgs e)
        {
            try
            {
                var tela_cad = new Tela_Cadastro(null);
                var resultado = tela_cad.ShowDialog(null);
                if (resultado == DialogResult.OK)
                {
                    pessoas.Add(tela_cad.pessoa);
                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = pessoas;

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
                var indexSelecionado = dataGridView1.CurrentCell.RowIndex;
                var clienteSelecionado = dataGridView1.Rows[indexSelecionado].DataBoundItem as Pessoa;
                var tela_Cadastro = new Tela_Cadastro(clienteSelecionado);
                var resultado = tela_Cadastro.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = pessoas;
                }
            }
            catch
            {
                throw new Exception("Erro inesperado, entrar em contato com o adm do sistema");
            }
        }
    }
}
