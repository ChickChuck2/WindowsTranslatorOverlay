using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsTranslatorOverlay.Classes;

namespace WindowsTranslatorOverlay
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        KeyboardHook hook = new KeyboardHook();
        private OverlayWindow overlayWindow = new OverlayWindow();

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KeyPreview = true;

            hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            hook.RegisterHotKey(Classes.ModifierKeys.Control | Classes.ModifierKeys.Alt, Keys.X);

            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;

            new ToastContentBuilder()
                .AddAppLogoOverride()
                .AddText("Notificação")
                .Show();

        }
        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            overlayWindow.Overlay();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();

            notifyIcon1.Text = "Windows Translator Overlay";
            notifyIcon1.Visible = true;
            notifyIcon1.DoubleClick += new EventHandler((object sender1, EventArgs e1) =>
            {
                Show();
            });
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
