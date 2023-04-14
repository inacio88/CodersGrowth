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
            Btn_Novo = new Button();
            Btn_Editar = new Button();
            Btn_Excluir = new Button();
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
            // Btn_Novo
            // 
            Btn_Novo.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_Novo.Location = new Point(71, 452);
            Btn_Novo.Name = "Btn_Novo";
            Btn_Novo.Size = new Size(80, 39);
            Btn_Novo.TabIndex = 2;
            Btn_Novo.Text = "Novo";
            Btn_Novo.UseVisualStyleBackColor = true;
            Btn_Novo.Click += Btn_Novo_Click;
            // 
            // Btn_Editar
            // 
            Btn_Editar.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_Editar.Location = new Point(253, 452);
            Btn_Editar.Name = "Btn_Editar";
            Btn_Editar.Size = new Size(80, 39);
            Btn_Editar.TabIndex = 3;
            Btn_Editar.Text = "Editar";
            Btn_Editar.UseVisualStyleBackColor = true;
            // 
            // Btn_Excluir
            // 
            Btn_Excluir.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_Excluir.Location = new Point(429, 452);
            Btn_Excluir.Name = "Btn_Excluir";
            Btn_Excluir.Size = new Size(80, 39);
            Btn_Excluir.TabIndex = 4;
            Btn_Excluir.Text = "Excluir";
            Btn_Excluir.UseVisualStyleBackColor = true;
            // 
            // Tela_Inicial
            // 
            ClientSize = new Size(736, 524);
            Controls.Add(Btn_Excluir);
            Controls.Add(Btn_Editar);
            Controls.Add(Btn_Novo);
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

        private void Btn_Novo_Click(object sender, EventArgs e)
        {

        }

        private DataGridView dataGridView1;
        private Button Btn_Novo;
        private Button Btn_Editar;
        private Button Btn_Excluir;
        private Label Lbl_Titulo;
    }
}
