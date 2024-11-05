namespace P5_2_1194049
{
    partial class ChildForm
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
            OutputLabel = new Label();
            DisplayButton = new Button();
            ExitButton = new Button();
            OutputGroupBox = new GroupBox();
            TimeOption = new RadioButton();
            DateOption = new RadioButton();
            OutputGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // OutputLabel
            // 
            OutputLabel.BorderStyle = BorderStyle.Fixed3D;
            OutputLabel.Dock = DockStyle.Top;
            OutputLabel.Font = new Font("Trebuchet MS", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            OutputLabel.Location = new Point(0, 0);
            OutputLabel.Name = "OutputLabel";
            OutputLabel.Size = new Size(287, 32);
            OutputLabel.TabIndex = 0;
            OutputLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DisplayButton
            // 
            DisplayButton.Location = new Point(34, 88);
            DisplayButton.Name = "DisplayButton";
            DisplayButton.Size = new Size(80, 34);
            DisplayButton.TabIndex = 1;
            DisplayButton.Text = "&Display";
            DisplayButton.UseVisualStyleBackColor = true;
            DisplayButton.Click += DisplayButton_Click;
            // 
            // ExitButton
            // 
            ExitButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ExitButton.Location = new Point(177, 88);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(75, 31);
            ExitButton.TabIndex = 2;
            ExitButton.Text = "E&xit";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // OutputGroupBox
            // 
            OutputGroupBox.Controls.Add(TimeOption);
            OutputGroupBox.Controls.Add(DateOption);
            OutputGroupBox.Dock = DockStyle.Bottom;
            OutputGroupBox.Location = new Point(0, 159);
            OutputGroupBox.Name = "OutputGroupBox";
            OutputGroupBox.Size = new Size(287, 104);
            OutputGroupBox.TabIndex = 3;
            OutputGroupBox.TabStop = false;
            OutputGroupBox.Text = "Choose Output";
            // 
            // TimeOption
            // 
            TimeOption.Location = new Point(16, 53);
            TimeOption.Name = "TimeOption";
            TimeOption.Size = new Size(215, 24);
            TimeOption.TabIndex = 1;
            TimeOption.TabStop = true;
            TimeOption.Text = "Display Current &Time";
            TimeOption.UseVisualStyleBackColor = true;
            TimeOption.CheckedChanged += TimeOption_CheckedChanged;
            // 
            // DateOption
            // 
            DateOption.Location = new Point(16, 23);
            DateOption.Name = "DateOption";
            DateOption.Size = new Size(215, 24);
            DateOption.TabIndex = 0;
            DateOption.TabStop = true;
            DateOption.Text = "Display Current D&ate";
            DateOption.UseVisualStyleBackColor = true;
            DateOption.CheckedChanged += DateOption_CheckedChanged;
            // 
            // ChildForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(287, 263);
            Controls.Add(OutputGroupBox);
            Controls.Add(ExitButton);
            Controls.Add(DisplayButton);
            Controls.Add(OutputLabel);
            Name = "ChildForm";
            Text = "Child Form";
            OutputGroupBox.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label OutputLabel;
        private Button DisplayButton;
        private Button ExitButton;
        private GroupBox OutputGroupBox;
        private RadioButton DateOption;
        private RadioButton TimeOption;
    }
}