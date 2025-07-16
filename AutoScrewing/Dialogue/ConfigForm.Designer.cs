namespace AutoScrewing.Dialogue
{
    partial class ConfigForm
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
            button1 = new Button();
            plcBox = new TextBox();
            label2 = new Label();
            screwingBox = new ComboBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            outputBox = new TextBox();
            label5 = new Label();
            inputTextBox = new TextBox();
            label4 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            inputfolderdialogue = new FolderBrowserDialog();
            outputfolderdialogue = new FolderBrowserDialog();
            operationBox = new TextBox();
            label6 = new Label();
            urlBox = new TextBox();
            label7 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(plcBox);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(screwingBox);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(397, 164);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "I/O Configuration";
            // 
            // button1
            // 
            button1.Location = new Point(103, 90);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // plcBox
            // 
            plcBox.Location = new Point(103, 61);
            plcBox.Name = "plcBox";
            plcBox.Size = new Size(263, 23);
            plcBox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 64);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 2;
            label2.Text = "PLC IP Address";
            // 
            // screwingBox
            // 
            screwingBox.DropDownStyle = ComboBoxStyle.DropDownList;
            screwingBox.FormattingEnabled = true;
            screwingBox.Location = new Point(103, 25);
            screwingBox.Name = "screwingBox";
            screwingBox.Size = new Size(263, 23);
            screwingBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 28);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 0;
            label1.Text = "Screwing Port";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(operationBox);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(urlBox);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(button4);
            groupBox2.Controls.Add(button3);
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(outputBox);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(inputTextBox);
            groupBox2.Controls.Add(label4);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(3, 173);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(397, 164);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "MESH Config";
            // 
            // button4
            // 
            button4.Location = new Point(313, 107);
            button4.Name = "button4";
            button4.Size = new Size(53, 23);
            button4.TabIndex = 11;
            button4.Text = "...";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(313, 74);
            button3.Name = "button3";
            button3.Size = new Size(53, 23);
            button3.TabIndex = 10;
            button3.Text = "...";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(101, 133);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 5;
            button2.Text = "Save";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // outputBox
            // 
            outputBox.Location = new Point(101, 104);
            outputBox.Name = "outputBox";
            outputBox.ReadOnly = true;
            outputBox.Size = new Size(206, 23);
            outputBox.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(4, 107);
            label5.Name = "label5";
            label5.Size = new Size(72, 15);
            label5.TabIndex = 8;
            label5.Text = "Output Path";
            // 
            // inputTextBox
            // 
            inputTextBox.Location = new Point(101, 75);
            inputTextBox.Name = "inputTextBox";
            inputTextBox.ReadOnly = true;
            inputTextBox.Size = new Size(206, 23);
            inputTextBox.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 78);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 6;
            label4.Text = "Input Path";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(groupBox2, 0, 1);
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(403, 340);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // operationBox
            // 
            operationBox.Location = new Point(103, 51);
            operationBox.Name = "operationBox";
            operationBox.Size = new Size(206, 23);
            operationBox.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 54);
            label6.Name = "label6";
            label6.Size = new Size(74, 15);
            label6.TabIndex = 14;
            label6.Text = "Operation ID";
            // 
            // urlBox
            // 
            urlBox.Location = new Point(103, 22);
            urlBox.Name = "urlBox";
            urlBox.Size = new Size(206, 23);
            urlBox.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(9, 25);
            label7.Name = "label7";
            label7.Size = new Size(57, 15);
            label7.TabIndex = 12;
            label7.Text = "MESH Url";
            // 
            // ConfigForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(403, 340);
            Controls.Add(tableLayoutPanel1);
            Name = "ConfigForm";
            Text = "Config Form";
            Load += ConfigForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private ComboBox screwingBox;
        private Label label1;
        private TextBox plcBox;
        private Button button1;
        private GroupBox groupBox2;
        private Label label4;
        private TextBox meshUrlBox;
        private Label label3;
        private TextBox inputTextBox;
        private TextBox outputBox;
        private Label label5;
        private Button button2;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button4;
        private Button button3;
        private FolderBrowserDialog inputfolderdialogue;
        private FolderBrowserDialog outputfolderdialogue;
        private TextBox operationBox;
        private Label label6;
        private TextBox urlBox;
        private Label label7;
    }
}