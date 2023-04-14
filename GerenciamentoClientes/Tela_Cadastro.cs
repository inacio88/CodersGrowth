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
        public Tela_Cadastro()
        {
            InitializeComponent();
        }

        private void Lbl_Data_Nasc_Click(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // Tela_Cadastro
            // 
            ClientSize = new Size(398, 303);
            Name = "Tela_Cadastro";
            ResumeLayout(false);
        }
    }
}
