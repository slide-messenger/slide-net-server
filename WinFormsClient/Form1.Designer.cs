namespace WinFormsClient
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
            this.components = new System.ComponentModel.Container();
            this.SendButton = new System.Windows.Forms.Button();
            this.UsernameTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MessagesRTB = new System.Windows.Forms.RichTextBox();
            this.MessageRTB = new System.Windows.Forms.RichTextBox();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // SendButton
            // 
            this.SendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SendButton.Location = new System.Drawing.Point(773, 438);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(159, 56);
            this.SendButton.TabIndex = 0;
            this.SendButton.Text = "Отправить";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // UsernameTB
            // 
            this.UsernameTB.Location = new System.Drawing.Point(12, 34);
            this.UsernameTB.Name = "UsernameTB";
            this.UsernameTB.Size = new System.Drawing.Size(210, 29);
            this.UsernameTB.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Имя пользователя:";
            // 
            // MessagesRTB
            // 
            this.MessagesRTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MessagesRTB.Location = new System.Drawing.Point(12, 69);
            this.MessagesRTB.Name = "MessagesRTB";
            this.MessagesRTB.Size = new System.Drawing.Size(920, 363);
            this.MessagesRTB.TabIndex = 3;
            this.MessagesRTB.Text = "";
            // 
            // MessageRTB
            // 
            this.MessageRTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageRTB.Location = new System.Drawing.Point(12, 438);
            this.MessageRTB.Name = "MessageRTB";
            this.MessageRTB.Size = new System.Drawing.Size(755, 54);
            this.MessageRTB.TabIndex = 4;
            this.MessageRTB.Text = "";
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Enabled = true;
            this.UpdateTimer.Interval = 1000;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 504);
            this.Controls.Add(this.MessageRTB);
            this.Controls.Add(this.MessagesRTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UsernameTB);
            this.Controls.Add(this.SendButton);
            this.Name = "Form1";
            this.Text = "WinFormsClient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button SendButton;
        private TextBox UsernameTB;
        private Label label1;
        private RichTextBox MessagesRTB;
        private RichTextBox MessageRTB;
        private System.Windows.Forms.Timer UpdateTimer;
    }
}