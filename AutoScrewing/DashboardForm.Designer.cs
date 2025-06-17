namespace AutoScrewing
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
            groupBox1 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            screwingResultLabel = new Label();
            torqueLabel = new Label();
            groupBox2 = new GroupBox();
            sensorResultLabel = new Label();
            groupBox3 = new GroupBox();
            cameraResultLabel = new Label();
            dataGridView1 = new DataGridView();
            Serial = new DataGridViewTextBoxColumn();
            Screwing = new DataGridViewTextBoxColumn();
            Laser = new DataGridViewTextBoxColumn();
            Camera = new DataGridViewTextBoxColumn();
            Judgement = new DataGridViewTextBoxColumn();
            button1 = new Button();
            textBox1 = new TextBox();
            timeLabel = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            timer1 = new System.Windows.Forms.Timer(components);
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tableLayoutPanel1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Consolas", 24F, FontStyle.Bold);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(10);
            groupBox1.Size = new Size(431, 201);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Screwing";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.Controls.Add(screwingResultLabel, 1, 0);
            tableLayoutPanel1.Controls.Add(torqueLabel, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(10, 48);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(411, 143);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // screwingResultLabel
            // 
            screwingResultLabel.Dock = DockStyle.Fill;
            screwingResultLabel.Location = new Point(249, 0);
            screwingResultLabel.Name = "screwingResultLabel";
            screwingResultLabel.Size = new Size(159, 143);
            screwingResultLabel.TabIndex = 2;
            screwingResultLabel.Text = "OK/NG";
            screwingResultLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // torqueLabel
            // 
            torqueLabel.Dock = DockStyle.Fill;
            torqueLabel.Location = new Point(3, 0);
            torqueLabel.Name = "torqueLabel";
            torqueLabel.Size = new Size(240, 143);
            torqueLabel.TabIndex = 1;
            torqueLabel.Text = "0N";
            torqueLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(sensorResultLabel);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Font = new Font("Consolas", 24F, FontStyle.Bold);
            groupBox2.Location = new Point(440, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(10);
            groupBox2.Size = new Size(322, 201);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Sensor Laser";
            // 
            // sensorResultLabel
            // 
            sensorResultLabel.Dock = DockStyle.Fill;
            sensorResultLabel.Location = new Point(10, 48);
            sensorResultLabel.Name = "sensorResultLabel";
            sensorResultLabel.Size = new Size(302, 143);
            sensorResultLabel.TabIndex = 0;
            sensorResultLabel.Text = "OK/NG";
            sensorResultLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(cameraResultLabel);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Font = new Font("Consolas", 24F, FontStyle.Bold);
            groupBox3.Location = new Point(768, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(10);
            groupBox3.Size = new Size(323, 201);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Camera";
            // 
            // cameraResultLabel
            // 
            cameraResultLabel.Dock = DockStyle.Fill;
            cameraResultLabel.Location = new Point(10, 48);
            cameraResultLabel.Name = "cameraResultLabel";
            cameraResultLabel.Size = new Size(303, 143);
            cameraResultLabel.TabIndex = 1;
            cameraResultLabel.Text = "OK/NG";
            cameraResultLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Serial, Screwing, Laser, Camera, Judgement });
            tableLayoutPanel2.SetColumnSpan(dataGridView1, 3);
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 210);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1088, 201);
            dataGridView1.TabIndex = 3;
            // 
            // Serial
            // 
            Serial.HeaderText = "Serial";
            Serial.Name = "Serial";
            Serial.ReadOnly = true;
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
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            button1.Location = new Point(12, 494);
            button1.Name = "button1";
            button1.Size = new Size(281, 53);
            button1.TabIndex = 4;
            button1.Text = "Home";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Segoe UI", 18F);
            textBox1.Location = new Point(12, 29);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(399, 39);
            textBox1.TabIndex = 5;
            textBox1.Text = "Scan";
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // timeLabel
            // 
            timeLabel.AutoSize = true;
            timeLabel.Font = new Font("Segoe UI", 18F);
            timeLabel.Location = new Point(720, 29);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(135, 32);
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
            tableLayoutPanel2.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel2.Controls.Add(dataGridView1, 0, 1);
            tableLayoutPanel2.Controls.Add(groupBox2, 1, 0);
            tableLayoutPanel2.Controls.Add(groupBox3, 2, 0);
            tableLayoutPanel2.Location = new Point(12, 74);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(1094, 414);
            tableLayoutPanel2.TabIndex = 7;
            // 
            // timer1
            // 
            timer1.Interval = 900;
            timer1.Tick += timer1_Tick;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1118, 559);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(timeLabel);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "DashboardForm";
            Text = "Dashboard";
            Load += DashboardForm_Load;
            groupBox1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label screwingResultLabel;
        private Label torqueLabel;
        private GroupBox groupBox2;
        private Label sensorResultLabel;
        private GroupBox groupBox3;
        private Label cameraResultLabel;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Serial;
        private DataGridViewTextBoxColumn Screwing;
        private DataGridViewTextBoxColumn Laser;
        private DataGridViewTextBoxColumn Camera;
        private DataGridViewTextBoxColumn Judgement;
        private Button button1;
        private TextBox textBox1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label timeLabel;
        private System.Windows.Forms.Timer timer1;
    }
}