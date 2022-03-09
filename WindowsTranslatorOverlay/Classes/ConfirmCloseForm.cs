using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace WindowsTranslatorOverlay.Classes
{
    public partial class ConfirmCloseForm : Form
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.T)
            {
                Form1.ShowForm1 = false;
                Close();
                return true;
            }
            else if(keyData == Keys.C)
            {
                Process.GetCurrentProcess().Kill();
                return true;
            }
            else if(keyData == Keys.S)
            {
                Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        public ConfirmCloseForm()
        {
            InitializeComponent();
        }

        private void ConfirmCloseForm_Load(object sender, EventArgs e)
        {

        }
        private void cancelbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void ConfirmCloseForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
