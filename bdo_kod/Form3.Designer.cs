namespace bdo_kod
{
    partial class Form3
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
            txtKullanici = new TextBox();
            txtSifre = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnGiris = new Button();
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // txtKullanici
            // 
            txtKullanici.Location = new Point(37, 74);
            txtKullanici.Name = "txtKullanici";
            txtKullanici.Size = new Size(125, 27);
            txtKullanici.TabIndex = 0;
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(37, 160);
            txtSifre.Name = "txtSifre";
            txtSifre.PasswordChar = '*';
            txtSifre.Size = new Size(125, 27);
            txtSifre.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 40);
            label1.Name = "label1";
            label1.Size = new Size(95, 20);
            label1.TabIndex = 2;
            label1.Text = "Kullanıcı Adı:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 127);
            label2.Name = "label2";
            label2.Size = new Size(42, 20);
            label2.TabIndex = 3;
            label2.Text = "Şifre:";
            // 
            // btnGiris
            // 
            btnGiris.BackColor = SystemColors.ActiveCaption;
            btnGiris.Location = new Point(96, 224);
            btnGiris.Name = "btnGiris";
            btnGiris.Size = new Size(94, 29);
            btnGiris.TabIndex = 4;
            btnGiris.Text = "Giriş Yap";
            btnGiris.UseVisualStyleBackColor = false;
            btnGiris.Click += btnGiris_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(572, 40);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(270, 324);
            listBox1.TabIndex = 5;
            listBox1.Visible = false;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.Location = new Point(284, 40);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(273, 324);
            listBox2.TabIndex = 6;
            listBox2.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(572, 17);
            label3.Name = "label3";
            label3.Size = new Size(163, 20);
            label3.TabIndex = 7;
            label3.Text = "Tedarik edilecek ilaçlar:";
            label3.Visible = false;
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(284, 17);
            label4.Name = "label4";
            label4.Size = new Size(167, 20);
            label4.TabIndex = 8;
            label4.Text = "Tedarik Bekleyen İlaçlar:";
            label4.Visible = false;
            label4.Click += label4_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(374, 370);
            button1.Name = "button1";
            button1.Size = new Size(103, 34);
            button1.TabIndex = 9;
            button1.Text = "Onayla";
            button1.UseVisualStyleBackColor = false;
            button1.Visible = false;
            button1.Click += button1_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(854, 450);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Controls.Add(btnGiris);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtSifre);
            Controls.Add(txtKullanici);
            Name = "Form3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Yetkili Giriş";
            Load += Form3_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtKullanici;
        private TextBox txtSifre;
        private Label label1;
        private Label label2;
        private Button btnGiris;
        private ListBox listBox1;
        private ListBox listBox2;
        private Label label3;
        private Label label4;
        private Button button1;
    }
}