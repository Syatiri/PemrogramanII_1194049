namespace P5_1_1194049
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
            OutputLabel = new Label();
            HelloButton = new Button();
            ExitButton = new Button();
            SuspendLayout();
            // 
            // OutputLabel
            // 
            OutputLabel.BorderStyle = BorderStyle.Fixed3D;
            OutputLabel.Font = new Font("Trebuchet MS", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            OutputLabel.Location = new Point(5, 20);
            OutputLabel.Name = "OutputLabel";
            OutputLabel.Size = new Size(264, 23);
            OutputLabel.TabIndex = 0;
            OutputLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // HelloButton
            // 
            HelloButton.Location = new Point(57, 87);
            HelloButton.Name = "HelloButton";
            HelloButton.Size = new Size(75, 35);
            HelloButton.TabIndex = 1;
            HelloButton.Text = "&Say Hello";
            HelloButton.UseVisualStyleBackColor = true;
            HelloButton.Click += HelloButton_Click;
            // 
            // ExitButton
            // 
            ExitButton.Location = new Point(161, 87);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(75, 35);
            ExitButton.TabIndex = 2;
            ExitButton.Text = "E&xit";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(278, 144);
            Controls.Add(ExitButton);
            Controls.Add(HelloButton);
            Controls.Add(OutputLabel);
            Name = "Form1";
            Text = "Form Hello";
            ResumeLayout(false);
        }

        #endregion

        private Label OutputLabel;
        private Button HelloButton;
        private Button ExitButton;
    }
}
