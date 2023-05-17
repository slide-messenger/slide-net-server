namespace WinFormsClient
{
    partial class InputBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputBox));
            LabelTitle = new Label();
            TBResult = new TextBox();
            ButtonOK = new Button();
            SuspendLayout();
            // 
            // LabelTitle
            // 
            LabelTitle.AutoSize = true;
            LabelTitle.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            LabelTitle.Location = new Point(12, 9);
            LabelTitle.Name = "LabelTitle";
            LabelTitle.Size = new Size(129, 23);
            LabelTitle.TabIndex = 0;
            LabelTitle.Text = "Введите что-то";
            // 
            // TBResult
            // 
            TBResult.Location = new Point(16, 35);
            TBResult.Name = "TBResult";
            TBResult.Size = new Size(340, 30);
            TBResult.TabIndex = 1;
            // 
            // ButtonOK
            // 
            ButtonOK.Location = new Point(262, 71);
            ButtonOK.Name = "ButtonOK";
            ButtonOK.Size = new Size(94, 29);
            ButtonOK.TabIndex = 2;
            ButtonOK.Text = "OK";
            ButtonOK.UseVisualStyleBackColor = true;
            ButtonOK.Click += ButtonOK_Click;
            // 
            // InputBox
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(364, 108);
            Controls.Add(ButtonOK);
            Controls.Add(TBResult);
            Controls.Add(LabelTitle);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "InputBox";
            StartPosition = FormStartPosition.CenterParent;
            Text = "SlideMessenger";
            Load += InputBox_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelTitle;
        private TextBox TBResult;
        private Button ButtonOK;
    }
}