namespace WindowsTranslatorOverlay.Classes
{
    partial class ConfirmCloseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmCloseForm));
            this.closebutton = new System.Windows.Forms.Button();
            this.traybutton = new System.Windows.Forms.Button();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // closebutton
            // 
            this.closebutton.Location = new System.Drawing.Point(12, 12);
            this.closebutton.Name = "closebutton";
            this.closebutton.Size = new System.Drawing.Size(75, 23);
            this.closebutton.TabIndex = 0;
            this.closebutton.Text = "Close [C]";
            this.closebutton.UseVisualStyleBackColor = true;
            this.closebutton.Click += new System.EventHandler(this.closebutton_Click);
            // 
            // traybutton
            // 
            this.traybutton.Location = new System.Drawing.Point(72, 51);
            this.traybutton.Name = "traybutton";
            this.traybutton.Size = new System.Drawing.Size(75, 23);
            this.traybutton.TabIndex = 1;
            this.traybutton.Text = "Hidden [T]";
            this.traybutton.UseVisualStyleBackColor = true;
            // 
            // cancelbutton
            // 
            this.cancelbutton.Location = new System.Drawing.Point(131, 12);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(75, 23);
            this.cancelbutton.TabIndex = 2;
            this.cancelbutton.Text = "Cancel [S]";
            this.cancelbutton.UseVisualStyleBackColor = true;
            this.cancelbutton.Click += new System.EventHandler(this.cancelbutton_Click);
            // 
            // ConfirmCloseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(218, 86);
            this.ControlBox = false;
            this.Controls.Add(this.cancelbutton);
            this.Controls.Add(this.traybutton);
            this.Controls.Add(this.closebutton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfirmCloseForm";
            this.Text = "Close??";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfirmCloseForm_FormClosing);
            this.Load += new System.EventHandler(this.ConfirmCloseForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button closebutton;
        public System.Windows.Forms.Button traybutton;
        public System.Windows.Forms.Button cancelbutton;
    }
}