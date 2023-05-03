namespace GerenciamentoClientes
{
    partial class Tela_Inicial_Consulta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Btn_Novo = new Button();
            dataGridViewListaPessoa = new DataGridView();
            Btn_Editar = new Button();
            Btn_Excluir = new Button();
            Lbl_Titulo = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewListaPessoa).BeginInit();
            SuspendLayout();
            // 
            // Btn_Novo
            // 
            Btn_Novo.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_Novo.Location = new Point(48, 432);
            Btn_Novo.Name = "Btn_Novo";
            Btn_Novo.Size = new Size(90, 42);
            Btn_Novo.TabIndex = 0;
            Btn_Novo.Text = "Novo";
            Btn_Novo.UseVisualStyleBackColor = true;
            Btn_Novo.Click += AoClicarEmNovo;
            // 
            // dataGridViewListaPessoa
            // 
            dataGridViewListaPessoa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewListaPessoa.Location = new Point(21, 68);
            dataGridViewListaPessoa.Name = "dataGridViewListaPessoa";
            dataGridViewListaPessoa.RowTemplate.Height = 25;
            dataGridViewListaPessoa.Size = new Size(690, 342);
            dataGridViewListaPessoa.TabIndex = 1;
            // 
            // Btn_Editar
            // 
            Btn_Editar.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_Editar.Location = new Point(233, 432);
            Btn_Editar.Name = "Btn_Editar";
            Btn_Editar.Size = new Size(90, 42);
            Btn_Editar.TabIndex = 2;
            Btn_Editar.Text = "Editar";
            Btn_Editar.UseVisualStyleBackColor = true;
            Btn_Editar.Click += AoClicarEmEditar;
            // 
            // Btn_Excluir
            // 
            Btn_Excluir.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_Excluir.Location = new Point(417, 432);
            Btn_Excluir.Name = "Btn_Excluir";
            Btn_Excluir.Size = new Size(90, 42);
            Btn_Excluir.TabIndex = 3;
            Btn_Excluir.Text = "Excluir";
            Btn_Excluir.UseVisualStyleBackColor = true;
            Btn_Excluir.Click += AoClicarEmExcluir;
            // 
            // Lbl_Titulo
            // 
            Lbl_Titulo.AutoSize = true;
            Lbl_Titulo.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            Lbl_Titulo.Location = new Point(282, 23);
            Lbl_Titulo.Name = "Lbl_Titulo";
            Lbl_Titulo.Size = new Size(150, 25);
            Lbl_Titulo.TabIndex = 4;
            Lbl_Titulo.Text = "Lista de Clientes";
            // 
            // Tela_Inicial_Consulta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(723, 519);
            Controls.Add(Lbl_Titulo);
            Controls.Add(Btn_Excluir);
            Controls.Add(Btn_Editar);
            Controls.Add(dataGridViewListaPessoa);
            Controls.Add(Btn_Novo);
            Name = "Tela_Inicial_Consulta";
            Text = "Tela_Inicial_Nova";
            ((System.ComponentModel.ISupportInitialize)dataGridViewListaPessoa).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Btn_Novo;
        private DataGridView dataGridViewListaPessoa;
        private Button Btn_Editar;
        private Button Btn_Excluir;
        private Label Lbl_Titulo;
    }
}