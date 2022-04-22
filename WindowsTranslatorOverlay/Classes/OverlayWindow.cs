using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using System.Threading;
using IWshRuntimeLibrary;

namespace WindowsTranslatorOverlay.Classes
{
    internal class OverlayWindow : Form
    {
        private bool OverlayOpenned = false;
        private bool BindingKey = false;

        public float opacityOut;
        public float opacityIn;

        public Keys replaceKey;
        readonly KeyboardHook hook = new KeyboardHook();

        private PictureBox pictureBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private RichTextBox OriginalTextbox;
        private PictureBox pictureBox2;
        private RichTextBox TranslatedTextbox;
        private Button CopyButton;
        private Button translateButton;
        private Button ReplaceTextButton;

        public OverlayWindow()
        {
            InitializeComponent();
        }

        private string TranslatedText = "";

        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.OriginalTextbox = new System.Windows.Forms.RichTextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.TranslatedTextbox = new System.Windows.Forms.RichTextBox();
            this.CopyButton = new System.Windows.Forms.Button();
            this.ReplaceTextButton = new System.Windows.Forms.Button();
            this.translateButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.pictureBox1.Image = global::WindowsTranslatorOverlay.Properties.Resources.move;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.OriginalTextbox);
            this.flowLayoutPanel1.Controls.Add(this.pictureBox2);
            this.flowLayoutPanel1.Controls.Add(this.TranslatedTextbox);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 50);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(537, 106);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // OriginalTextbox
            // 
            this.OriginalTextbox.Location = new System.Drawing.Point(3, 3);
            this.OriginalTextbox.Name = "OriginalTextbox";
            this.OriginalTextbox.Size = new System.Drawing.Size(200, 100);
            this.OriginalTextbox.TabIndex = 0;
            this.OriginalTextbox.Text = "";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WindowsTranslatorOverlay.Properties.Resources.Iconequals;
            this.pictureBox2.Location = new System.Drawing.Point(209, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 100);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // TranslatedTextbox
            // 
            this.TranslatedTextbox.Location = new System.Drawing.Point(315, 3);
            this.TranslatedTextbox.Name = "TranslatedTextbox";
            this.TranslatedTextbox.Size = new System.Drawing.Size(200, 100);
            this.TranslatedTextbox.TabIndex = 2;
            this.TranslatedTextbox.Text = "";
            // 
            // CopyButton
            // 
            this.CopyButton.AutoSize = true;
            this.CopyButton.Location = new System.Drawing.Point(171, 169);
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.Size = new System.Drawing.Size(86, 23);
            this.CopyButton.TabIndex = 2;
            this.CopyButton.Text = "Copy [Ctrl + C]";
            this.CopyButton.UseVisualStyleBackColor = true;
            // 
            // ReplaceTextButton
            // 
            this.ReplaceTextButton.AutoSize = true;
            this.ReplaceTextButton.Location = new System.Drawing.Point(263, 169);
            this.ReplaceTextButton.Name = "ReplaceTextButton";
            this.ReplaceTextButton.Size = new System.Drawing.Size(130, 23);
            this.ReplaceTextButton.TabIndex = 3;
            this.ReplaceTextButton.Text = "Replace text [Ctrl + X]";
            this.ReplaceTextButton.UseVisualStyleBackColor = true;
            // 
            // translateButton
            // 
            this.translateButton.Location = new System.Drawing.Point(3, 159);
            this.translateButton.Name = "translateButton";
            this.translateButton.Size = new System.Drawing.Size(75, 23);
            this.translateButton.TabIndex = 4;
            this.translateButton.Text = "Translate";
            this.translateButton.UseVisualStyleBackColor = true;
            // 
            // OverlayWindow
            // 
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(549, 204);
            this.ControlBox = false;
            this.Controls.Add(this.translateButton);
            this.Controls.Add(this.ReplaceTextButton);
            this.Controls.Add(this.CopyButton);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "OverlayWindow";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        public async void OverlayWindow_Load(Form1 form1)
        {
            ComboBox inputbox = form1.InputcomboBox1;
            ComboBox OutputBox = form1.OutputcomboBox2;

            TranslatedText = GoogleTranslator.Translate(Clipboard.GetText(), GoogleTranslator.InputCode(form1.BoxContent(inputbox).Value.ToString()), GoogleTranslator.OutputCode(form1.BoxContent(OutputBox).Value.ToString()));

            Point MousePos = new Point(Cursor.Position.X, Cursor.Position.Y - 150);
            if (!OverlayOpenned)
            {
                if (!BindingKey)
                {
                    Keys KEY_ = replaceKey;
                    List<ModifierKeys> mod = new List<ModifierKeys>();

                    int replacespecialkeycount = KEY_.ToString().Split(',').Length;

                    for (int i = 0; i < replacespecialkeycount; i++)
                    {
                        Keys replacespecialKey = (Keys)Enum.Parse(typeof(Keys), KEY_.ToString().Split(',')[i], true);
                        if (replacespecialKey == Keys.Alt)
                            mod.Add(Classes.ModifierKeys.Alt);
                        else if (replacespecialKey == Keys.Control)
                            mod.Add(Classes.ModifierKeys.Control);
                        else if (replacespecialKey == Keys.Shift)
                            mod.Add(Classes.ModifierKeys.Shift);
                        else if (replacespecialKey == Keys.LWin)
                            mod.Add(Classes.ModifierKeys.Win);

                        if (i >= 2)
                            break;
                    }
                    Keys key = (Keys)Enum.Parse(typeof(Keys), KEY_.ToString().Split(',')[0], true);

                    hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(Hook_KeyPressed);
                    if (key == Keys.None)
                    {
                        hook.RegisterHotKey(Classes.ModifierKeys.Control, Keys.C);
                        ReplaceTextButton.Text = $"Replace [{Classes.ModifierKeys.Control}+{Keys.C}]";
                    }
                    else if (mod.Count == 1)
                    {
                        hook.RegisterHotKey(mod[0], key);
                        ReplaceTextButton.Text = $"Replace [{mod[0]}+{key}]";
                    }
                    else if (mod.Count == 2)
                    {
                        hook.RegisterHotKey(mod[0] | mod[1], key);
                        ReplaceTextButton.Text = $"Replace [{mod[0]}+{mod[1]}+{key}]";
                    }
                    BindingKey = true;
                }

                if (Clipboard.ContainsText())
                {
                    string Input = Clipboard.GetText();
                    string Output = "";

                    if (!form1.ReplaceAutomatic.Checked)
                    {
                        if(!form1.copyautomatic.Checked)
                        {
                            Show();
                            Location = MousePos;
                            OverlayOpenned = true;
                        }

                        OriginalTextbox.Text = Input;
                        await Task.Factory.StartNew(() =>
                        {
                            try
                            {
                                Output = TranslatedText;
                            }
                            catch (FaultException FE)
                            {
                                Output = "ERROR";
                                Console.WriteLine(FE.Message);
                            }
                        });
                        TranslatedTextbox.Text = Output;
                    }else
                    {
                        WshShell shell = new WshShell();
                        Output = TranslatedText;
                        Thread.Sleep(300);
                        shell.SendKeys(Output);
                    }
                    if(form1.copyautomatic.Checked)
                    {
                        Output = TranslatedText;
                        Clipboard.SetText(Output);
                    }
                }
                else
                {
                    WarnTimestampForm warn = new WarnTimestampForm();
                    warn.Loadwarn(2);
                }
            }
            else
                Location = MousePos;

            translateButton.Click += new EventHandler((object sender, EventArgs e) =>
            {
                string Output = "";
                string Input = OriginalTextbox.Text;


                Output = GoogleTranslator.Translate(Input, GoogleTranslator.InputCode(form1.BoxContent(inputbox).Value.ToString()), GoogleTranslator.OutputCode(form1.BoxContent(OutputBox).Value.ToString()));

                TranslatedTextbox.Text = Output;
            });

            CopyButton.Click += new EventHandler((object sender, EventArgs e) =>
            {
                string Input = OriginalTextbox.Text;
                string Output = "";
                Output = TranslatedText;
                if (Clipboard.GetText().Length > 1)
                    Clipboard.SetText(TranslatedTextbox.Text);

            });
            ReplaceTextButton.Click += new EventHandler((object sender, EventArgs e) =>
            {
                OverlayOpenned = false;
                Hide();
                if (Clipboard.GetText().Length > 1)
                {
                    WshShell shell = new WshShell();
                    Thread.Sleep(300);
                    shell.SendKeys(TranslatedText);
                }
            });

            pictureBox1.MouseMove += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {
                Cursor = Cursors.SizeAll;
                if (e.Button == MouseButtons.Left)
                {
                    Point MousePos1 = new Point(Cursor.Position.X, Cursor.Position.Y);
                    Location = MousePos1;
                }
            });

            pictureBox1.MouseLeave += new EventHandler((object sender, EventArgs e) => { Cursor = Cursors.Default; });
            Activated += new EventHandler((object sender, EventArgs e) => { Opacity = opacityOut; });
            Deactivate += new EventHandler((object sender, EventArgs e) => { Opacity = opacityIn; });

            FormClosing += new FormClosingEventHandler((object sender, FormClosingEventArgs e) =>
            {
                e.Cancel = true;
                OverlayOpenned = false;
                Hide();
            });
        }
        private void Hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            try
            {
                OverlayOpenned = false;
                Hide();
                if (Clipboard.GetText().Length > 1)
                {
                    Clipboard.SetText(TranslatedTextbox.Text);
                    SendKeys.Send("^{v}");
                }
            }catch
            {
                Console.WriteLine("Janela não aberta");
            }
        }
    }
}
