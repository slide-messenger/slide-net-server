namespace WinFormsClient
{
    partial class Registration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registration));
            label1 = new Label();
            TBFirstName = new TextBox();
            TBLastName = new TextBox();
            label2 = new Label();
            TBPassword = new TextBox();
            label3 = new Label();
            TBUserName = new TextBox();
            label4 = new Label();
            TBRepeatPassword = new TextBox();
            label5 = new Label();
            ButtonRegister = new Button();
            LinkToAuth = new LinkLabel();
            ButtonShowPass = new Button();
            ButtonShowRepeatPass = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(44, 23);
            label1.TabIndex = 0;
            label1.Text = "Имя";
            // 
            // TBFirstName
            // 
            TBFirstName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TBFirstName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            TBFirstName.Location = new Point(12, 35);
            TBFirstName.MaxLength = 32;
            TBFirstName.Name = "TBFirstName";
            TBFirstName.Size = new Size(298, 30);
            TBFirstName.TabIndex = 1;
            // 
            // TBLastName
            // 
            TBLastName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TBLastName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            TBLastName.Location = new Point(12, 94);
            TBLastName.MaxLength = 32;
            TBLastName.Name = "TBLastName";
            TBLastName.Size = new Size(298, 30);
            TBLastName.TabIndex = 3;
            TBLastName.TextChanged += TBLastName_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 68);
            label2.Name = "label2";
            label2.Size = new Size(81, 23);
            label2.TabIndex = 2;
            label2.Text = "Фамилия";
            // 
            // TBPassword
            // 
            TBPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TBPassword.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            TBPassword.Location = new Point(12, 208);
            TBPassword.MaxLength = 32;
            TBPassword.Name = "TBPassword";
            TBPassword.PasswordChar = '•';
            TBPassword.Size = new Size(266, 30);
            TBPassword.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 183);
            label3.Name = "label3";
            label3.Size = new Size(255, 23);
            label3.TabIndex = 6;
            label3.Text = "Придумайте надёжный пароль";
            // 
            // TBUserName
            // 
            TBUserName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TBUserName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            TBUserName.Location = new Point(12, 150);
            TBUserName.MaxLength = 32;
            TBUserName.Name = "TBUserName";
            TBUserName.Size = new Size(298, 30);
            TBUserName.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(12, 127);
            label4.Name = "label4";
            label4.Size = new Size(255, 23);
            label4.TabIndex = 4;
            label4.Text = "Придумайте имя пользователя";
            // 
            // TBRepeatPassword
            // 
            TBRepeatPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TBRepeatPassword.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            TBRepeatPassword.Location = new Point(12, 264);
            TBRepeatPassword.MaxLength = 32;
            TBRepeatPassword.Name = "TBRepeatPassword";
            TBRepeatPassword.PasswordChar = '•';
            TBRepeatPassword.Size = new Size(266, 30);
            TBRepeatPassword.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(12, 241);
            label5.Name = "label5";
            label5.Size = new Size(156, 23);
            label5.TabIndex = 10;
            label5.Text = "Повторите пароль";
            // 
            // ButtonRegister
            // 
            ButtonRegister.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonRegister.Location = new Point(12, 320);
            ButtonRegister.Name = "ButtonRegister";
            ButtonRegister.Size = new Size(298, 58);
            ButtonRegister.TabIndex = 12;
            ButtonRegister.Text = "Зарегистрироваться";
            ButtonRegister.UseVisualStyleBackColor = true;
            ButtonRegister.Click += ButtonRegister_Click;
            // 
            // LinkToAuth
            // 
            LinkToAuth.AutoSize = true;
            LinkToAuth.Location = new Point(209, 297);
            LinkToAuth.Name = "LinkToAuth";
            LinkToAuth.Size = new Size(101, 20);
            LinkToAuth.TabIndex = 13;
            LinkToAuth.TabStop = true;
            LinkToAuth.Text = "Авторизация";
            LinkToAuth.LinkClicked += LinkToAuth_LinkClicked;
            // 
            // ButtonShowPass
            // 
            ButtonShowPass.Image = (Image)resources.GetObject("ButtonShowPass.Image");
            ButtonShowPass.Location = new Point(284, 207);
            ButtonShowPass.Name = "ButtonShowPass";
            ButtonShowPass.Size = new Size(26, 29);
            ButtonShowPass.TabIndex = 14;
            ButtonShowPass.UseVisualStyleBackColor = true;
            ButtonShowPass.Click += ButtonShowPass_Click;
            // 
            // ButtonShowRepeatPass
            // 
            ButtonShowRepeatPass.Image = (Image)resources.GetObject("ButtonShowRepeatPass.Image");
            ButtonShowRepeatPass.Location = new Point(284, 264);
            ButtonShowRepeatPass.Name = "ButtonShowRepeatPass";
            ButtonShowRepeatPass.Size = new Size(26, 29);
            ButtonShowRepeatPass.TabIndex = 15;
            ButtonShowRepeatPass.UseVisualStyleBackColor = true;
            ButtonShowRepeatPass.Click += ButtonShowRepeatPass_Click;
            // 
            // Registration
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(322, 388);
            Controls.Add(ButtonShowRepeatPass);
            Controls.Add(ButtonShowPass);
            Controls.Add(LinkToAuth);
            Controls.Add(ButtonRegister);
            Controls.Add(TBRepeatPassword);
            Controls.Add(label5);
            Controls.Add(TBPassword);
            Controls.Add(label3);
            Controls.Add(TBUserName);
            Controls.Add(label4);
            Controls.Add(TBLastName);
            Controls.Add(label2);
            Controls.Add(TBFirstName);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Registration";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SlideMessenger";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox TBFirstName;
        private TextBox TBLastName;
        private Label label2;
        private TextBox TBPassword;
        private Label label3;
        private TextBox TBUserName;
        private Label label4;
        private TextBox TBRepeatPassword;
        private Label label5;
        private Button ButtonRegister;
        private LinkLabel LinkToAuth;
        private Button ButtonShowPass;
        private Button ButtonShowRepeatPass;
    }
}