using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
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

        readonly KeyboardHook hook = new KeyboardHook();

        private readonly ManagerSettings managerSettings = new ManagerSettings();
        private readonly OverlayWindow overlayWindow = new OverlayWindow();

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

        public ComboboxItem BoxContent(ComboBox comboBox)
        {
            if (comboBox.SelectedIndex == -1)
                return new ComboboxItem { Text = "Português", Value = "pt" };
            return comboBox.SelectedItem as ComboboxItem;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine(GoogleTranslator.Translate("fodase?",GoogleTranslator.LangCode.auto, GoogleTranslator.LangCode.ru));

            notifyIcon1.Visible = true;

            InputcomboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            OutputcomboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            InputcomboBox1.Items.Add(new ComboboxItem { Text = "auto", Value = "auto" });
            for (int i = 0; i < GoogleTranslator.ValueName().Count; i++)
            {
                InputcomboBox1.Items.Add(new ComboboxItem { Text = GoogleTranslator.ValueName()[i].Key, Value = GoogleTranslator.ValueName()[i].Value });
                OutputcomboBox2.Items.Add(new ComboboxItem { Text = GoogleTranslator.ValueName()[i].Key, Value = GoogleTranslator.ValueName()[i].Value });
            }

            InputcomboBox1.SelectedIndexChanged += new EventHandler((object sender1, EventArgs e1) =>
            {
                string Key = BoxContent(InputcomboBox1).Text;
                string Value = BoxContent(InputcomboBox1).Value.ToString();

            });
            OutputcomboBox2.SelectedIndexChanged += new EventHandler((object sender1, EventArgs e1) =>
            {
                string Key = BoxContent(OutputcomboBox2).Text;
                string Value = BoxContent(OutputcomboBox2).Value.ToString();

            });

            string CurrentPath = Application.StartupPath;
            if (!File.Exists($@"{CurrentPath}\configs.json"))
            {
                File.Create($@"{CurrentPath}\configs.json").Dispose();
                managerSettings.LoadOrCreateConfig(Typefile.Create, overlayWindow, this);
            }
            else
                managerSettings.LoadOrCreateConfig(Typefile.Load, overlayWindow, this);

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

            hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(Hook_KeyPressed);
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

            if (!File.Exists($@"{Application.StartupPath}\logo.png"))
            {
                WebClient client = new WebClient();
                Uri logourl = new Uri("https://media.discordapp.net/attachments/770093105516642305/962842510533722172/icon2.png", UriKind.Absolute);
                client.DownloadFile(logourl, $@"{Application.StartupPath}\logo.png");
            }
            new ToastContentBuilder()
                .AddAppLogoOverride(new Uri($@"{Application.StartupPath}\logo.png"))
                .AddText("Rodando em segundo plano")
                .AddText($"{hotkeymessage}")
                .AddText($"Atualmente {InputcomboBox1.SelectedText} >> {OutputcomboBox2.SelectedText}")
                .Show();
            overlayWindow.replaceKey = replaceKey;
            HideForm();
        }

        void Hook_KeyPressed(object sender, KeyPressedEventArgs e)
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

        private void FecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            KeysConverter converter = new KeysConverter();
            textboxOverlay.Text = converter.ConvertToString(e.KeyData);
            moveoverlayKey = e.KeyData;
        }
        private void TextboxCopyT_KeyDown(object sender, KeyEventArgs e)
        {
            KeysConverter converter = new KeysConverter();
            textboxCopyT.Text = converter.ConvertToString(e.KeyData);
            copyTKey = e.KeyData;
        }
        private void TextboxReplaceText_KeyDown(object sender, KeyEventArgs e)
        {
            KeysConverter converter = new KeysConverter();
            textboxReplaceText.Text = converter.ConvertToString(e.KeyData);
            replaceKey = e.KeyData;
        }

        private void OpacityIn_MouseDown(object sender, MouseEventArgs e)
        {
            FopacityIn = (float)Math.Round(FopacityIn * 100f) / 100f;
            
            if (e.Button == MouseButtons.Left)
            {
                if (FopacityIn < 1)
                {
                    FopacityIn += 0.1f;
                    opacityIn.Text = FopacityIn.ToString();
                }
            }
            if(e.Button == MouseButtons.Right)
            {
                if (FopacityIn > 0.1f)
                {
                    FopacityIn -= 0.1f;
                    opacityIn.Text = FopacityIn.ToString();
                }
            }
        }

        private void OpacityOut_MouseDown(object sender, MouseEventArgs e)
        {
            FopacityOut = (float)Math.Round(FopacityOut * 100f) / 100f;


            if(e.Button == MouseButtons.Left)
            {
                if (FopacityOut < 1)
                {
                    FopacityOut += 0.1f;
                    opacityOut.Text = FopacityOut.ToString();
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                if(FopacityOut > 0.1f)
                {
                    FopacityOut -= 0.1f;
                    opacityOut.Text = FopacityOut.ToString();
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            managerSettings.LoadOrCreateConfig(Typefile.Save, overlayWindow, this);
        }

        private void NotifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            Show();
            TopMost = true;
            TopMost = false;
        }

        private void FecharToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void MostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            Show();
            TopMost = true;
            TopMost = false;
            
        }
    }
}
