namespace WinFormsClient
{
    partial class Auth
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Auth));
            LabelLogin = new Label();
            TBLogin = new TextBox();
            TBPassword = new TextBox();
            PasswordTB = new Label();
            ButtonLogin = new Button();
            ButtonRegister = new Button();
            ButtonShowPass = new Button();
            SuspendLayout();
            // 
            // LabelLogin
            // 
            LabelLogin.AutoSize = true;
            LabelLogin.Location = new Point(12, 21);
            LabelLogin.Name = "LabelLogin";
            LabelLogin.Size = new Size(52, 20);
            LabelLogin.TabIndex = 0;
            LabelLogin.Text = "Логин";
            // 
            // TBLogin
            // 
            TBLogin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TBLogin.Location = new Point(12, 44);
            TBLogin.MaxLength = 20;
            TBLogin.Name = "TBLogin";
            TBLogin.Size = new Size(330, 27);
            TBLogin.TabIndex = 1;
            // 
            // TBPassword
            // 
            TBPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TBPassword.Location = new Point(12, 101);
            TBPassword.MaxLength = 20;
            TBPassword.Name = "TBPassword";
            TBPassword.PasswordChar = '*';
            TBPassword.Size = new Size(294, 27);
            TBPassword.TabIndex = 3;
            // 
            // PasswordTB
            // 
            PasswordTB.AutoSize = true;
            PasswordTB.Location = new Point(12, 78);
            PasswordTB.Name = "PasswordTB";
            PasswordTB.Size = new Size(62, 20);
            PasswordTB.TabIndex = 2;
            PasswordTB.Text = "Пароль";
            // 
            // ButtonLogin
            // 
            ButtonLogin.Location = new Point(9, 147);
            ButtonLogin.Name = "ButtonLogin";
            ButtonLogin.Size = new Size(170, 54);
            ButtonLogin.TabIndex = 4;
            ButtonLogin.Text = "Войти";
            ButtonLogin.UseVisualStyleBackColor = true;
            ButtonLogin.Click += ButtonLogin_Click;
            // 
            // ButtonRegister
            // 
            ButtonRegister.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonRegister.Location = new Point(185, 147);
            ButtonRegister.Name = "ButtonRegister";
            ButtonRegister.Size = new Size(157, 54);
            ButtonRegister.TabIndex = 5;
            ButtonRegister.Text = "Регистрация";
            ButtonRegister.UseVisualStyleBackColor = true;
            ButtonRegister.Click += ButtonRegister_Click;
            // 
            // ButtonShowPass
            // 
            ButtonShowPass.Image = (Image)resources.GetObject("ButtonShowPass.Image");
            ButtonShowPass.Location = new Point(312, 101);
            ButtonShowPass.Name = "ButtonShowPass";
            ButtonShowPass.Size = new Size(30, 27);
            ButtonShowPass.TabIndex = 6;
            ButtonShowPass.UseVisualStyleBackColor = true;
            ButtonShowPass.Click += ButtonShowPass_Click;
            // 
            // Auth
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(354, 213);
            Controls.Add(ButtonShowPass);
            Controls.Add(ButtonRegister);
            Controls.Add(ButtonLogin);
            Controls.Add(TBPassword);
            Controls.Add(PasswordTB);
            Controls.Add(TBLogin);
            Controls.Add(LabelLogin);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Auth";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Авторизация";
            TopMost = true;
            FormClosed += Auth_FormClosed;
            Load += Auth_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelLogin;
        private TextBox TBLogin;
        private TextBox TBPassword;
        private Label PasswordTB;
        private Button ButtonLogin;
        private Button ButtonRegister;
        private Button ButtonShowPass;
    }
}