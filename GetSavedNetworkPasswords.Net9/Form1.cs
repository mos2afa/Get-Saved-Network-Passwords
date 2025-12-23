using QRCoder;
using System.Diagnostics;
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
            List<NetworkProfile> profiles = Network.GetAllNetworkProfiles();
            dgvNetworkProfiles.DataSource = profiles;

            CustomizeDataGridView();
        }

        private void CustomizeDataGridView()
        {
            dgvNetworkProfiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvNetworkProfiles.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dgvNetworkProfiles.RowHeadersVisible = false;
            dgvNetworkProfiles.EnableHeadersVisualStyles = false;

            dgvNetworkProfiles.Columns[3].Visible = false;


            dgvNetworkProfiles.Font = new Font(dgvNetworkProfiles.Font.FontFamily, 20);

            dgvNetworkProfiles.GridColor = BackColor;
            dgvNetworkProfiles.ForeColor = Color.DodgerBlue;
            dgvNetworkProfiles.BackgroundColor = BackColor;

            dgvNetworkProfiles.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvNetworkProfiles.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;


            dgvNetworkProfiles.ColumnHeadersDefaultCellStyle.BackColor = BackColor;
            dgvNetworkProfiles.ColumnHeadersDefaultCellStyle.ForeColor = Color.DeepPink;

            dgvNetworkProfiles.RowHeadersDefaultCellStyle.BackColor = BackColor;
            dgvNetworkProfiles.RowHeadersDefaultCellStyle.ForeColor = Color.DodgerBlue;

            dgvNetworkProfiles.RowsDefaultCellStyle.BackColor = BackColor;
            dgvNetworkProfiles.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(1, 3, 70);

            ClientSize = new Size(dgvNetworkProfiles.PreferredSize.Width, ClientSize.Height);

            dgvNetworkProfiles.ClearSelection();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void dgvNetworkProfiles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // header

            if (e.ColumnIndex == 0) return;// name

            string SSID = (string)dgvNetworkProfiles.Rows[e.RowIndex].Cells[0].Value!;

            SSID = SSID.Trim();

            NetworkProfile profile = Network.GetNetworkProfile(SSID);

            pictureBox1.Image = QR.GenerateQRImage(profile);
            panel1.Show();
        }

        private void pictureBox1_VisibleChanged(object sender, EventArgs e)
        {
            if (!pictureBox1.Visible)
                pictureBox1.Image?.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Password = (string)dgvNetworkProfiles!.CurrentCell!.Value!;

            Password = Password.Trim();

            if (!string.IsNullOrEmpty(Password))
            {
                Clipboard.SetText(Password);
                MessageBox.Show("Copied To Clipboard", "Success");
            }
        }

        private void qRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string SSID = (string)dgvNetworkProfiles.CurrentRow!.Cells[0].Value!;

            SSID = SSID.Trim();

            NetworkProfile profile = Network.GetNetworkProfile(SSID);

            pictureBox1.Image = QR.GenerateQRImage(profile);
            panel1.Show();
        }
    }

    public class NetworkProfile
    {
        public string? SSID { get; set; }
        public string? Password { get; set; }
        public string? Encryption { get; set; }

        public bool hidden { get; set; }

        public string Hidden { get { return hidden.ToString(); } }

        public NetworkProfile(){}

        public NetworkProfile(string ssid,string password,string encryption ,bool hidden) 
        {
            this.SSID = ssid;
            this.Password = password;
            this.Encryption = encryption;
            this.hidden = hidden;
        }
    }

    public class Network
    {
        static string AllProfilesCommand = "netsh wlan show profiles";

        static string SpecificProfileCommand(string ProfileName)
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

        private static string GetValueAfterColon(string line)
        {
            int index = line.IndexOf(':');
            return index >= 0 ? line[(index + 1)..].Trim() : string.Empty;
        }

        public static NetworkProfile GetNetworkProfile(string ssid)
        {
            NetworkProfile profile = new NetworkProfile
            {
                SSID = ssid
            };

            string command = SpecificProfileCommand(ssid);
            string[] lines = RunCmd(command).Split('\n');

            foreach (string line in lines)
            {
                if (line.Contains("Key Content"))
                {
                    profile.Password = GetValueAfterColon(line);
                }
                else if (line.Contains("Authentication"))
                {
                    profile.Encryption = GetValueAfterColon(line);
                }
                else if (line.Contains("Network broadcast"))
                {
                    profile.hidden = line.Contains("Connect even");
                }
            }

            return profile;
        }


        public static List<NetworkProfile> GetAllNetworkProfiles()
        {
            List<NetworkProfile> profiles = new List<NetworkProfile>();

#if DEBUG
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
#endif

            GetProfilesNames().AsParallel().ForAll(name => profiles.Add(GetNetworkProfile(name)));

#if DEBUG
            stopwatch.Stop();
            MessageBox.Show(stopwatch.Elapsed.ToString());
#endif

            return profiles;
        }

    }



    class QR
    {
        public static Bitmap GenerateQRImage(NetworkProfile networkProfile)
        {
            string wifiString = $"WIFI:T:{networkProfile.Encryption};S:{networkProfile.SSID};P:{networkProfile.Password};H:{networkProfile.hidden.ToString().ToLower()};;";

            var qrGenerator = new QRCodeGenerator();
            var qrData = qrGenerator.CreateQrCode(wifiString, QRCodeGenerator.ECCLevel.M);
            var qrCode = new QRCode(qrData);

            Bitmap qrImage = qrCode.GetGraphic(20);

            return qrImage;
        }
    }
}
