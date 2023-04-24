namespace GerenciamentoClientes
{
    partial class Tela_Cadastro
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
            Lbl_Nome = new Label();
            Txt_Nome = new TextBox();
            Lbl_Email = new Label();
            Txt_Email = new TextBox();
            Lbl_Cpf = new Label();
            Lbl_Data_Nasc = new Label();
            Btn_Salvar = new Button();
            Txt_DataNasc = new MaskedTextBox();
            Txt_Cpf = new MaskedTextBox();
            Btn_Cancelar = new Button();
            SuspendLayout();
            // 
            // Lbl_Nome
            // 
            Lbl_Nome.AutoSize = true;
            Lbl_Nome.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            Lbl_Nome.Location = new Point(21, 18);
            Lbl_Nome.Name = "Lbl_Nome";
            Lbl_Nome.Size = new Size(72, 30);
            Lbl_Nome.TabIndex = 0;
            Lbl_Nome.Text = "Nome";
            // 
            // Txt_Nome
            // 
            Txt_Nome.Location = new Point(21, 61);
            Txt_Nome.Name = "Txt_Nome";
            Txt_Nome.Size = new Size(255, 23);
            Txt_Nome.TabIndex = 1;
            // 
            // Lbl_Email
            // 
            Lbl_Email.AutoSize = true;
            Lbl_Email.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            Lbl_Email.Location = new Point(21, 112);
            Lbl_Email.Name = "Lbl_Email";
            Lbl_Email.Size = new Size(64, 30);
            Lbl_Email.TabIndex = 2;
            Lbl_Email.Text = "Email";
            // 
            // Txt_Email
            // 
            Txt_Email.Location = new Point(21, 164);
            Txt_Email.Name = "Txt_Email";
            Txt_Email.Size = new Size(255, 23);
            Txt_Email.TabIndex = 3;
            // 
            // Lbl_Cpf
            // 
            Lbl_Cpf.AutoSize = true;
            Lbl_Cpf.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            Lbl_Cpf.Location = new Point(29, 233);
            Lbl_Cpf.Name = "Lbl_Cpf";
            Lbl_Cpf.Size = new Size(49, 30);
            Lbl_Cpf.TabIndex = 4;
            Lbl_Cpf.Text = "CPF";
            // 
            // Lbl_Data_Nasc
            // 
            Lbl_Data_Nasc.AutoSize = true;
            Lbl_Data_Nasc.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            Lbl_Data_Nasc.Location = new Point(29, 343);
            Lbl_Data_Nasc.Name = "Lbl_Data_Nasc";
            Lbl_Data_Nasc.Size = new Size(178, 30);
            Lbl_Data_Nasc.TabIndex = 6;
            Lbl_Data_Nasc.Text = "Data Nascimento";
            // 
            // Btn_Salvar
            // 
            Btn_Salvar.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_Salvar.Location = new Point(309, 482);
            Btn_Salvar.Name = "Btn_Salvar";
            Btn_Salvar.Size = new Size(83, 35);
            Btn_Salvar.TabIndex = 8;
            Btn_Salvar.Text = "Salvar";
            Btn_Salvar.UseVisualStyleBackColor = true;
            Btn_Salvar.Click += AoClicarEmSalvar;
            // 
            // Txt_DataNasc
            // 
            Txt_DataNasc.Location = new Point(29, 415);
            Txt_DataNasc.Mask = "00/00/0000";
            Txt_DataNasc.Name = "Txt_DataNasc";
            Txt_DataNasc.Size = new Size(100, 23);
            Txt_DataNasc.TabIndex = 7;
            Txt_DataNasc.ValidatingType = typeof(DateTime);
            // 
            // Txt_Cpf
            // 
            Txt_Cpf.Location = new Point(29, 286);
            Txt_Cpf.Mask = "000,000,000-00";
            Txt_Cpf.Name = "Txt_Cpf";
            Txt_Cpf.Size = new Size(178, 23);
            Txt_Cpf.TabIndex = 5;
            // 
            // Btn_Cancelar
            // 
            Btn_Cancelar.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_Cancelar.Location = new Point(33, 482);
            Btn_Cancelar.Name = "Btn_Cancelar";
            Btn_Cancelar.Size = new Size(96, 33);
            Btn_Cancelar.TabIndex = 11;
            Btn_Cancelar.Text = "Cancelar";
            Btn_Cancelar.UseVisualStyleBackColor = true;
            Btn_Cancelar.Click += AoClicarEmCancelar;
            // 
            // Tela_Cadastro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 529);
            Controls.Add(Btn_Cancelar);
            Controls.Add(Txt_Cpf);
            Controls.Add(Txt_DataNasc);
            Controls.Add(Btn_Salvar);
            Controls.Add(Lbl_Data_Nasc);
            Controls.Add(Lbl_Cpf);
            Controls.Add(Txt_Email);
            Controls.Add(Lbl_Email);
            Controls.Add(Txt_Nome);
            Controls.Add(Lbl_Nome);
            Name = "Tela_Cadastro";
            Text = "Cadastro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Lbl_Nome;
        private TextBox Txt_Nome;
        private Label Lbl_Email;
        private TextBox Txt_Email;
        private Label Lbl_Cpf;
        private Label Lbl_Data_Nasc;
        private Button Btn_Salvar;
        private MaskedTextBox Txt_DataNasc;
        private MaskedTextBox Txt_Cpf;
        private Button Btn_Cancelar;
    }
}