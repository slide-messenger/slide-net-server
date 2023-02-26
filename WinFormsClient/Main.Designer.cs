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
            MessagesRTB = new RichTextBox();
            MessageRTB = new RichTextBox();
            UpdateTimer = new System.Windows.Forms.Timer(components);
            LBUsers = new ListBox();
            LabelContacts = new Label();
            SuspendLayout();
            // 
            // SendButton
            // 
            SendButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SendButton.Location = new Point(847, 464);
            SendButton.Name = "SendButton";
            SendButton.Size = new Size(141, 53);
            SendButton.TabIndex = 0;
            SendButton.Text = "Отправить";
            SendButton.UseVisualStyleBackColor = true;
            SendButton.Click += SendButton_Click;
            // 
            // MessagesRTB
            // 
            MessagesRTB.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MessagesRTB.Location = new Point(200, 12);
            MessagesRTB.Name = "MessagesRTB";
            MessagesRTB.Size = new Size(789, 447);
            MessagesRTB.TabIndex = 3;
            MessagesRTB.Text = "";
            // 
            // MessageRTB
            // 
            MessageRTB.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MessageRTB.Location = new Point(12, 463);
            MessageRTB.Name = "MessageRTB";
            MessageRTB.Size = new Size(832, 52);
            MessageRTB.TabIndex = 4;
            MessageRTB.Text = "";
            MessageRTB.KeyDown += MessageRTB_KeyDown;
            // 
            // UpdateTimer
            // 
            UpdateTimer.Interval = 1000;
            UpdateTimer.Tick += UpdateTimer_Tick;
            // 
            // LBUsers
            // 
            LBUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            LBUsers.FormattingEnabled = true;
            LBUsers.ItemHeight = 20;
            LBUsers.Items.AddRange(new object[] { "<Global chat>" });
            LBUsers.Location = new Point(12, 32);
            LBUsers.Name = "LBUsers";
            LBUsers.Size = new Size(182, 424);
            LBUsers.TabIndex = 5;
            // 
            // LabelContacts
            // 
            LabelContacts.AutoSize = true;
            LabelContacts.Location = new Point(12, 9);
            LabelContacts.Name = "LabelContacts";
            LabelContacts.Size = new Size(44, 20);
            LabelContacts.TabIndex = 6;
            LabelContacts.Text = "Чаты";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(999, 527);
            Controls.Add(LabelContacts);
            Controls.Add(LBUsers);
            Controls.Add(MessageRTB);
            Controls.Add(MessagesRTB);
            Controls.Add(SendButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Сообщения";
            FormClosed += Main_FormClosed;
            Load += Main_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SendButton;
        private RichTextBox MessagesRTB;
        private RichTextBox MessageRTB;
        private System.Windows.Forms.Timer UpdateTimer;
        private ListBox LBUsers;
        private Label LabelContacts;
    }
}