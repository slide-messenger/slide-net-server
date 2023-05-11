using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsClient
{
    public partial class InputBox : Form
    {
        public string Result
        {
            get { return TBResult.Text; }
        }
        public InputBox()
        {
            InitializeComponent();
        }

        public DialogResult Execute(string title = "", int? maxSize = null)
        {
            LabelTitle.Text = title;
            TBResult.MaxLength = maxSize ?? 32767;

            return ShowDialog();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBResult.Text))
            {
                MessageBox.Show("Заполните поле", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void InputBox_Load(object sender, EventArgs e)
        {

        }
    }
}
