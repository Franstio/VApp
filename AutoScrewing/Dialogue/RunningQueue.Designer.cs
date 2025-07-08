namespace AutoScrewing.Dialogue
{
    partial class RunningQueue
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
            dataGridView1 = new DataGridView();
            Scan_ID = new DataGridViewTextBoxColumn();
            Scan_ID2 = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            StartTime = new DataGridViewTextBoxColumn();
            ScrewingStartTime = new DataGridViewTextBoxColumn();
            ScrewingEndTime = new DataGridViewTextBoxColumn();
            LaserStartTime = new DataGridViewTextBoxColumn();
            LaserEndTime = new DataGridViewTextBoxColumn();
            CameraStartTime = new DataGridViewTextBoxColumn();
            CameraEndTime = new DataGridViewTextBoxColumn();
            CHECKSUM = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Scan_ID, Scan_ID2, Status, StartTime, ScrewingStartTime, ScrewingEndTime, LaserStartTime, LaserEndTime, CameraStartTime, CameraEndTime, CHECKSUM });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(1401, 590);
            dataGridView1.TabIndex = 0;
            // 
            // Scan_ID
            // 
            Scan_ID.HeaderText = "Scan_ID";
            Scan_ID.Name = "Scan_ID";
            Scan_ID.ReadOnly = true;
            // 
            // Scan_ID2
            // 
            Scan_ID2.HeaderText = "Scan ID 2";
            Scan_ID2.Name = "Scan_ID2";
            Scan_ID2.ReadOnly = true;
            // 
            // Status
            // 
            Status.HeaderText = "Current Status";
            Status.Name = "Status";
            Status.ReadOnly = true;
            // 
            // StartTime
            // 
            StartTime.HeaderText = "Scan Time";
            StartTime.Name = "StartTime";
            StartTime.ReadOnly = true;
            // 
            // ScrewingStartTime
            // 
            ScrewingStartTime.HeaderText = "Screwing Start Time";
            ScrewingStartTime.Name = "ScrewingStartTime";
            ScrewingStartTime.ReadOnly = true;
            // 
            // ScrewingEndTime
            // 
            ScrewingEndTime.HeaderText = "Screwing End Time";
            ScrewingEndTime.Name = "ScrewingEndTime";
            ScrewingEndTime.ReadOnly = true;
            // 
            // LaserStartTime
            // 
            LaserStartTime.HeaderText = "Laser Start Time";
            LaserStartTime.Name = "LaserStartTime";
            LaserStartTime.ReadOnly = true;
            // 
            // LaserEndTime
            // 
            LaserEndTime.HeaderText = "Laser End Time";
            LaserEndTime.Name = "LaserEndTime";
            LaserEndTime.ReadOnly = true;
            // 
            // CameraStartTime
            // 
            CameraStartTime.HeaderText = "Camera Start Time";
            CameraStartTime.Name = "CameraStartTime";
            CameraStartTime.ReadOnly = true;
            // 
            // CameraEndTime
            // 
            CameraEndTime.HeaderText = "Camera End Time";
            CameraEndTime.Name = "CameraEndTime";
            CameraEndTime.ReadOnly = true;
            // 
            // CHECKSUM
            // 
            CHECKSUM.HeaderText = "Checksum";
            CHECKSUM.Name = "CHECKSUM";
            CHECKSUM.ReadOnly = true;
            // 
            // RunningQueue
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1401, 590);
            Controls.Add(dataGridView1);
            Name = "RunningQueue";
            Text = "RunningQueue";
            FormClosed += RunningQueue_FormClosed;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Scan_ID;
        private DataGridViewTextBoxColumn Scan_ID2;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn StartTime;
        private DataGridViewTextBoxColumn ScrewingStartTime;
        private DataGridViewTextBoxColumn ScrewingEndTime;
        private DataGridViewTextBoxColumn LaserStartTime;
        private DataGridViewTextBoxColumn LaserEndTime;
        private DataGridViewTextBoxColumn CameraStartTime;
        private DataGridViewTextBoxColumn CameraEndTime;
        private DataGridViewTextBoxColumn CHECKSUM;
    }
}