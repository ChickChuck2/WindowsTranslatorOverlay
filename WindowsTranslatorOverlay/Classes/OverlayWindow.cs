using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsTranslatorOverlay.Properties;

namespace WindowsTranslatorOverlay.Classes
{
    internal class OverlayWindow
    {
        private bool OverlayOpenned = false;
        private Size RichBoxSize = new Size(200,100);
        public void Overlay()
        {
            Form formOverlay = new Form();
            Point MousePos = new Point(Cursor.Position.X, Cursor.Position.Y);

            Bitmap MoveImage = new Bitmap(Resources.move);

            PictureBox moveBox = new PictureBox();
            moveBox.SizeMode = PictureBoxSizeMode.Zoom;
            moveBox.Location = new Point(0, 0);
            moveBox.Size = new Size(50, 40);
            moveBox.MouseMove += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {
                formOverlay.Cursor = Cursors.NoMove2D;
                if (e.Button == MouseButtons.Left)
                {
                    MousePos = new Point(Cursor.Position.X, Cursor.Position.Y);
                    formOverlay.Location = MousePos;
                }
            });
            moveBox.MouseLeave += new EventHandler((object sender, EventArgs e) =>
            {
                formOverlay.Cursor = Cursors.Default;
            });
            formOverlay.Deactivate += new EventHandler((object sender, EventArgs e) =>
            {
                formOverlay.Opacity = 0.4;
            });
            formOverlay.Activated += new EventHandler((object sender, EventArgs e) =>
            {
                formOverlay.Opacity = 0.7;
            });
            formOverlay.FormClosing += new FormClosingEventHandler((object sender, FormClosingEventArgs e) =>
            {
                e.Cancel = true;
                OverlayOpenned = false;
                formOverlay.Dispose();
                formOverlay.Close();

            });

            moveBox.Image = MoveImage;

            formOverlay.ControlBox = false;
            formOverlay.TopMost = true;
            
            formOverlay.AutoSize = true;

            formOverlay.Controls.Add(moveBox);

            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Location = new Point(0,50);
            flowLayoutPanel.AutoSize = true;
            flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;


            Bitmap equals = new Bitmap(Resources.equals);

            RichTextBox OriginalTextbox = new RichTextBox();
            OriginalTextbox.Size = RichBoxSize;

            PictureBox equalsimage = new PictureBox();
            equalsimage.Image = equals;
            equalsimage.SizeMode = PictureBoxSizeMode.Zoom;

            RichTextBox TranslatedTextbox = new RichTextBox();
            TranslatedTextbox.Size = RichBoxSize;

            flowLayoutPanel.Controls.Add(OriginalTextbox);
            flowLayoutPanel.Controls.Add(equalsimage);
            flowLayoutPanel.Controls.Add(TranslatedTextbox);

            FlowLayoutPanel ButtonsFlow = new FlowLayoutPanel();
            ButtonsFlow.AutoSize = true;
            ButtonsFlow.Size = new Size(100,50);
            ButtonsFlow.Location = new Point(0,180);
            ButtonsFlow.FlowDirection = FlowDirection.RightToLeft;

            Button CopyButton = new Button();
            CopyButton.AutoSize = true;
            CopyButton.Text = "Copy [Ctrl + C]";

            Button ReplaceTextButton = new Button();
            ReplaceTextButton.AutoSize = true;
            ReplaceTextButton.Text = "Replace Text [Ctrl + X]";

            ButtonsFlow.Controls.Add(CopyButton);
            ButtonsFlow.Controls.Add(ReplaceTextButton);

            formOverlay.Controls.Add(ButtonsFlow);
            formOverlay.Controls.Add(flowLayoutPanel);

            formOverlay.Show();
            formOverlay.Location = MousePos;
            OverlayOpenned = true;
        }
    }
}
