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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            dgvNetworkProfiles = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            copyToolStripMenuItem = new ToolStripMenuItem();
            qRToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvNetworkProfiles).BeginInit();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
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
            dgvNetworkProfiles.ContextMenuStrip = contextMenuStrip1;
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
            // contextMenuStrip1
            // 
            contextMenuStrip1.Font = new Font("Segoe UI", 14F);
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { copyToolStripMenuItem, qRToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(144, 76);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new Size(143, 36);
            copyToolStripMenuItem.Text = "Copy";
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // qRToolStripMenuItem
            // 
            qRToolStripMenuItem.Name = "qRToolStripMenuItem";
            qRToolStripMenuItem.Size = new Size(143, 36);
            qRToolStripMenuItem.Text = "QR";
            qRToolStripMenuItem.Click += qRToolStripMenuItem_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Black;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(324, 367);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.VisibleChanged += pictureBox1_VisibleChanged;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.AutoSize = true;
            button1.BackColor = Color.Red;
            button1.Font = new Font("Segoe UI", 14F);
            button1.ForeColor = Color.White;
            button1.Location = new Point(268, 3);
            button1.Name = "button1";
            button1.Size = new Size(50, 42);
            button1.TabIndex = 2;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(82, 116);
            panel1.Name = "panel1";
            panel1.Size = new Size(324, 367);
            panel1.TabIndex = 3;
            panel1.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.Black;
            ClientSize = new Size(581, 668);
            Controls.Add(panel1);
            Controls.Add(dgvNetworkProfiles);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Network Profiles";
            Load += Form1_Load;
            Shown += Form1_Shown;
            ((System.ComponentModel.ISupportInitialize)dgvNetworkProfiles).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNetworkProfiles;
        private PictureBox pictureBox1;
        private Button button1;
        private Panel panel1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem qRToolStripMenuItem;
    }
}

