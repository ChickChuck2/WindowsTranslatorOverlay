namespace WindowsTranslatorOverlay
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fecharToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayItens = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mostrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fecharToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.OutputcomboBox2 = new System.Windows.Forms.ComboBox();
            this.Output = new System.Windows.Forms.Label();
            this.InputcomboBox1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ReplaceAutomatic = new System.Windows.Forms.CheckBox();
            this.copyautomatic = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textboxOverlay = new System.Windows.Forms.TextBox();
            this.textboxCopyT = new System.Windows.Forms.TextBox();
            this.textboxReplaceText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.opacityOut = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.opacityIn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkboxWindows = new System.Windows.Forms.CheckBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.trayItens.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fecharToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // fecharToolStripMenuItem
            // 
            this.fecharToolStripMenuItem.Name = "fecharToolStripMenuItem";
            this.fecharToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.fecharToolStripMenuItem.Text = "Fechar";
            this.fecharToolStripMenuItem.Click += new System.EventHandler(this.FecharToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.trayItens;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Windows Translator Overlay";
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.NotifyIcon1_DoubleClick);
            // 
            // trayItens
            // 
            this.trayItens.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mostrarToolStripMenuItem,
            this.fecharToolStripMenuItem1});
            this.trayItens.Name = "trayItens";
            this.trayItens.Size = new System.Drawing.Size(104, 48);
            // 
            // mostrarToolStripMenuItem
            // 
            this.mostrarToolStripMenuItem.Image = global::WindowsTranslatorOverlay.Properties.Resources.window_25;
            this.mostrarToolStripMenuItem.Name = "mostrarToolStripMenuItem";
            this.mostrarToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.mostrarToolStripMenuItem.Text = "Show";
            this.mostrarToolStripMenuItem.Click += new System.EventHandler(this.MostrarToolStripMenuItem_Click);
            // 
            // fecharToolStripMenuItem1
            // 
            this.fecharToolStripMenuItem1.Image = global::WindowsTranslatorOverlay.Properties.Resources.X;
            this.fecharToolStripMenuItem1.Name = "fecharToolStripMenuItem1";
            this.fecharToolStripMenuItem1.ShortcutKeyDisplayString = "";
            this.fecharToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.fecharToolStripMenuItem1.Text = "Close";
            this.fecharToolStripMenuItem1.Click += new System.EventHandler(this.FecharToolStripMenuItem1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.OutputcomboBox2);
            this.splitContainer1.Panel1.Controls.Add(this.Output);
            this.splitContainer1.Panel1.Controls.Add(this.InputcomboBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ReplaceAutomatic);
            this.splitContainer1.Panel2.Controls.Add(this.copyautomatic);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.textboxOverlay);
            this.splitContainer1.Panel2.Controls.Add(this.textboxCopyT);
            this.splitContainer1.Panel2.Controls.Add(this.textboxReplaceText);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.opacityOut);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.opacityIn);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.checkboxWindows);
            this.splitContainer1.Size = new System.Drawing.Size(800, 384);
            this.splitContainer1.SplitterDistance = 328;
            this.splitContainer1.TabIndex = 1;
            // 
            // OutputcomboBox2
            // 
            this.OutputcomboBox2.FormattingEnabled = true;
            this.OutputcomboBox2.Location = new System.Drawing.Point(61, 166);
            this.OutputcomboBox2.Name = "OutputcomboBox2";
            this.OutputcomboBox2.Size = new System.Drawing.Size(144, 21);
            this.OutputcomboBox2.TabIndex = 4;
            // 
            // Output
            // 
            this.Output.AutoSize = true;
            this.Output.Location = new System.Drawing.Point(12, 174);
            this.Output.Name = "Output";
            this.Output.Size = new System.Drawing.Size(39, 13);
            this.Output.TabIndex = 3;
            this.Output.Text = "Output";
            // 
            // InputcomboBox1
            // 
            this.InputcomboBox1.FormattingEnabled = true;
            this.InputcomboBox1.Location = new System.Drawing.Point(61, 123);
            this.InputcomboBox1.Name = "InputcomboBox1";
            this.InputcomboBox1.Size = new System.Drawing.Size(144, 21);
            this.InputcomboBox1.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 131);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Input";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsTranslatorOverlay.Properties.Resources.icon2;
            this.pictureBox1.Location = new System.Drawing.Point(114, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(79, 76);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ReplaceAutomatic
            // 
            this.ReplaceAutomatic.AutoSize = true;
            this.ReplaceAutomatic.Location = new System.Drawing.Point(16, 284);
            this.ReplaceAutomatic.Name = "ReplaceAutomatic";
            this.ReplaceAutomatic.Size = new System.Drawing.Size(115, 17);
            this.ReplaceAutomatic.TabIndex = 8;
            this.ReplaceAutomatic.Text = "Replace automatic";
            this.ReplaceAutomatic.UseVisualStyleBackColor = true;
            // 
            // copyautomatic
            // 
            this.copyautomatic.AutoSize = true;
            this.copyautomatic.Location = new System.Drawing.Point(16, 307);
            this.copyautomatic.Name = "copyautomatic";
            this.copyautomatic.Size = new System.Drawing.Size(99, 17);
            this.copyautomatic.TabIndex = 7;
            this.copyautomatic.Text = "Automatic copy";
            this.copyautomatic.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Shortcut Keys";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Open | Move Overlay";
            // 
            // textboxOverlay
            // 
            this.textboxOverlay.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textboxOverlay.Location = new System.Drawing.Point(126, 183);
            this.textboxOverlay.Name = "textboxOverlay";
            this.textboxOverlay.ReadOnly = true;
            this.textboxOverlay.Size = new System.Drawing.Size(153, 20);
            this.textboxOverlay.TabIndex = 1;
            this.textboxOverlay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox1_KeyDown);
            // 
            // textboxCopyT
            // 
            this.textboxCopyT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textboxCopyT.Location = new System.Drawing.Point(126, 209);
            this.textboxCopyT.Name = "textboxCopyT";
            this.textboxCopyT.ReadOnly = true;
            this.textboxCopyT.Size = new System.Drawing.Size(153, 20);
            this.textboxCopyT.TabIndex = 4;
            this.textboxCopyT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextboxCopyT_KeyDown);
            // 
            // textboxReplaceText
            // 
            this.textboxReplaceText.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textboxReplaceText.Location = new System.Drawing.Point(126, 235);
            this.textboxReplaceText.Name = "textboxReplaceText";
            this.textboxReplaceText.ReadOnly = true;
            this.textboxReplaceText.Size = new System.Drawing.Size(153, 20);
            this.textboxReplaceText.TabIndex = 6;
            this.textboxReplaceText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextboxReplaceText_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Copy Translated";
            // 
            // opacityOut
            // 
            this.opacityOut.Location = new System.Drawing.Point(126, 328);
            this.opacityOut.Name = "opacityOut";
            this.opacityOut.Size = new System.Drawing.Size(75, 23);
            this.opacityOut.TabIndex = 6;
            this.opacityOut.Text = "0.4";
            this.opacityOut.UseVisualStyleBackColor = true;
            this.opacityOut.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OpacityOut_MouseDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Replace Text";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(207, 338);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "out";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(105, 338);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "in";
            // 
            // opacityIn
            // 
            this.opacityIn.Location = new System.Drawing.Point(235, 328);
            this.opacityIn.Name = "opacityIn";
            this.opacityIn.Size = new System.Drawing.Size(75, 23);
            this.opacityIn.TabIndex = 3;
            this.opacityIn.Text = "0.7";
            this.opacityIn.UseVisualStyleBackColor = true;
            this.opacityIn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OpacityIn_MouseDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 338);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Transparency";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Settings";
            // 
            // checkboxWindows
            // 
            this.checkboxWindows.AutoSize = true;
            this.checkboxWindows.Location = new System.Drawing.Point(16, 261);
            this.checkboxWindows.Name = "checkboxWindows";
            this.checkboxWindows.Size = new System.Drawing.Size(117, 17);
            this.checkboxWindows.TabIndex = 0;
            this.checkboxWindows.Text = "Start with Windows";
            this.checkboxWindows.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(294, 414);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Windows Translator Overlay";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.trayItens.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fecharToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label Output;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TextBox textboxOverlay;
        public System.Windows.Forms.TextBox textboxReplaceText;
        public System.Windows.Forms.TextBox textboxCopyT;
        public System.Windows.Forms.CheckBox checkboxWindows;
        public System.Windows.Forms.Button opacityIn;
        public System.Windows.Forms.Button opacityOut;
        public System.Windows.Forms.ComboBox OutputcomboBox2;
        public System.Windows.Forms.ComboBox InputcomboBox1;
        private System.Windows.Forms.ContextMenuStrip trayItens;
        private System.Windows.Forms.ToolStripMenuItem fecharToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mostrarToolStripMenuItem;
        public System.Windows.Forms.CheckBox ReplaceAutomatic;
        public System.Windows.Forms.CheckBox copyautomatic;
        public System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer timer1;
    }
}

