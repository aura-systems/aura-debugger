using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Aura_Debugger
{
    public static class ConfigManager
    {
        public static string FileName = "cnd_config.ini";

        public static bool WordWrap = true;
        public static bool AutoScroll = true;

        public static void SaveConfig()
        {
            WordWrap = Program.MainForm.GetWordWrap();
            AutoScroll = Program.MainForm.GetAutoScroll();

            string config = "word_wrap," + WordWrap.ToString() + "\n";
            config += "auto_scroll," + AutoScroll.ToString() + "\n";
            config += "win_pos," + Program.MainForm.Location.X.ToString() + "," + Program.MainForm.Location.Y.ToString() + "\n";
            config += "win_size," + Program.MainForm.Size.Width.ToString() + "," + Program.MainForm.Size.Height.ToString() + "\n";
            File.WriteAllText(FileName, config);
        }

        public static void LoadConfig()
        {
            if (!File.Exists(FileName))
            {
                NetworkManager.WriteInfo("Generating new configuration file");
                SaveConfig();
            }

            string[] config = File.ReadAllLines(FileName);

            for (int i = 0; i < config.Length; i++)
            {
                string[] parts = config[i].Split(',');
                if (parts.Length == 0) { continue; }

                if (parts[0] == "word_wrap")
                {
                    if (parts.Length < 2) { NetworkManager.WriteError("Error parsing word wrap property in configuration file"); return; }
                    WordWrap = bool.Parse(parts[1]);
                    Program.MainForm.SetWordWrap(WordWrap);
                }

                if (parts[0] == "auto_scroll")
                {
                    if (parts.Length < 2) { NetworkManager.WriteError("Error parsing auto scroll property in configuration file"); return; }
                    AutoScroll = bool.Parse(parts[1]);
                    Program.MainForm.SetAutoScroll(AutoScroll);
                }

                if (parts[0] == "win_pos")
                {
                    if (parts.Length < 3) { NetworkManager.WriteError("Error parsing window position property in configuration file"); return; }
                    int x = 0, y = 0;
                    if (!int.TryParse(parts[1], out x)) { NetworkManager.WriteError("Error parsing window X position value in configuration file"); return; }
                    if (!int.TryParse(parts[2], out y)) { NetworkManager.WriteError("Error parsing window Y position value in configuration file"); return; }
                    Program.MainForm.SetDesktopLocation(x, y);
                }

                if (parts[0] == "win_size")
                {
                    if (parts.Length < 3) { NetworkManager.WriteError("Error parsing window size property in configuration file"); return; }
                    int x = 0, y = 0;
                    if (!int.TryParse(parts[1], out x)) { NetworkManager.WriteError("Error parsing window width value in configuration file"); return; }
                    if (!int.TryParse(parts[2], out y)) { NetworkManager.WriteError("Error parsing window height value in configuration file"); return; }
                    Program.MainForm.Size = new Size(x, y);
                }
            }

            NetworkManager.WriteInfo("Loaded configuration file");
        }
    }
}
