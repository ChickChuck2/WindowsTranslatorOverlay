using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

        private ManagerSettings managerSettings = new ManagerSettings();
        private OverlayWindow overlayWindow = new OverlayWindow();

        public static bool ShowForm1 = true;

        public bool startwithwindowsbool;

        public float FopacityIn;
        public float FopacityOut;

        public Keys moveoverlayKey;
        public Keys copyTKey;
        public Keys replaceKey;
        protected override bool ProcessCmdKey(ref Message msg, Keys KeyData)
        {
            if (KeyData == Keys.Escape)
            {
                DialogResult dialog = MessageBox.Show(this, "Fechar o programa?", "Sair?", MessageBoxButtons.YesNo);

                if (dialog == DialogResult.Yes)
                    Process.GetCurrentProcess().Kill();
                return true;
            }

            return base.ProcessCmdKey(ref msg, KeyData);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            string CurrentPath = Application.StartupPath;
            if (!File.Exists($@"{CurrentPath}\configs.json"))
            {
                File.Create($@"{CurrentPath}\configs.json").Dispose();
                managerSettings.LoadOrCreateConfig(Typefile.Create, overlayWindow, this);
            }
            else
                managerSettings.LoadOrCreateConfig(Typefile.Load, overlayWindow, this);

            InputcomboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            OutputcomboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            GoogleTranslator translator = new GoogleTranslator();
            InputcomboBox1.Items.Add("auto");
            for (int i = 0; i < translator.ValueName().Count; i++)
            {
                InputcomboBox1.Items.Add(translator.ValueName()[i].Key);
                OutputcomboBox2.Items.Add(translator.ValueName()[i].Key);
            }
            Console.WriteLine(InputcomboBox1.SelectedIndex);

            string hotkeyplaceholder = "";

            Keys key = (Keys)Enum.Parse(typeof(Keys), moveoverlayKey.ToString().Split(',')[0], true);

            int specialkeycount = moveoverlayKey.ToString().Split(',').Length;

            List<ModifierKeys> mod = new List<ModifierKeys>();
            for (int i = 0; i < specialkeycount; i++)
            {
                Keys movespecialKey = (Keys)Enum.Parse(typeof(Keys), moveoverlayKey.ToString().Split(',')[i], true);

                if (movespecialKey == Keys.Alt)
                    mod.Add(Classes.ModifierKeys.Alt);
                else if (movespecialKey == Keys.Control)
                    mod.Add(Classes.ModifierKeys.Control);
                else if (movespecialKey == Keys.Shift)
                    mod.Add(Classes.ModifierKeys.Shift);
                else if (movespecialKey == Keys.LWin)
                    mod.Add(Classes.ModifierKeys.Win);

                if (i >= 2)
                    break;
            }
            hotkeyplaceholder = string.Join($"+", mod.ToArray());
            string hotkeymessage = "";

            hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            if (moveoverlayKey == Keys.None)
            {
                hook.RegisterHotKey(Classes.ModifierKeys.Control | Classes.ModifierKeys.Alt, Keys.X);
                hotkeymessage = $"{Classes.ModifierKeys.Control}+{Classes.ModifierKeys.Alt}+{Keys.X}";
            }
                
            else if (mod.Count == 1)
            {
                hook.RegisterHotKey(mod[0], key);
                hotkeymessage = $"{hotkeyplaceholder}+{key}";
            }else if (mod.Count == 2)
            {
                hook.RegisterHotKey(mod[0] | mod[1], key);
                hotkeymessage = $"{hotkeyplaceholder}+{key}";
            }

            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            KeyPreview = true;
            Hide();

            Uri logourl = new Uri("https://github.com/ChickChuck2/WindowsTranslatorOverlay/blob/master/WindowsTranslatorOverlay/Resources/icon2.png?raw=true");
            new ToastContentBuilder()
                .AddAppLogoOverride(logourl)
                .AddText("Rodando em segundo plano")
                .AddText($"{hotkeymessage}")
                .Show();

            overlayWindow.replaceKey = replaceKey;

            HideForm();
        }

        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            overlayWindow.OverlayWindow_Load(this);
        }
        public void HideForm()
        {
            SizeChanged += new EventHandler((object sender, EventArgs e) =>
            {
                if (!ShowForm1)
                {
                    WindowState = FormWindowState.Minimized;
                    ShowInTaskbar = false;
                    Hide();
                    ShowForm1 = !ShowForm1;
                }
            });
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfirmCloseForm f = new ConfirmCloseForm();
            f.Show();

            f.traybutton.Click += new EventHandler((object sender1, EventArgs e1) =>
            {
                e.Cancel = true;
                WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;
                Hide();
                f.Close();
            });
            e.Cancel = true;

        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            KeysConverter converter = new KeysConverter();
            textboxOverlay.Text = converter.ConvertToString(e.KeyData);
            moveoverlayKey = e.KeyData;
        }
        private void textboxCopyT_KeyDown(object sender, KeyEventArgs e)
        {
            KeysConverter converter = new KeysConverter();
            textboxCopyT.Text = converter.ConvertToString(e.KeyData);
            copyTKey = e.KeyData;
        }
        private void textboxReplaceText_KeyDown(object sender, KeyEventArgs e)
        {
            KeysConverter converter = new KeysConverter();
            textboxReplaceText.Text = converter.ConvertToString(e.KeyData);
            replaceKey = e.KeyData;
        }

        private void opacityIn_MouseDown(object sender, MouseEventArgs e)
        {
            FopacityIn = (float)Math.Round(FopacityIn * 100f) / 100f;
            
            if (e.Button == MouseButtons.Left)
            {
                if (FopacityIn < 1)
                {
                    FopacityIn = FopacityIn + 0.1f;
                    opacityIn.Text = FopacityIn.ToString();
                }
            }
            if(e.Button == MouseButtons.Right)
            {
                if (FopacityIn > 0.1f)
                {
                    FopacityIn = FopacityIn - 0.1f;
                    opacityIn.Text = FopacityIn.ToString();
                }
            }
        }

        private void opacityOut_MouseDown(object sender, MouseEventArgs e)
        {
            FopacityOut = (float)Math.Round(FopacityOut * 100f) / 100f;


            if(e.Button == MouseButtons.Left)
            {
                if (FopacityOut < 1)
                {
                    FopacityOut = FopacityOut + 0.1f;
                    opacityOut.Text = FopacityOut.ToString();
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                if(FopacityOut > 0.1f)
                {
                    FopacityOut = FopacityOut - 0.1f;
                    opacityOut.Text = FopacityOut.ToString();
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            managerSettings.LoadOrCreateConfig(Typefile.Save, overlayWindow, this);
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            Show();
            TopMost = true;
            TopMost = false;
        }

        private void fecharToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            Show();
            TopMost = true;
            TopMost = false;
            
        }
    }
}
