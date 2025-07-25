﻿namespace AutoScrewing
{
    partial class DashboardForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tableLayoutPanel1 = new TableLayoutPanel();
            screwingResultLabel = new Label();
            screwingTimeLabel = new Label();
            torqueLabel = new Label();
            laserResultLabel = new Label();
            dataGridView1 = new DataGridView();
            MatLotNo = new DataGridViewTextBoxColumn();
            LotNo = new DataGridViewTextBoxColumn();
            Screwing = new DataGridViewTextBoxColumn();
            Laser = new DataGridViewTextBoxColumn();
            Camera = new DataGridViewTextBoxColumn();
            Judgement = new DataGridViewTextBoxColumn();
            button1 = new Button();
            timeLabel = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel5 = new TableLayoutPanel();
            label3 = new Label();
            panel1 = new Panel();
            tableLayoutPanel3 = new TableLayoutPanel();
            label1 = new Label();
            tableLayoutPanel4 = new TableLayoutPanel();
            label2 = new Label();
            cameraResultLabel = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            timer1 = new System.Windows.Forms.Timer(components);
            menuStrip1 = new MenuStrip();
            configToolStripMenuItem = new ToolStripMenuItem();
            runningQueueToolStripMenuItem = new ToolStripMenuItem();
            statusToolStripMenuItem = new ToolStripMenuItem();
            sampleToolStripMenuItem = new ToolStripMenuItem();
            logToolStripMenuItem = new ToolStripMenuItem();
            manualToolStripMenuItem = new ToolStripMenuItem();
            inputFileWatcher = new FileSystemWatcher();
            tableLayoutPanel6 = new TableLayoutPanel();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            workNumberScanBox = new TextBox();
            scan2Box = new TextBox();
            scan1Box = new TextBox();
            userIdBox = new TextBox();
            label4 = new Label();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)inputFileWatcher).BeginInit();
            tableLayoutPanel6.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(screwingResultLabel, 2, 0);
            tableLayoutPanel1.Controls.Add(screwingTimeLabel, 1, 0);
            tableLayoutPanel1.Controls.Add(torqueLabel, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Bold);
            tableLayoutPanel1.Location = new Point(13, 47);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(498, 187);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // screwingResultLabel
            // 
            screwingResultLabel.Dock = DockStyle.Fill;
            screwingResultLabel.Font = new Font("Sans Serif Collection", 18F, FontStyle.Bold);
            screwingResultLabel.Location = new Point(376, 0);
            screwingResultLabel.Name = "screwingResultLabel";
            screwingResultLabel.Size = new Size(119, 187);
            screwingResultLabel.TabIndex = 3;
            screwingResultLabel.Text = "NG";
            screwingResultLabel.TextAlign = ContentAlignment.MiddleCenter;
            screwingResultLabel.TextChanged += screwingResultLabel_TextChanged;
            screwingResultLabel.Paint += screwingResultLabel_Paint;
            // 
            // screwingTimeLabel
            // 
            screwingTimeLabel.Dock = DockStyle.Fill;
            screwingTimeLabel.Font = new Font("Sans Serif Collection", 14F, FontStyle.Bold);
            screwingTimeLabel.ForeColor = Color.FromArgb(31, 41, 55);
            screwingTimeLabel.Location = new Point(227, 0);
            screwingTimeLabel.Name = "screwingTimeLabel";
            screwingTimeLabel.Size = new Size(143, 187);
            screwingTimeLabel.TabIndex = 2;
            screwingTimeLabel.Text = "000.00 Seconds";
            screwingTimeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // torqueLabel
            // 
            torqueLabel.Dock = DockStyle.Fill;
            torqueLabel.Font = new Font("Sans Serif Collection", 18F, FontStyle.Bold);
            torqueLabel.ForeColor = Color.FromArgb(31, 41, 55);
            torqueLabel.Location = new Point(3, 0);
            torqueLabel.Name = "torqueLabel";
            torqueLabel.Size = new Size(218, 187);
            torqueLabel.TabIndex = 1;
            torqueLabel.Text = "0N";
            torqueLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // laserResultLabel
            // 
            laserResultLabel.Dock = DockStyle.Fill;
            laserResultLabel.Font = new Font("Sans Serif Collection", 36F, FontStyle.Bold);
            laserResultLabel.Location = new Point(13, 44);
            laserResultLabel.Name = "laserResultLabel";
            laserResultLabel.Size = new Size(365, 193);
            laserResultLabel.TabIndex = 0;
            laserResultLabel.Text = "OK";
            laserResultLabel.TextAlign = ContentAlignment.MiddleCenter;
            laserResultLabel.TextChanged += screwingResultLabel_TextChanged;
            laserResultLabel.Paint += screwingResultLabel_Paint;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(229, 231, 235);
            dataGridViewCellStyle1.Font = new Font("Sans Serif Collection", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(31, 41, 55);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { MatLotNo, LotNo, Screwing, Laser, Camera, Judgement });
            tableLayoutPanel2.SetColumnSpan(dataGridView1, 3);
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.GridColor = Color.FromArgb(209, 213, 219);
            dataGridView1.Location = new Point(3, 256);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Sans Serif Collection", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(55, 65, 81);
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Size = new Size(1320, 265);
            dataGridView1.TabIndex = 3;
            // 
            // MatLotNo
            // 
            MatLotNo.HeaderText = "Material Lot No";
            MatLotNo.Name = "MatLotNo";
            MatLotNo.ReadOnly = true;
            // 
            // LotNo
            // 
            LotNo.HeaderText = "Lot No";
            LotNo.Name = "LotNo";
            LotNo.ReadOnly = true;
            // 
            // Screwing
            // 
            Screwing.HeaderText = "Screwing";
            Screwing.Name = "Screwing";
            Screwing.ReadOnly = true;
            // 
            // Laser
            // 
            Laser.HeaderText = "Laser";
            Laser.Name = "Laser";
            Laser.ReadOnly = true;
            // 
            // Camera
            // 
            Camera.HeaderText = "Camera";
            Camera.Name = "Camera";
            Camera.ReadOnly = true;
            // 
            // Judgement
            // 
            Judgement.HeaderText = "Judgement";
            Judgement.Name = "Judgement";
            Judgement.ReadOnly = true;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(59, 130, 246);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Sans Serif Collection", 12F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(231, 49);
            button1.TabIndex = 4;
            button1.Text = "Home";
            button1.UseVisualStyleBackColor = false;
            // 
            // timeLabel
            // 
            timeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            timeLabel.AutoSize = true;
            timeLabel.Font = new Font("Sans Serif Collection", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            timeLabel.ForeColor = Color.FromArgb(107, 114, 128);
            timeLabel.Location = new Point(1202, 30);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(133, 37);
            timeLabel.TabIndex = 6;
            timeLabel.Text = "00:00 00.00";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel5, 1, 0);
            tableLayoutPanel2.Controls.Add(dataGridView1, 0, 1);
            tableLayoutPanel2.Controls.Add(panel1, 0, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 2, 0);
            tableLayoutPanel2.Controls.Add(flowLayoutPanel1, 0, 2);
            tableLayoutPanel2.Location = new Point(12, 97);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 43F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 46F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 11F));
            tableLayoutPanel2.Size = new Size(1326, 590);
            tableLayoutPanel2.TabIndex = 7;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.BackColor = Color.White;
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Controls.Add(laserResultLabel, 0, 1);
            tableLayoutPanel5.Controls.Add(label3, 0, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(533, 3);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.Padding = new Padding(10);
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 85F));
            tableLayoutPanel5.Size = new Size(391, 247);
            tableLayoutPanel5.TabIndex = 6;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Sans Serif Collection", 14.2499981F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(31, 41, 55);
            label3.Location = new Point(13, 10);
            label3.Name = "label3";
            label3.Size = new Size(365, 34);
            label3.TabIndex = 2;
            label3.Text = "SENSOR LASER";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(tableLayoutPanel3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(524, 247);
            panel1.TabIndex = 4;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(tableLayoutPanel1, 0, 1);
            tableLayoutPanel3.Controls.Add(label1, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.Padding = new Padding(10);
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 85F));
            tableLayoutPanel3.Size = new Size(524, 247);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Sans Serif Collection", 14.2499981F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(31, 41, 55);
            label1.Location = new Point(13, 10);
            label1.Name = "label1";
            label1.Size = new Size(498, 34);
            label1.TabIndex = 0;
            label1.Text = "SCREWING";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.BackColor = Color.White;
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(label2, 0, 0);
            tableLayoutPanel4.Controls.Add(cameraResultLabel, 0, 1);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(930, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.Padding = new Padding(10);
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 85F));
            tableLayoutPanel4.Size = new Size(393, 247);
            tableLayoutPanel4.TabIndex = 5;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Sans Serif Collection", 14.2499981F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(31, 41, 55);
            label2.Location = new Point(13, 10);
            label2.Name = "label2";
            label2.Size = new Size(367, 34);
            label2.TabIndex = 2;
            label2.Text = "CAMERA";
            // 
            // cameraResultLabel
            // 
            cameraResultLabel.Dock = DockStyle.Fill;
            cameraResultLabel.Font = new Font("Sans Serif Collection", 36F, FontStyle.Bold);
            cameraResultLabel.Location = new Point(13, 44);
            cameraResultLabel.Name = "cameraResultLabel";
            cameraResultLabel.Size = new Size(367, 193);
            cameraResultLabel.TabIndex = 1;
            cameraResultLabel.Text = "NG";
            cameraResultLabel.TextAlign = ContentAlignment.MiddleCenter;
            cameraResultLabel.TextChanged += screwingResultLabel_TextChanged;
            cameraResultLabel.Paint += screwingResultLabel_Paint;
            // 
            // flowLayoutPanel1
            // 
            tableLayoutPanel2.SetColumnSpan(flowLayoutPanel1, 3);
            flowLayoutPanel1.Controls.Add(button1);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 527);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1320, 60);
            flowLayoutPanel1.TabIndex = 7;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 900;
            timer1.Tick += timer1_Tick;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(30, 58, 138);
            menuStrip1.Items.AddRange(new ToolStripItem[] { configToolStripMenuItem, runningQueueToolStripMenuItem, statusToolStripMenuItem, sampleToolStripMenuItem, logToolStripMenuItem, manualToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1347, 24);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";
            // 
            // configToolStripMenuItem
            // 
            configToolStripMenuItem.ForeColor = Color.FromArgb(249, 250, 251);
            configToolStripMenuItem.Name = "configToolStripMenuItem";
            configToolStripMenuItem.Size = new Size(55, 20);
            configToolStripMenuItem.Text = "Config";
            configToolStripMenuItem.Click += configToolStripMenuItem_Click;
            // 
            // runningQueueToolStripMenuItem
            // 
            runningQueueToolStripMenuItem.ForeColor = Color.FromArgb(249, 250, 251);
            runningQueueToolStripMenuItem.Name = "runningQueueToolStripMenuItem";
            runningQueueToolStripMenuItem.Size = new Size(102, 20);
            runningQueueToolStripMenuItem.Text = "Running Queue";
            runningQueueToolStripMenuItem.Click += runningQueueToolStripMenuItem_Click;
            // 
            // statusToolStripMenuItem
            // 
            statusToolStripMenuItem.ForeColor = Color.FromArgb(249, 250, 251);
            statusToolStripMenuItem.Name = "statusToolStripMenuItem";
            statusToolStripMenuItem.Size = new Size(51, 20);
            statusToolStripMenuItem.Text = "Status";
            statusToolStripMenuItem.Click += statusToolStripMenuItem_Click;
            // 
            // sampleToolStripMenuItem
            // 
            sampleToolStripMenuItem.ForeColor = Color.FromArgb(249, 250, 251);
            sampleToolStripMenuItem.Name = "sampleToolStripMenuItem";
            sampleToolStripMenuItem.Size = new Size(58, 20);
            sampleToolStripMenuItem.Text = "Sample";
            sampleToolStripMenuItem.Click += sampleToolStripMenuItem_Click;
            // 
            // logToolStripMenuItem
            // 
            logToolStripMenuItem.ForeColor = Color.FromArgb(249, 250, 251);
            logToolStripMenuItem.Name = "logToolStripMenuItem";
            logToolStripMenuItem.Size = new Size(39, 20);
            logToolStripMenuItem.Text = "Log";
            logToolStripMenuItem.Click += logToolStripMenuItem_Click;
            // 
            // manualToolStripMenuItem
            // 
            manualToolStripMenuItem.ForeColor = Color.FromArgb(249, 250, 251);
            manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            manualToolStripMenuItem.Size = new Size(59, 20);
            manualToolStripMenuItem.Text = "Manual";
            manualToolStripMenuItem.Click += manualToolStripMenuItem_Click;
            // 
            // inputFileWatcher
            // 
            inputFileWatcher.EnableRaisingEvents = true;
            inputFileWatcher.NotifyFilter = NotifyFilters.FileName;
            inputFileWatcher.SynchronizingObject = this;
            inputFileWatcher.Created += inputFileWatcher_Changed;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel6.ColumnCount = 4;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel6.Controls.Add(label7, 3, 0);
            tableLayoutPanel6.Controls.Add(label6, 2, 0);
            tableLayoutPanel6.Controls.Add(label5, 1, 0);
            tableLayoutPanel6.Controls.Add(workNumberScanBox, 0, 1);
            tableLayoutPanel6.Controls.Add(scan2Box, 3, 1);
            tableLayoutPanel6.Controls.Add(scan1Box, 2, 1);
            tableLayoutPanel6.Controls.Add(userIdBox, 1, 1);
            tableLayoutPanel6.Controls.Add(label4, 0, 0);
            tableLayoutPanel6.Location = new Point(12, 27);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 2;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 75F));
            tableLayoutPanel6.Size = new Size(1076, 64);
            tableLayoutPanel6.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Location = new Point(810, 0);
            label7.Name = "label7";
            label7.Size = new Size(263, 16);
            label7.TabIndex = 17;
            label7.Text = "Scan Work Number";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Location = new Point(541, 0);
            label6.Name = "label6";
            label6.Size = new Size(263, 16);
            label6.TabIndex = 16;
            label6.Text = "Scan Operation Material Lot:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(272, 0);
            label5.Name = "label5";
            label5.Size = new Size(263, 16);
            label5.TabIndex = 15;
            label5.Text = "Scan Operation User SN:";
            // 
            // workNumberScanBox
            // 
            workNumberScanBox.Dock = DockStyle.Fill;
            workNumberScanBox.Font = new Font("Sans Serif Collection", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            workNumberScanBox.Location = new Point(3, 19);
            workNumberScanBox.Name = "workNumberScanBox";
            workNumberScanBox.Size = new Size(263, 39);
            workNumberScanBox.TabIndex = 13;
            workNumberScanBox.Tag = "Scan Work Order Number";
            workNumberScanBox.TextAlign = HorizontalAlignment.Center;
            workNumberScanBox.KeyPress += textBox1_KeyPress;
            // 
            // scan2Box
            // 
            scan2Box.Dock = DockStyle.Fill;
            scan2Box.Font = new Font("Sans Serif Collection", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            scan2Box.Location = new Point(810, 19);
            scan2Box.Name = "scan2Box";
            scan2Box.Size = new Size(263, 39);
            scan2Box.TabIndex = 12;
            scan2Box.Tag = "Scan Operation LotNo...";
            scan2Box.TextAlign = HorizontalAlignment.Center;
            scan2Box.KeyPress += scan2Box_KeyPress;
            // 
            // scan1Box
            // 
            scan1Box.Dock = DockStyle.Fill;
            scan1Box.Font = new Font("Sans Serif Collection", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            scan1Box.Location = new Point(541, 19);
            scan1Box.Name = "scan1Box";
            scan1Box.Size = new Size(263, 39);
            scan1Box.TabIndex = 11;
            scan1Box.Tag = "Scan Operation MaterialLotNo'";
            scan1Box.TextAlign = HorizontalAlignment.Center;
            scan1Box.KeyPress += scan1Box_KeyPress;
            // 
            // userIdBox
            // 
            userIdBox.Dock = DockStyle.Fill;
            userIdBox.Font = new Font("Sans Serif Collection", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            userIdBox.Location = new Point(272, 19);
            userIdBox.Name = "userIdBox";
            userIdBox.Size = new Size(263, 39);
            userIdBox.TabIndex = 10;
            userIdBox.Tag = "Scan Operation User SN...";
            userIdBox.TextAlign = HorizontalAlignment.Center;
            userIdBox.KeyPress += userIdBox_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(263, 16);
            label4.TabIndex = 14;
            label4.Text = "Scan Work Number:";
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 246, 248);
            ClientSize = new Size(1347, 711);
            Controls.Add(tableLayoutPanel6);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(timeLabel);
            Controls.Add(menuStrip1);
            ForeColor = Color.FromArgb(31, 41, 55);
            MainMenuStrip = menuStrip1;
            Name = "DashboardForm";
            Text = "Dashboard";
            WindowState = FormWindowState.Maximized;
            Load += DashboardForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)inputFileWatcher).EndInit();
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel1;
        private Label screwingTimeLabel;
        private Label torqueLabel;
        private Label laserResultLabel;
        private DataGridView dataGridView1;
        private Button button1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label timeLabel;
        private System.Windows.Forms.Timer timer1;
        private Label screwingResultLabel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem configToolStripMenuItem;
        private FileSystemWatcher inputFileWatcher;
        private ToolStripMenuItem runningQueueToolStripMenuItem;
        private ToolStripMenuItem statusToolStripMenuItem;
        private ToolStripMenuItem sampleToolStripMenuItem;
        private ToolStripMenuItem logToolStripMenuItem;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel4;
        private Label cameraResultLabel;
        private TableLayoutPanel tableLayoutPanel5;
        private Label label3;
        private Label label2;
        private FlowLayoutPanel flowLayoutPanel1;
        private ToolStripMenuItem manualToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel6;
        private TextBox userIdBox;
        private TextBox scan2Box;
        private TextBox scan1Box;
        private TextBox workNumberScanBox;
        private DataGridViewTextBoxColumn MatLotNo;
        private DataGridViewTextBoxColumn LotNo;
        private DataGridViewTextBoxColumn Screwing;
        private DataGridViewTextBoxColumn Laser;
        private DataGridViewTextBoxColumn Camera;
        private DataGridViewTextBoxColumn Judgement;
        private Label label4;
        private Label label7;
        private Label label6;
        private Label label5;
    }
}