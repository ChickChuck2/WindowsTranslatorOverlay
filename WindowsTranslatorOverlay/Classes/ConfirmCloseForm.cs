using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.UI.Xaml;

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
            int time = 3;
			Task.Run(async() =>
            {
                while(true)
                {
                    Console.WriteLine(time);
                    Invoke(new Action(() => timerlabel.Text = $"Fechando em: {time}"));
                    await Task.Delay(1000);
                    time--;
                    if (time < 1)
                    {
                        Process.GetCurrentProcess().Kill();
						break;
					}
                }
			});
        }
        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Closebutton_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void ConfirmCloseForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

    }
}
