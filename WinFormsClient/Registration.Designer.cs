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
            GBName = new GroupBox();
            ButtonNext = new Button();
            GBPassword = new GroupBox();
            ButtonPrev = new Button();
            GBName.SuspendLayout();
            GBPassword.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(7, 26);
            label1.Name = "label1";
            label1.Size = new Size(44, 23);
            label1.TabIndex = 0;
            label1.Text = "Имя";
            // 
            // TBFirstName
            // 
            TBFirstName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            TBFirstName.Location = new Point(7, 55);
            TBFirstName.MaxLength = 32;
            TBFirstName.Name = "TBFirstName";
            TBFirstName.Size = new Size(355, 30);
            TBFirstName.TabIndex = 1;
            // 
            // TBLastName
            // 
            TBLastName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            TBLastName.Location = new Point(7, 124);
            TBLastName.MaxLength = 32;
            TBLastName.Name = "TBLastName";
            TBLastName.Size = new Size(355, 30);
            TBLastName.TabIndex = 3;
            TBLastName.TextChanged += TBLastName_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(7, 94);
            label2.Name = "label2";
            label2.Size = new Size(81, 23);
            label2.TabIndex = 2;
            label2.Text = "Фамилия";
            // 
            // TBPassword
            // 
            TBPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TBPassword.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            TBPassword.Location = new Point(10, 56);
            TBPassword.MaxLength = 32;
            TBPassword.Name = "TBPassword";
            TBPassword.PasswordChar = '•';
            TBPassword.Size = new Size(305, 30);
            TBPassword.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(6, 26);
            label3.Name = "label3";
            label3.Size = new Size(255, 23);
            label3.TabIndex = 6;
            label3.Text = "Придумайте надёжный пароль";
            label3.Click += label3_Click;
            // 
            // TBUserName
            // 
            TBUserName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TBUserName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            TBUserName.Location = new Point(7, 192);
            TBUserName.MaxLength = 32;
            TBUserName.Name = "TBUserName";
            TBUserName.Size = new Size(355, 30);
            TBUserName.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(7, 162);
            label4.Name = "label4";
            label4.Size = new Size(255, 23);
            label4.TabIndex = 4;
            label4.Text = "Придумайте имя пользователя";
            // 
            // TBRepeatPassword
            // 
            TBRepeatPassword.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            TBRepeatPassword.Location = new Point(10, 124);
            TBRepeatPassword.MaxLength = 32;
            TBRepeatPassword.Name = "TBRepeatPassword";
            TBRepeatPassword.PasswordChar = '•';
            TBRepeatPassword.Size = new Size(305, 30);
            TBRepeatPassword.TabIndex = 11;
            TBRepeatPassword.TextChanged += TBRepeatPassword_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(10, 94);
            label5.Name = "label5";
            label5.Size = new Size(156, 23);
            label5.TabIndex = 10;
            label5.Text = "Повторите пароль";
            // 
            // ButtonRegister
            // 
            ButtonRegister.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonRegister.Location = new Point(80, 260);
            ButtonRegister.Name = "ButtonRegister";
            ButtonRegister.Size = new Size(289, 67);
            ButtonRegister.TabIndex = 12;
            ButtonRegister.Text = "Зарегистрироваться";
            ButtonRegister.UseVisualStyleBackColor = true;
            ButtonRegister.Click += ButtonRegister_Click;
            // 
            // LinkToAuth
            // 
            LinkToAuth.AutoSize = true;
            LinkToAuth.Location = new Point(251, 225);
            LinkToAuth.Name = "LinkToAuth";
            LinkToAuth.Size = new Size(113, 23);
            LinkToAuth.TabIndex = 13;
            LinkToAuth.TabStop = true;
            LinkToAuth.Text = "Авторизация";
            LinkToAuth.LinkClicked += LinkToAuth_LinkClicked;
            // 
            // ButtonShowPass
            // 
            ButtonShowPass.Image = (Image)resources.GetObject("ButtonShowPass.Image");
            ButtonShowPass.Location = new Point(321, 59);
            ButtonShowPass.Name = "ButtonShowPass";
            ButtonShowPass.Size = new Size(42, 27);
            ButtonShowPass.TabIndex = 14;
            ButtonShowPass.UseVisualStyleBackColor = true;
            ButtonShowPass.Click += ButtonShowPass_Click;
            // 
            // ButtonShowRepeatPass
            // 
            ButtonShowRepeatPass.Image = (Image)resources.GetObject("ButtonShowRepeatPass.Image");
            ButtonShowRepeatPass.Location = new Point(321, 125);
            ButtonShowRepeatPass.Name = "ButtonShowRepeatPass";
            ButtonShowRepeatPass.Size = new Size(42, 29);
            ButtonShowRepeatPass.TabIndex = 15;
            ButtonShowRepeatPass.UseVisualStyleBackColor = true;
            ButtonShowRepeatPass.Click += ButtonShowRepeatPass_Click;
            // 
            // GBName
            // 
            GBName.Controls.Add(ButtonNext);
            GBName.Controls.Add(label1);
            GBName.Controls.Add(TBFirstName);
            GBName.Controls.Add(label2);
            GBName.Controls.Add(LinkToAuth);
            GBName.Controls.Add(TBLastName);
            GBName.Controls.Add(label4);
            GBName.Controls.Add(TBUserName);
            GBName.Location = new Point(14, 14);
            GBName.Name = "GBName";
            GBName.Size = new Size(369, 338);
            GBName.TabIndex = 16;
            GBName.TabStop = false;
            GBName.Text = "1. Имя";
            // 
            // ButtonNext
            // 
            ButtonNext.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonNext.Location = new Point(5, 260);
            ButtonNext.Name = "ButtonNext";
            ButtonNext.Size = new Size(357, 68);
            ButtonNext.TabIndex = 14;
            ButtonNext.Text = "Далее >>";
            ButtonNext.UseVisualStyleBackColor = true;
            ButtonNext.Click += ButtonNext_Click;
            // 
            // GBPassword
            // 
            GBPassword.Controls.Add(ButtonPrev);
            GBPassword.Controls.Add(label3);
            GBPassword.Controls.Add(TBRepeatPassword);
            GBPassword.Controls.Add(ButtonRegister);
            GBPassword.Controls.Add(ButtonShowRepeatPass);
            GBPassword.Controls.Add(TBPassword);
            GBPassword.Controls.Add(ButtonShowPass);
            GBPassword.Controls.Add(label5);
            GBPassword.Location = new Point(390, 15);
            GBPassword.Name = "GBPassword";
            GBPassword.Size = new Size(369, 337);
            GBPassword.TabIndex = 17;
            GBPassword.TabStop = false;
            GBPassword.Text = "2. Пароль";
            GBPassword.Visible = false;
            // 
            // ButtonPrev
            // 
            ButtonPrev.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonPrev.Location = new Point(6, 260);
            ButtonPrev.Name = "ButtonPrev";
            ButtonPrev.Size = new Size(66, 67);
            ButtonPrev.TabIndex = 16;
            ButtonPrev.Text = "<<";
            ButtonPrev.UseVisualStyleBackColor = true;
            ButtonPrev.Click += ButtonPrev_Click;
            // 
            // Registration
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1182, 673);
            Controls.Add(GBPassword);
            Controls.Add(GBName);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Registration";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SlideMessenger";
            Load += Registration_Load;
            GBName.ResumeLayout(false);
            GBName.PerformLayout();
            GBPassword.ResumeLayout(false);
            GBPassword.PerformLayout();
            ResumeLayout(false);
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
        private GroupBox GBName;
        private Button ButtonNext;
        private GroupBox GBPassword;
        private Button ButtonPrev;
    }
}