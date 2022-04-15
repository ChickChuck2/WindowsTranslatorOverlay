using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WindowsTranslatorOverlay.Classes
{
    public enum Typefile
    {
        Create,
        Load,
        Save
    }

    internal class ManagerSettings
    {
        public void LoadOrCreateConfig(Typefile typefile, OverlayWindow overlayWindow, Form1 form1)
        {
            string apppath = Application.StartupPath;
            if (typefile == Typefile.Create)
            {
                StringBuilder sb = new StringBuilder();
                StringWriter sw = new StringWriter(sb);

                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    writer.Formatting = Formatting.Indented;

                    writer.WriteStartObject();

                    writer.WritePropertyName("InputValue");
                    writer.WriteValue(0);

                    writer.WritePropertyName("OutputValue");
                    writer.WriteValue(52);

                    writer.WritePropertyName("startwithwindows");
                    writer.WriteValue(false);

                    writer.WritePropertyName("automaticReplace");
                    writer.WriteValue(false);

                    writer.WritePropertyName("automaticcopy");
                    writer.WriteValue(false);

                    writer.WritePropertyName("Shortcuts");
                    writer.WriteStartArray();
                    writer.WriteStartObject();

                    writer.WritePropertyName("showmoveoverlay");
                    writer.WriteValue(Keys.Control | Keys.Alt | Keys.X);

                    writer.WritePropertyName("copytrans");
                    writer.WriteValue(Keys.Control | Keys.C);

                    writer.WritePropertyName("replace");
                    writer.WriteValue(Keys.Control | Keys.X);

                    writer.WriteEndObject();
                    writer.WriteEnd();

                    writer.WritePropertyName("transparency");
                    writer.WriteStartArray();
                    writer.WriteStartObject();

                    writer.WritePropertyName("transparencyin");
                    writer.WriteValue(0.7f);

                    overlayWindow.opacityIn = 0.7f;

                    writer.WritePropertyName("transparencyout");
                    writer.WriteValue(0.5f);

                    overlayWindow.opacityOut = 0.5f;

                    writer.WriteEndObject();


                    writer.WriteEnd();
                    writer.WriteEndObject();

                    using (StreamWriter file = File.CreateText($@"{apppath}\configs.json"))
                    {
                        JObject JOBe = JObject.Parse(sb.ToString());

                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Formatting = Formatting.Indented;
                        serializer.Serialize(file, JOBe);

                        file.Dispose();
                    }
                }
            }
            else if (typefile == Typefile.Load)
            {
                StreamReader r = new StreamReader($@"{apppath}\configs.json");
                string json = r.ReadToEnd();

                dynamic data = JObject.Parse(json);

                bool startwithwindows = data.startwithwindows;

                bool automaticReplace = data.automaticReplace;
                bool automaticcopy = data.automaticcopy;

                dynamic Shortcuts = data.Shortcuts[0];

                int InputValue = data.InputValue;
                int OutputValue = data.OutputValue;

                Keys showmoveoverlay = Shortcuts.showmoveoverlay;
                Keys copytrans = Shortcuts.copytrans;
                Keys replace = Shortcuts.replace;

                dynamic transparency = data.transparency[0];

                float transparencyin = transparency.transparencyin;
                float transparencyout = transparency.transparencyout;

                form1.InputcomboBox1.SelectedIndex = InputValue;
                form1.OutputcomboBox2.SelectedIndex = OutputValue;

                form1.checkboxWindows.Checked = startwithwindows;
                form1.startwithwindowsbool = startwithwindows;

                form1.ReplaceAutomatic.Checked = automaticReplace;
                form1.copyautomatic.Checked = automaticcopy;

                form1.textboxOverlay.Text = showmoveoverlay.ToString();
                form1.moveoverlayKey = showmoveoverlay;

                form1.textboxCopyT.Text = copytrans.ToString();
                form1.copyTKey = copytrans;

                form1.textboxReplaceText.Text = replace.ToString();
                form1.replaceKey = replace;

                form1.opacityIn.Text = transparencyin.ToString();
                form1.FopacityIn = transparencyin;
                overlayWindow.opacityIn = transparencyin;

                form1.opacityOut.Text = transparencyout.ToString();
                form1.FopacityOut = transparencyout;
                overlayWindow.opacityOut = transparencyout;

                r.Dispose();

            }
            else if (typefile == Typefile.Save)
            {
                StartWithWindows start = new StartWithWindows();

                string json = File.ReadAllText($@"{apppath}\configs.json");
                dynamic jsonobj = JsonConvert.DeserializeObject(json);

                jsonobj.InputValue = form1.InputcomboBox1.SelectedIndex;
                jsonobj.OutputValue = form1.OutputcomboBox2.SelectedIndex;

                jsonobj.startwithwindows = form1.checkboxWindows.Checked;

                jsonobj.automaticReplace = form1.ReplaceAutomatic.Checked;
                jsonobj.automaticcopy = form1.copyautomatic.Checked;

                dynamic shortcuts = jsonobj.Shortcuts[0];
                shortcuts.showmoveoverlay = form1.moveoverlayKey;
                shortcuts.copytrans = form1.copyTKey;
                shortcuts.replace = form1.replaceKey;

                dynamic transparency = jsonobj.transparency[0];
                form1.FopacityIn = (float)Math.Round(form1.FopacityIn * 100f) / 100f;
                transparency.transparencyin = form1.FopacityIn;
                form1.FopacityOut = (float)Math.Round(form1.FopacityOut * 100f) / 100f;
                transparency.transparencyout = form1.FopacityOut;

                string output = JsonConvert.SerializeObject(jsonobj, Formatting.Indented);
                File.WriteAllText($@"{apppath}\configs.json", output);

                start.SetStartup(form1.checkboxWindows);

                MessageBox.Show("Reinicie para aplicar algumas aletações", "WOW!!!");
            }
        }
    }
}
