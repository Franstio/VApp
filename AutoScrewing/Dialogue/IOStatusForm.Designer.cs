namespace AutoScrewing.Dialogue
{
    partial class IOStatusForm
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
            groupBox1 = new GroupBox();
            plcStatus = new Label();
            plcLabel = new Label();
            screwingstatus = new Label();
            screwingLabel = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(plcStatus);
            groupBox1.Controls.Add(plcLabel);
            groupBox1.Controls.Add(screwingstatus);
            groupBox1.Controls.Add(screwingLabel);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(440, 104);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "I/O Status";
            // 
            // plcStatus
            // 
            plcStatus.AutoSize = true;
            plcStatus.Font = new Font("Segoe UI", 16F);
            plcStatus.Location = new Point(184, 49);
            plcStatus.Name = "plcStatus";
            plcStatus.Size = new Size(22, 30);
            plcStatus.TabIndex = 3;
            plcStatus.Text = "-";
            // 
            // plcLabel
            // 
            plcLabel.AutoSize = true;
            plcLabel.Font = new Font("Segoe UI", 16F);
            plcLabel.Location = new Point(9, 49);
            plcLabel.Name = "plcLabel";
            plcLabel.Size = new Size(116, 30);
            plcLabel.TabIndex = 2;
            plcLabel.Text = "PLC Status:";
            // 
            // screwingstatus
            // 
            screwingstatus.AutoSize = true;
            screwingstatus.Font = new Font("Segoe UI", 16F);
            screwingstatus.Location = new Point(184, 19);
            screwingstatus.Name = "screwingstatus";
            screwingstatus.Size = new Size(22, 30);
            screwingstatus.TabIndex = 1;
            screwingstatus.Text = "-";
            // 
            // screwingLabel
            // 
            screwingLabel.AutoSize = true;
            screwingLabel.Font = new Font("Segoe UI", 16F);
            screwingLabel.Location = new Point(9, 19);
            screwingLabel.Name = "screwingLabel";
            screwingLabel.Size = new Size(169, 30);
            screwingLabel.TabIndex = 0;
            screwingLabel.Text = "Screwing Status:";
            // 
            // IOStatusForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 128);
            Controls.Add(groupBox1);
            Name = "IOStatusForm";
            Text = "IOStatusForm";
            Load += IOStatusForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label plcStatus;
        private Label plcLabel;
        private Label screwingstatus;
        private Label screwingLabel;
    }
}