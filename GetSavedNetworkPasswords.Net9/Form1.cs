using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Get_Saved_Network_Passwords
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvNetworkProfiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvNetworkProfiles.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            List<Network.Profile> profiles = Network.GetNetworkProfiles();
            dgvNetworkProfiles.DataSource = profiles;

            dgvNetworkProfiles.Font = new Font(dgvNetworkProfiles.Font.FontFamily, 16);

        }
    }

    public class Network
    {
        static string AllProfilesCommand = "netsh wlan show profiles";

        static string SpecificPasswordCommand(string ProfileName)
        {
            return $"netsh wlan show profile name=\"{ProfileName}\" key=clear";
        }


        static string RunCmd(string command)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c " + command,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = new Process { StartInfo = psi })
            {
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                process.WaitForExit();

                if (!string.IsNullOrEmpty(error))
                    return error;

                return output;
            }
        }


        public class Profile
        {
            public string? Name { get; set; }
            public string? Password { get; set; }
        }


        static List<string> GetProfilesNames()
        {
            List<string> names = new List<string>();

            string[] profileNames = RunCmd(AllProfilesCommand).Split('\n');
            foreach (string Name in profileNames)
            {
                if (Name.Contains("All User Profile"))
                {
                    int nameStartIndex = Name.IndexOf(':') + 2;

                    names.Add(Name.Substring(nameStartIndex));
                }
            }
            return names;
        }

        static string GetProfilePassword(string profileName)
        {
            string Password = "";

            string Command = SpecificPasswordCommand(profileName);
            string[] Result = RunCmd(Command).Split('\n');

            foreach (string Name in Result)
            {
                if (Name.Contains("Key Content"))
                {
                    int nameStartIndex = Name.IndexOf(':') + 2;

                    Password = Name.Substring(nameStartIndex);
                }
            }

            return Password;
        }

        public static List<Profile> GetNetworkProfiles()
        {
            List<Profile> profiles = new List<Profile>(); 
            
            foreach(string name in GetProfilesNames())
            {
                Profile profile = new Profile();

                profile.Name = name;
                profile.Password = GetProfilePassword(name);

                profiles.Add(profile);
            }

            return profiles;
        }

    }


}
