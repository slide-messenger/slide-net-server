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
            SuspendLayout();
            // 
            // TBPassword
            // 
            TBPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TBPassword.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            TBPassword.Location = new Point(12, 90);
            TBPassword.MaxLength = 32;
            TBPassword.Name = "TBPassword";
            TBPassword.PasswordChar = '•';
            TBPassword.Size = new Size(234, 30);
            TBPassword.TabIndex = 7;
            TBPassword.Text = "testtest";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 64);
            label2.Name = "label2";
            label2.Size = new Size(69, 23);
            label2.TabIndex = 6;
            label2.Text = "Пароль";
            // 
            // TBLogin
            // 
            TBLogin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TBLogin.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            TBLogin.Location = new Point(12, 31);
            TBLogin.MaxLength = 32;
            TBLogin.Name = "TBLogin";
            TBLogin.Size = new Size(280, 30);
            TBLogin.TabIndex = 5;
            TBLogin.Text = "issstasevich";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 8);
            label1.Name = "label1";
            label1.Size = new Size(58, 23);
            label1.TabIndex = 4;
            label1.Text = "Логин";
            // 
            // ButtonLogin
            // 
            ButtonLogin.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonLogin.Location = new Point(12, 150);
            ButtonLogin.Name = "ButtonLogin";
            ButtonLogin.Size = new Size(280, 61);
            ButtonLogin.TabIndex = 8;
            ButtonLogin.Text = "Войти";
            ButtonLogin.UseVisualStyleBackColor = true;
            ButtonLogin.Click += ButtonLogin_Click;
            // 
            // LinkToRegistration
            // 
            LinkToRegistration.AutoSize = true;
            LinkToRegistration.Location = new Point(196, 123);
            LinkToRegistration.Name = "LinkToRegistration";
            LinkToRegistration.Size = new Size(96, 20);
            LinkToRegistration.TabIndex = 9;
            LinkToRegistration.TabStop = true;
            LinkToRegistration.Text = "Регистрация";
            LinkToRegistration.LinkClicked += LinkToRegistration_LinkClicked;
            // 
            // ButtonShowPass
            // 
            ButtonShowPass.Image = (Image)resources.GetObject("ButtonShowPass.Image");
            ButtonShowPass.Location = new Point(252, 90);
            ButtonShowPass.Name = "ButtonShowPass";
            ButtonShowPass.Size = new Size(40, 30);
            ButtonShowPass.TabIndex = 10;
            ButtonShowPass.UseVisualStyleBackColor = true;
            ButtonShowPass.Click += ButtonShowPass_Click;
            // 
            // Auth
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(304, 219);
            Controls.Add(ButtonShowPass);
            Controls.Add(LinkToRegistration);
            Controls.Add(ButtonLogin);
            Controls.Add(TBPassword);
            Controls.Add(label2);
            Controls.Add(TBLogin);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Auth";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SlideMessenger";
            TopMost = true;
            FormClosed += Auth_FormClosed;
            Load += Auth_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TBPassword;
        private Label label2;
        private TextBox TBLogin;
        private Label label1;
        private Button ButtonLogin;
        private LinkLabel LinkToRegistration;
        private Button ButtonShowPass;
    }
}