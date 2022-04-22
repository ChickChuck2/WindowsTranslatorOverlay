using System;
using System.Threading;
using System.Windows.Forms;

namespace WindowsTranslatorOverlay.Classes
{
    public partial class WarnTimestampForm : Form
    {
        public WarnTimestampForm()
        {
            InitializeComponent();
        }

        private int CountSeconds(int seconds)
        {
            int miliseconds = (int)TimeSpan.FromSeconds(seconds).TotalMilliseconds;
            int value = seconds;
            button1.Text = $"Ok ({value})";
            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(miliseconds);
                    value--;
                    try
                    {
                        BeginInvoke((Action)delegate ()
                        {
                            button1.Text = $"Ok ({value})";
                        });
                        returnValue();
                        if (value <= 0)
                        {
                            BeginInvoke((Action)delegate ()
                            {
                                Close();
                            });
                            break;
                        }
                    }catch(InvalidOperationException IOE)
                    {
                        Console.WriteLine($"Form Closed {IOE.Message}");
                        break;
                    }
                }
            });
            thread.Start();
            return value;

            int returnValue()
            {
                return value;
            }
        }

        private void WarnTimestampForm_Load(object sender, EventArgs e)
        {
            CountSeconds(3);
        }
        public void Loadwarn(int seconds)
        {
            Show();
            CountSeconds(seconds);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
