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
            TBPassword = new TextBox();
            label2 = new Label();
            TBLogin = new TextBox();
            label1 = new Label();
            ButtonLogin = new Button();
            LinkToRegistration = new LinkLabel();
            ButtonShowPass = new Button();
            GBAuth = new GroupBox();
            GBAuth.SuspendLayout();
            SuspendLayout();
            // 
            // TBPassword
            // 
            TBPassword.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            TBPassword.Location = new Point(7, 126);
            TBPassword.MaxLength = 32;
            TBPassword.Name = "TBPassword";
            TBPassword.PasswordChar = '•';
            TBPassword.Size = new Size(302, 30);
            TBPassword.TabIndex = 7;
            TBPassword.Text = "testtest";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(7, 97);
            label2.Name = "label2";
            label2.Size = new Size(69, 23);
            label2.TabIndex = 6;
            label2.Text = "Пароль";
            // 
            // TBLogin
            // 
            TBLogin.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            TBLogin.Location = new Point(7, 59);
            TBLogin.MaxLength = 32;
            TBLogin.Name = "TBLogin";
            TBLogin.Size = new Size(356, 30);
            TBLogin.TabIndex = 5;
            TBLogin.Text = "ivanstasevich";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(7, 30);
            label1.Name = "label1";
            label1.Size = new Size(58, 23);
            label1.TabIndex = 4;
            label1.Text = "Логин";
            label1.Click += label1_Click;
            // 
            // ButtonLogin
            // 
            ButtonLogin.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonLogin.Location = new Point(7, 194);
            ButtonLogin.Name = "ButtonLogin";
            ButtonLogin.Size = new Size(357, 70);
            ButtonLogin.TabIndex = 8;
            ButtonLogin.Text = "Войти";
            ButtonLogin.UseVisualStyleBackColor = true;
            ButtonLogin.Click += ButtonLogin_Click;
            // 
            // LinkToRegistration
            // 
            LinkToRegistration.AutoSize = true;
            LinkToRegistration.Location = new Point(254, 159);
            LinkToRegistration.Name = "LinkToRegistration";
            LinkToRegistration.Size = new Size(109, 23);
            LinkToRegistration.TabIndex = 9;
            LinkToRegistration.TabStop = true;
            LinkToRegistration.Text = "Регистрация";
            LinkToRegistration.LinkClicked += LinkToRegistration_LinkClicked;
            // 
            // ButtonShowPass
            // 
            ButtonShowPass.Image = (Image)resources.GetObject("ButtonShowPass.Image");
            ButtonShowPass.Location = new Point(315, 126);
            ButtonShowPass.Name = "ButtonShowPass";
            ButtonShowPass.Size = new Size(48, 30);
            ButtonShowPass.TabIndex = 10;
            ButtonShowPass.UseVisualStyleBackColor = true;
            ButtonShowPass.Click += ButtonShowPass_Click;
            // 
            // GBAuth
            // 
            GBAuth.Controls.Add(label1);
            GBAuth.Controls.Add(ButtonLogin);
            GBAuth.Controls.Add(ButtonShowPass);
            GBAuth.Controls.Add(TBLogin);
            GBAuth.Controls.Add(LinkToRegistration);
            GBAuth.Controls.Add(label2);
            GBAuth.Controls.Add(TBPassword);
            GBAuth.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            GBAuth.Location = new Point(14, 14);
            GBAuth.Name = "GBAuth";
            GBAuth.Size = new Size(369, 270);
            GBAuth.TabIndex = 11;
            GBAuth.TabStop = false;
            GBAuth.Text = "Авторизация";
            // 
            // Auth
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1182, 673);
            Controls.Add(GBAuth);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Auth";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SlideMessenger";
            FormClosed += Auth_FormClosed;
            Load += Auth_Load;
            GBAuth.ResumeLayout(false);
            GBAuth.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox TBPassword;
        private Label label2;
        private TextBox TBLogin;
        private Label label1;
        private Button ButtonLogin;
        private LinkLabel LinkToRegistration;
        private Button ButtonShowPass;
        private GroupBox GBAuth;
    }
}