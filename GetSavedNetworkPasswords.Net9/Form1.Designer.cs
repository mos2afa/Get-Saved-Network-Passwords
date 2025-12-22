namespace Get_Saved_Network_Passwords
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            dgvNetworkProfiles = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvNetworkProfiles).BeginInit();
            SuspendLayout();
            // 
            // dgvNetworkProfiles
            // 
            dgvNetworkProfiles.AllowUserToAddRows = false;
            dgvNetworkProfiles.AllowUserToDeleteRows = false;
            dgvNetworkProfiles.AllowUserToOrderColumns = true;
            dgvNetworkProfiles.BackgroundColor = Color.White;
            dgvNetworkProfiles.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            dgvNetworkProfiles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNetworkProfiles.Dock = DockStyle.Fill;
            dgvNetworkProfiles.GridColor = Color.White;
            dgvNetworkProfiles.Location = new Point(0, 0);
            dgvNetworkProfiles.Margin = new Padding(3, 4, 3, 4);
            dgvNetworkProfiles.Name = "dgvNetworkProfiles";
            dgvNetworkProfiles.ReadOnly = true;
            dgvNetworkProfiles.RowHeadersWidth = 51;
            dgvNetworkProfiles.RowTemplate.Height = 24;
            dgvNetworkProfiles.Size = new Size(581, 668);
            dgvNetworkProfiles.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(581, 668);
            Controls.Add(dgvNetworkProfiles);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Network Profiles";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvNetworkProfiles).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNetworkProfiles;
    }
}

