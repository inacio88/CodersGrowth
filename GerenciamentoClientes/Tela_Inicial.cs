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
    public partial class Tela_Inicial : Form
    {
        public Tela_Inicial()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            Lbl_Titulo = new Label();
            ((ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 59);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(696, 341);
            dataGridView1.TabIndex = 0;
            // 
            // Lbl_Titulo
            // 
            Lbl_Titulo.AutoSize = true;
            Lbl_Titulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            Lbl_Titulo.Location = new Point(303, 22);
            Lbl_Titulo.Name = "Lbl_Titulo";
            Lbl_Titulo.Size = new Size(153, 25);
            Lbl_Titulo.TabIndex = 1;
            Lbl_Titulo.Text = "Lista de Clientes";
            Lbl_Titulo.Click += label1_Click;
            // 
            // Tela_Inicial
            // 
            ClientSize = new Size(736, 524);
            Controls.Add(Lbl_Titulo);
            Controls.Add(dataGridView1);
            Name = "Tela_Inicial";
            Text = "Tela Inicial";
            ((ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private DataGridView dataGridView1;
        private Label Lbl_Titulo;
    }
}
