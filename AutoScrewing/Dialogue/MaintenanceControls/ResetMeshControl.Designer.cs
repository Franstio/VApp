namespace AutoScrewing.Dialogue.MaintenanceControls
{
    partial class ResetMeshControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel4 = new Panel();
            button1 = new Button();
            inputTable = new TableLayoutPanel();
            inputLabel = new Label();
            panel3 = new Panel();
            pictureBox1 = new PictureBox();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel4.SuspendLayout();
            inputTable.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(inputTable, 0, 0);
            tableLayoutPanel1.Controls.Add(panel2, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(10, 10);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(783, 232);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(tableLayoutPanel2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(394, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(386, 226);
            panel2.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(panel4, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(384, 224);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Controls.Add(button1);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(378, 218);
            panel4.TabIndex = 5;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(16, 185, 129);
            button1.Font = new Font("Sans Serif Collection", 12F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(12, 65);
            button1.Name = "button1";
            button1.Size = new Size(354, 90);
            button1.TabIndex = 6;
            button1.Text = "Trigger Reset Mesh";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // inputTable
            // 
            inputTable.ColumnCount = 2;
            inputTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            inputTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            inputTable.Controls.Add(inputLabel, 0, 0);
            inputTable.Controls.Add(panel3, 1, 0);
            inputTable.Dock = DockStyle.Fill;
            inputTable.Location = new Point(3, 3);
            inputTable.Name = "inputTable";
            inputTable.RowCount = 1;
            inputTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            inputTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            inputTable.Size = new Size(385, 226);
            inputTable.TabIndex = 2;
            // 
            // inputLabel
            // 
            inputLabel.Dock = DockStyle.Fill;
            inputLabel.Font = new Font("Sans Serif Collection", 14.2499981F, FontStyle.Bold);
            inputLabel.ForeColor = Color.FromArgb(31, 41, 55);
            inputLabel.Location = new Point(3, 0);
            inputLabel.Name = "inputLabel";
            inputLabel.Size = new Size(186, 226);
            inputLabel.TabIndex = 4;
            inputLabel.Text = "Input Label";
            inputLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.Controls.Add(pictureBox1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(195, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(187, 220);
            panel3.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Location = new Point(26, 44);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(123, 112);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // ResetMeshControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(tableLayoutPanel1);
            Name = "ResetMeshControl";
            Padding = new Padding(10);
            Size = new Size(803, 252);
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            inputTable.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel4;
        private Button button1;
        private TableLayoutPanel inputTable;
        private Label inputLabel;
        private Panel panel3;
        private PictureBox pictureBox1;
    }
}
