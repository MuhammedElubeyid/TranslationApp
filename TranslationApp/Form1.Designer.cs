namespace TranslationApp
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
            txtInput = new TextBox();
            txtOutput = new TextBox();
            btnTranslate = new Button();
            cmbLanguage = new ComboBox();
            SuspendLayout();
            // 
            // txtInput
            // 
            txtInput.Location = new Point(55, 41);
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(320, 84);
            txtInput.TabIndex = 0;
            txtInput.TextChanged += txtInput_TextChanged;
            // 
            // txtOutput
            // 
            txtOutput.Location = new Point(40, 192);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.Size = new Size(339, 79);
            txtOutput.TabIndex = 1;
            txtOutput.TextChanged += txtOutput_TextChanged;
            // 
            // btnTranslate
            // 
            btnTranslate.Location = new Point(508, 217);
            btnTranslate.Name = "btnTranslate";
            btnTranslate.Size = new Size(94, 29);
            btnTranslate.TabIndex = 2;
            btnTranslate.Text = "Translate";
            btnTranslate.UseVisualStyleBackColor = true;
            btnTranslate.Click += btnTranslate_Click;
            // 
            // cmbLanguage
            // 
            cmbLanguage.FormattingEnabled = true;
            cmbLanguage.Location = new Point(487, 62);
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.Size = new Size(151, 28);
            cmbLanguage.TabIndex = 3;
            cmbLanguage.SelectedIndexChanged += cmbLanguage_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbLanguage);
            Controls.Add(btnTranslate);
            Controls.Add(txtOutput);
            Controls.Add(txtInput);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtInput;
        private TextBox txtOutput;
        private Button btnTranslate;
        private ComboBox cmbLanguage;
    }
}
