namespace P5_3_1194049
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtMerkHP = new TextBox();
            rb_android = new RadioButton();
            rb_ios = new RadioButton();
            cb_Ya = new CheckBox();
            btnTampilkan = new Button();
            btnKeluar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Trebuchet MS", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 31);
            label1.Name = "label1";
            label1.Size = new Size(91, 26);
            label1.TabIndex = 0;
            label1.Text = "Merk HP";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Trebuchet MS", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 76);
            label2.Name = "label2";
            label2.Size = new Size(36, 26);
            label2.TabIndex = 1;
            label2.Text = "OS";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Trebuchet MS", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 119);
            label3.Name = "label3";
            label3.Size = new Size(182, 26);
            label3.TabIndex = 2;
            label3.Text = "Sudah Diperbaiki?";
            // 
            // txtMerkHP
            // 
            txtMerkHP.Font = new Font("Trebuchet MS", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtMerkHP.Location = new Point(206, 26);
            txtMerkHP.Name = "txtMerkHP";
            txtMerkHP.Size = new Size(226, 31);
            txtMerkHP.TabIndex = 3;
            // 
            // rb_android
            // 
            rb_android.AutoSize = true;
            rb_android.Location = new Point(206, 73);
            rb_android.Name = "rb_android";
            rb_android.Size = new Size(102, 29);
            rb_android.TabIndex = 4;
            rb_android.TabStop = true;
            rb_android.Text = "Android";
            rb_android.UseVisualStyleBackColor = true;
            // 
            // rb_ios
            // 
            rb_ios.AutoSize = true;
            rb_ios.Location = new Point(327, 74);
            rb_ios.Name = "rb_ios";
            rb_ios.Size = new Size(65, 29);
            rb_ios.TabIndex = 5;
            rb_ios.TabStop = true;
            rb_ios.Text = "iOS";
            rb_ios.UseVisualStyleBackColor = true;
            // 
            // cb_Ya
            // 
            cb_Ya.AutoSize = true;
            cb_Ya.Location = new Point(206, 118);
            cb_Ya.Name = "cb_Ya";
            cb_Ya.Size = new Size(55, 29);
            cb_Ya.TabIndex = 6;
            cb_Ya.Text = "Ya";
            cb_Ya.UseVisualStyleBackColor = true;
            // 
            // btnTampilkan
            // 
            btnTampilkan.Location = new Point(82, 184);
            btnTampilkan.Name = "btnTampilkan";
            btnTampilkan.Size = new Size(112, 34);
            btnTampilkan.TabIndex = 7;
            btnTampilkan.Text = "Tampilkan";
            btnTampilkan.UseVisualStyleBackColor = true;
            btnTampilkan.Click += btnTampilkan_Click;
            // 
            // btnKeluar
            // 
            btnKeluar.Location = new Point(280, 184);
            btnKeluar.Name = "btnKeluar";
            btnKeluar.Size = new Size(112, 34);
            btnKeluar.TabIndex = 8;
            btnKeluar.Text = "Keluar";
            btnKeluar.UseVisualStyleBackColor = true;
            btnKeluar.Click += btnKeluar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(444, 259);
            Controls.Add(btnKeluar);
            Controls.Add(btnTampilkan);
            Controls.Add(cb_Ya);
            Controls.Add(rb_ios);
            Controls.Add(rb_android);
            Controls.Add(txtMerkHP);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Service HP";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtMerkHP;
        private RadioButton rb_android;
        private RadioButton rb_ios;
        private CheckBox cb_Ya;
        private Button btnTampilkan;
        private Button btnKeluar;
    }
}
