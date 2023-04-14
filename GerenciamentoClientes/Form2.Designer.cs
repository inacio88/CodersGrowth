namespace GerenciamentoClientes
{
    partial class Form2
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
            textBox1 = new TextBox();
            Txt_msg = new TextBox();
            Btn_reset = new Button();
            Lbl_Minus = new Label();
            Lbl_maiusculo = new Label();
            Lbl_Upper = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(8, 8);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 0;
            // 
            // Txt_msg
            // 
            Txt_msg.Location = new Point(8, 40);
            Txt_msg.Multiline = true;
            Txt_msg.Name = "Txt_msg";
            Txt_msg.ScrollBars = ScrollBars.Vertical;
            Txt_msg.Size = new Size(304, 232);
            Txt_msg.TabIndex = 1;
            Txt_msg.TabStop = false;
            // 
            // Btn_reset
            // 
            Btn_reset.Location = new Point(328, 8);
            Btn_reset.Name = "Btn_reset";
            Btn_reset.Size = new Size(75, 28);
            Btn_reset.TabIndex = 2;
            Btn_reset.Text = "limpa";
            Btn_reset.UseVisualStyleBackColor = true;
            // 
            // Lbl_Minus
            // 
            Lbl_Minus.AutoSize = true;
            Lbl_Minus.Location = new Point(320, 104);
            Lbl_Minus.Name = "Lbl_Minus";
            Lbl_Minus.Size = new Size(43, 15);
            Lbl_Minus.TabIndex = 3;
            Lbl_Minus.Text = "Minus.";
            // 
            // Lbl_maiusculo
            // 
            Lbl_maiusculo.AutoSize = true;
            Lbl_maiusculo.Location = new Point(320, 56);
            Lbl_maiusculo.Name = "Lbl_maiusculo";
            Lbl_maiusculo.Size = new Size(39, 15);
            Lbl_maiusculo.TabIndex = 4;
            Lbl_maiusculo.Text = "Maius";
            // 
            // Lbl_Upper
            // 
            Lbl_Upper.AutoSize = true;
            Lbl_Upper.BorderStyle = BorderStyle.Fixed3D;
            Lbl_Upper.Location = new Point(419, 178);
            Lbl_Upper.Name = "Lbl_Upper";
            Lbl_Upper.Size = new Size(40, 17);
            Lbl_Upper.TabIndex = 5;
            Lbl_Upper.Text = "label1";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 334);
            Controls.Add(Lbl_Upper);
            Controls.Add(Lbl_maiusculo);
            Controls.Add(Lbl_Minus);
            Controls.Add(Btn_reset);
            Controls.Add(Txt_msg);
            Controls.Add(textBox1);
            Name = "Form2";
            Text = "Demostracao evento key";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox Txt_msg;
        private Button Btn_reset;
        private Label Lbl_Minus;
        private Label Lbl_maiusculo;
        private Label Lbl_Upper;
    }
}