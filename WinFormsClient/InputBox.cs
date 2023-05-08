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
        public InputBox(string title = "")
        {
            InitializeComponent();

            LabelTitle.Text = title;
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void InputBox_Load(object sender, EventArgs e)
        {

        }
    }
}
