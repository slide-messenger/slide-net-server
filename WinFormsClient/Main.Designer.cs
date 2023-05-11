namespace WinFormsClient
{
    partial class Main
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            SendButton = new Button();
            RTBMessages = new RichTextBox();
            RTBTypeMessage = new RichTextBox();
            UpdateTimer = new System.Windows.Forms.Timer(components);
            LBChats = new ListBox();
            LabelChatname = new Label();
            groupBox1 = new GroupBox();
            ButtonCreateChat = new Button();
            ButtonJoinChat = new Button();
            groupBox2 = new GroupBox();
            LinkQuit = new LinkLabel();
            ButtonProfileInfo = new Button();
            LabelLastName = new Label();
            LabelFirstName = new Label();
            groupBox3 = new GroupBox();
            ButtonGetLink = new Button();
            groupBox4 = new GroupBox();
            ButtonCopyMyLink = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // SendButton
            // 
            SendButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SendButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            SendButton.Image = (Image)resources.GetObject("SendButton.Image");
            SendButton.Location = new Point(762, 15);
            SendButton.Name = "SendButton";
            SendButton.Size = new Size(56, 65);
            SendButton.TabIndex = 0;
            SendButton.UseVisualStyleBackColor = true;
            SendButton.Click += SendButton_Click;
            // 
            // RTBMessages
            // 
            RTBMessages.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            RTBMessages.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            RTBMessages.Location = new Point(6, 51);
            RTBMessages.Name = "RTBMessages";
            RTBMessages.Size = new Size(812, 453);
            RTBMessages.TabIndex = 3;
            RTBMessages.Text = "";
            // 
            // RTBTypeMessage
            // 
            RTBTypeMessage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            RTBTypeMessage.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            RTBTypeMessage.Location = new Point(6, 15);
            RTBTypeMessage.MaxLength = 4096;
            RTBTypeMessage.Name = "RTBTypeMessage";
            RTBTypeMessage.Size = new Size(750, 65);
            RTBTypeMessage.TabIndex = 4;
            RTBTypeMessage.Text = "Написать сообщение...";
            RTBTypeMessage.Click += MessageRTB_Click;
            RTBTypeMessage.KeyDown += MessageRTB_KeyDown;
            // 
            // UpdateTimer
            // 
            UpdateTimer.Interval = 1000;
            UpdateTimer.Tick += UpdateTimer_Tick;
            // 
            // LBChats
            // 
            LBChats.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            LBChats.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            LBChats.FormattingEnabled = true;
            LBChats.IntegralHeight = false;
            LBChats.ItemHeight = 23;
            LBChats.Items.AddRange(new object[] { "Человек 1 (0)", "Человек 2 (0)", "Группа 1 (0)" });
            LBChats.Location = new Point(6, 29);
            LBChats.Name = "LBChats";
            LBChats.Size = new Size(216, 402);
            LBChats.TabIndex = 7;
            LBChats.SelectedIndexChanged += LBChats_SelectedIndexChanged;
            // 
            // LabelChatname
            // 
            LabelChatname.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            LabelChatname.BackColor = SystemColors.Window;
            LabelChatname.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            LabelChatname.Location = new Point(0, 14);
            LabelChatname.Name = "LabelChatname";
            LabelChatname.Size = new Size(772, 34);
            LabelChatname.TabIndex = 14;
            LabelChatname.Text = "Выберите чат";
            LabelChatname.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox1.Controls.Add(ButtonCreateChat);
            groupBox1.Controls.Add(ButtonJoinChat);
            groupBox1.Controls.Add(LBChats);
            groupBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(12, 117);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(228, 484);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Чаты";
            // 
            // ButtonCreateChat
            // 
            ButtonCreateChat.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonCreateChat.Image = (Image)resources.GetObject("ButtonCreateChat.Image");
            ButtonCreateChat.Location = new Point(6, 437);
            ButtonCreateChat.Name = "ButtonCreateChat";
            ButtonCreateChat.Size = new Size(152, 41);
            ButtonCreateChat.TabIndex = 15;
            ButtonCreateChat.UseVisualStyleBackColor = true;
            ButtonCreateChat.Click += ButtonCreateChat_Click;
            // 
            // ButtonJoinChat
            // 
            ButtonJoinChat.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonJoinChat.Image = (Image)resources.GetObject("ButtonJoinChat.Image");
            ButtonJoinChat.Location = new Point(164, 437);
            ButtonJoinChat.Name = "ButtonJoinChat";
            ButtonJoinChat.Size = new Size(58, 41);
            ButtonJoinChat.TabIndex = 14;
            ButtonJoinChat.UseVisualStyleBackColor = true;
            ButtonJoinChat.Click += ButtonJoinChat_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(ButtonCopyMyLink);
            groupBox2.Controls.Add(LinkQuit);
            groupBox2.Controls.Add(ButtonProfileInfo);
            groupBox2.Controls.Add(LabelLastName);
            groupBox2.Controls.Add(LabelFirstName);
            groupBox2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox2.Location = new Point(12, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(228, 99);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Мой профиль";
            // 
            // LinkQuit
            // 
            LinkQuit.AutoSize = true;
            LinkQuit.Location = new Point(6, 66);
            LinkQuit.Name = "LinkQuit";
            LinkQuit.Size = new Size(59, 23);
            LinkQuit.TabIndex = 13;
            LinkQuit.TabStop = true;
            LinkQuit.Text = "Выход";
            LinkQuit.LinkClicked += LinkQuit_LinkClicked;
            // 
            // ButtonProfileInfo
            // 
            ButtonProfileInfo.Image = (Image)resources.GetObject("ButtonProfileInfo.Image");
            ButtonProfileInfo.Location = new Point(182, 22);
            ButtonProfileInfo.Name = "ButtonProfileInfo";
            ButtonProfileInfo.Size = new Size(40, 34);
            ButtonProfileInfo.TabIndex = 12;
            ButtonProfileInfo.UseVisualStyleBackColor = true;
            ButtonProfileInfo.Click += ButtonProfileInfo_Click;
            // 
            // LabelLastName
            // 
            LabelLastName.AutoSize = true;
            LabelLastName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            LabelLastName.Location = new Point(6, 43);
            LabelLastName.Name = "LabelLastName";
            LabelLastName.Size = new Size(81, 23);
            LabelLastName.TabIndex = 11;
            LabelLastName.Text = "Фамилия";
            // 
            // LabelFirstName
            // 
            LabelFirstName.AutoSize = true;
            LabelFirstName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            LabelFirstName.Location = new Point(6, 25);
            LabelFirstName.Name = "LabelFirstName";
            LabelFirstName.Size = new Size(44, 23);
            LabelFirstName.TabIndex = 10;
            LabelFirstName.Text = "Имя";
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(ButtonGetLink);
            groupBox3.Controls.Add(RTBMessages);
            groupBox3.Controls.Add(LabelChatname);
            groupBox3.Location = new Point(246, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(824, 512);
            groupBox3.TabIndex = 17;
            groupBox3.TabStop = false;
            // 
            // ButtonGetLink
            // 
            ButtonGetLink.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonGetLink.Image = (Image)resources.GetObject("ButtonGetLink.Image");
            ButtonGetLink.Location = new Point(778, 15);
            ButtonGetLink.Name = "ButtonGetLink";
            ButtonGetLink.Size = new Size(40, 34);
            ButtonGetLink.TabIndex = 15;
            ButtonGetLink.UseVisualStyleBackColor = true;
            ButtonGetLink.Click += ButtonGetLink_Click;
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox4.Controls.Add(SendButton);
            groupBox4.Controls.Add(RTBTypeMessage);
            groupBox4.Location = new Point(246, 515);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(824, 86);
            groupBox4.TabIndex = 18;
            groupBox4.TabStop = false;
            // 
            // ButtonCopyMyLink
            // 
            ButtonCopyMyLink.Image = (Image)resources.GetObject("ButtonCopyMyLink.Image");
            ButtonCopyMyLink.Location = new Point(182, 61);
            ButtonCopyMyLink.Name = "ButtonCopyMyLink";
            ButtonCopyMyLink.Size = new Size(40, 34);
            ButtonCopyMyLink.TabIndex = 14;
            ButtonCopyMyLink.UseVisualStyleBackColor = true;
            ButtonCopyMyLink.Click += ButtonCopyMyLink_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1081, 613);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SlideMessenger";
            Load += Main_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button SendButton;
        private RichTextBox RTBMessages;
        private RichTextBox RTBTypeMessage;
        private System.Windows.Forms.Timer UpdateTimer;
        private ListBox LBChats;
        private Label LabelChatname;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button ButtonProfileInfo;
        private Label LabelLastName;
        private Label LabelFirstName;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private LinkLabel LinkQuit;
        private Button ButtonCreateChat;
        private Button ButtonJoinChat;
        private Button ButtonGetLink;
        private Button ButtonCopyMyLink;
    }
}