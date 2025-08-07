namespace AutoScrewing.Dialogue
{
    partial class TransactionForm
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
            button3 = new Button();
            button2 = new Button();
            label4 = new Label();
            label3 = new Label();
            button1 = new Button();
            toBox = new DateTimePicker();
            fromBox = new DateTimePicker();
            groupBox2 = new GroupBox();
            numericUpDown1 = new NumericUpDown();
            button5 = new Button();
            button4 = new Button();
            dataGridView1 = new DataGridView();
            scanIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            scanID2DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            torqueDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            screwingResultDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            laserResultDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            cameraResultDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            resultDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            isErrorDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            finalResultDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            screwingTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            threadCountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            errorDescDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tighteningStatusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            transactionTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            operationUserSNDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            operationIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            workNumberDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            transactionModelBindingSource = new BindingSource(components);
            logModelBindingSource = new BindingSource(components);
            saveFileDialog1 = new SaveFileDialog();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)transactionModelBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logModelBindingSource).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(toBox);
            groupBox1.Controls.Add(fromBox);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(383, 655);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filter";
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button3.Enabled = false;
            button3.Location = new Point(6, 597);
            button3.Name = "button3";
            button3.Size = new Size(371, 52);
            button3.TabIndex = 10;
            button3.Text = "Clear Transaction";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button2.Location = new Point(6, 57);
            button2.Name = "button2";
            button2.Size = new Size(371, 52);
            button2.TabIndex = 9;
            button2.Text = "Filter";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(207, 32);
            label4.Name = "label4";
            label4.Size = new Size(19, 15);
            label4.TabIndex = 8;
            label4.Text = "To";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 32);
            label3.Name = "label3";
            label3.Size = new Size(35, 15);
            label3.TabIndex = 7;
            label3.Text = "From";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button1.Enabled = false;
            button1.Location = new Point(6, 115);
            button1.Name = "button1";
            button1.Size = new Size(371, 52);
            button1.TabIndex = 4;
            button1.Text = "Download";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // toBox
            // 
            toBox.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            toBox.Format = DateTimePickerFormat.Custom;
            toBox.Location = new Point(232, 28);
            toBox.Name = "toBox";
            toBox.Size = new Size(145, 23);
            toBox.TabIndex = 3;
            toBox.ValueChanged += fromBox_ValueChanged;
            // 
            // fromBox
            // 
            fromBox.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            fromBox.Format = DateTimePickerFormat.Custom;
            fromBox.Location = new Point(62, 28);
            fromBox.Name = "fromBox";
            fromBox.Size = new Size(128, 23);
            fromBox.TabIndex = 2;
            fromBox.ValueChanged += fromBox_ValueChanged;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(numericUpDown1);
            groupBox2.Controls.Add(button5);
            groupBox2.Controls.Add(button4);
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Location = new Point(401, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1046, 655);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Log Data";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Anchor = AnchorStyles.Bottom;
            numericUpDown1.Enabled = false;
            numericUpDown1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            numericUpDown1.Location = new Point(527, 602);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 35);
            numericUpDown1.TabIndex = 3;
            numericUpDown1.TextAlign = HorizontalAlignment.Center;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Bottom;
            button5.Enabled = false;
            button5.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.Location = new Point(653, 593);
            button5.Name = "button5";
            button5.Size = new Size(199, 52);
            button5.TabIndex = 2;
            button5.Text = "Next";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Bottom;
            button4.Enabled = false;
            button4.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(322, 593);
            button4.Name = "button4";
            button4.Size = new Size(199, 52);
            button4.TabIndex = 1;
            button4.Text = "Prev";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { scanIDDataGridViewTextBoxColumn, scanID2DataGridViewTextBoxColumn, torqueDataGridViewTextBoxColumn, screwingResultDataGridViewCheckBoxColumn, laserResultDataGridViewCheckBoxColumn, cameraResultDataGridViewCheckBoxColumn, resultDataGridViewCheckBoxColumn, isErrorDataGridViewCheckBoxColumn, finalResultDataGridViewTextBoxColumn, screwingTimeDataGridViewTextBoxColumn, threadCountDataGridViewTextBoxColumn, errorDescDataGridViewTextBoxColumn, tighteningStatusDataGridViewTextBoxColumn, transactionTimeDataGridViewTextBoxColumn, operationUserSNDataGridViewTextBoxColumn, operationIdDataGridViewTextBoxColumn, workNumberDataGridViewTextBoxColumn });
            dataGridView1.DataSource = transactionModelBindingSource;
            dataGridView1.Location = new Point(3, 19);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(1040, 556);
            dataGridView1.TabIndex = 0;
            // 
            // scanIDDataGridViewTextBoxColumn
            // 
            scanIDDataGridViewTextBoxColumn.DataPropertyName = "Scan_ID";
            scanIDDataGridViewTextBoxColumn.HeaderText = "Serial Number Material";
            scanIDDataGridViewTextBoxColumn.Name = "scanIDDataGridViewTextBoxColumn";
            scanIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // scanID2DataGridViewTextBoxColumn
            // 
            scanID2DataGridViewTextBoxColumn.DataPropertyName = "Scan_ID2";
            scanID2DataGridViewTextBoxColumn.HeaderText = " Serial Number Product";
            scanID2DataGridViewTextBoxColumn.Name = "scanID2DataGridViewTextBoxColumn";
            scanID2DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // torqueDataGridViewTextBoxColumn
            // 
            torqueDataGridViewTextBoxColumn.DataPropertyName = "Torque";
            torqueDataGridViewTextBoxColumn.HeaderText = "Torque";
            torqueDataGridViewTextBoxColumn.Name = "torqueDataGridViewTextBoxColumn";
            torqueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // screwingResultDataGridViewCheckBoxColumn
            // 
            screwingResultDataGridViewCheckBoxColumn.DataPropertyName = "ScrewingResult";
            screwingResultDataGridViewCheckBoxColumn.FalseValue = "NG";
            screwingResultDataGridViewCheckBoxColumn.HeaderText = "Screwing Result";
            screwingResultDataGridViewCheckBoxColumn.Name = "screwingResultDataGridViewCheckBoxColumn";
            screwingResultDataGridViewCheckBoxColumn.ReadOnly = true;
            screwingResultDataGridViewCheckBoxColumn.TrueValue = "OK";
            // 
            // laserResultDataGridViewCheckBoxColumn
            // 
            laserResultDataGridViewCheckBoxColumn.DataPropertyName = "LaserResult";
            laserResultDataGridViewCheckBoxColumn.FalseValue = "NG";
            laserResultDataGridViewCheckBoxColumn.HeaderText = "Laser Result";
            laserResultDataGridViewCheckBoxColumn.Name = "laserResultDataGridViewCheckBoxColumn";
            laserResultDataGridViewCheckBoxColumn.ReadOnly = true;
            laserResultDataGridViewCheckBoxColumn.TrueValue = "OK";
            // 
            // cameraResultDataGridViewCheckBoxColumn
            // 
            cameraResultDataGridViewCheckBoxColumn.DataPropertyName = "CameraResult";
            cameraResultDataGridViewCheckBoxColumn.FalseValue = "NG";
            cameraResultDataGridViewCheckBoxColumn.HeaderText = "Camera Result";
            cameraResultDataGridViewCheckBoxColumn.Name = "cameraResultDataGridViewCheckBoxColumn";
            cameraResultDataGridViewCheckBoxColumn.ReadOnly = true;
            cameraResultDataGridViewCheckBoxColumn.TrueValue = "OK";
            // 
            // resultDataGridViewCheckBoxColumn
            // 
            resultDataGridViewCheckBoxColumn.DataPropertyName = "Result";
            resultDataGridViewCheckBoxColumn.HeaderText = "Result";
            resultDataGridViewCheckBoxColumn.Name = "resultDataGridViewCheckBoxColumn";
            resultDataGridViewCheckBoxColumn.ReadOnly = true;
            resultDataGridViewCheckBoxColumn.Visible = false;
            // 
            // isErrorDataGridViewCheckBoxColumn
            // 
            isErrorDataGridViewCheckBoxColumn.DataPropertyName = "IsError";
            isErrorDataGridViewCheckBoxColumn.HeaderText = "IsError";
            isErrorDataGridViewCheckBoxColumn.Name = "isErrorDataGridViewCheckBoxColumn";
            isErrorDataGridViewCheckBoxColumn.ReadOnly = true;
            isErrorDataGridViewCheckBoxColumn.Visible = false;
            // 
            // finalResultDataGridViewTextBoxColumn
            // 
            finalResultDataGridViewTextBoxColumn.DataPropertyName = "FinalResult";
            finalResultDataGridViewTextBoxColumn.HeaderText = "Judgement";
            finalResultDataGridViewTextBoxColumn.Name = "finalResultDataGridViewTextBoxColumn";
            finalResultDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // screwingTimeDataGridViewTextBoxColumn
            // 
            screwingTimeDataGridViewTextBoxColumn.DataPropertyName = "ScrewingTime";
            screwingTimeDataGridViewTextBoxColumn.HeaderText = "Screwing Time";
            screwingTimeDataGridViewTextBoxColumn.Name = "screwingTimeDataGridViewTextBoxColumn";
            screwingTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // threadCountDataGridViewTextBoxColumn
            // 
            threadCountDataGridViewTextBoxColumn.DataPropertyName = "ThreadCount";
            threadCountDataGridViewTextBoxColumn.HeaderText = "Thread Count";
            threadCountDataGridViewTextBoxColumn.Name = "threadCountDataGridViewTextBoxColumn";
            threadCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // errorDescDataGridViewTextBoxColumn
            // 
            errorDescDataGridViewTextBoxColumn.DataPropertyName = "ErrorDesc";
            errorDescDataGridViewTextBoxColumn.HeaderText = "ErrorDesc";
            errorDescDataGridViewTextBoxColumn.Name = "errorDescDataGridViewTextBoxColumn";
            errorDescDataGridViewTextBoxColumn.ReadOnly = true;
            errorDescDataGridViewTextBoxColumn.Visible = false;
            // 
            // tighteningStatusDataGridViewTextBoxColumn
            // 
            tighteningStatusDataGridViewTextBoxColumn.DataPropertyName = "TighteningStatus";
            tighteningStatusDataGridViewTextBoxColumn.HeaderText = "Tightening Status";
            tighteningStatusDataGridViewTextBoxColumn.Name = "tighteningStatusDataGridViewTextBoxColumn";
            tighteningStatusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // transactionTimeDataGridViewTextBoxColumn
            // 
            transactionTimeDataGridViewTextBoxColumn.DataPropertyName = "TransactionTime";
            transactionTimeDataGridViewTextBoxColumn.HeaderText = "Transaction Time";
            transactionTimeDataGridViewTextBoxColumn.Name = "transactionTimeDataGridViewTextBoxColumn";
            transactionTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // operationUserSNDataGridViewTextBoxColumn
            // 
            operationUserSNDataGridViewTextBoxColumn.DataPropertyName = "OperationUserSN";
            operationUserSNDataGridViewTextBoxColumn.HeaderText = "Operation User SN";
            operationUserSNDataGridViewTextBoxColumn.Name = "operationUserSNDataGridViewTextBoxColumn";
            operationUserSNDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // operationIdDataGridViewTextBoxColumn
            // 
            operationIdDataGridViewTextBoxColumn.DataPropertyName = "OperationId";
            operationIdDataGridViewTextBoxColumn.HeaderText = "OperationId";
            operationIdDataGridViewTextBoxColumn.Name = "operationIdDataGridViewTextBoxColumn";
            operationIdDataGridViewTextBoxColumn.ReadOnly = true;
            operationIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // workNumberDataGridViewTextBoxColumn
            // 
            workNumberDataGridViewTextBoxColumn.DataPropertyName = "WorkNumber";
            workNumberDataGridViewTextBoxColumn.HeaderText = "Work Number";
            workNumberDataGridViewTextBoxColumn.Name = "workNumberDataGridViewTextBoxColumn";
            workNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // transactionModelBindingSource
            // 
            transactionModelBindingSource.DataSource = typeof(Database.Models.TransactionModel);
            // 
            // logModelBindingSource
            // 
            logModelBindingSource.DataSource = typeof(Database.Models.LogModel);
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Title = "Download Log Data";
            // 
            // TransactionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1459, 679);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "TransactionForm";
            Text = "Transaction Form";
            Load += LogForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)transactionModelBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)logModelBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button button1;
        private DateTimePicker toBox;
        private DateTimePicker fromBox;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private Label label4;
        private Label label3;
        private DataGridViewTextBoxColumn logIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn recordTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn logTypeDataGridViewTextBoxColumn;
        private BindingSource logModelBindingSource;
        private SaveFileDialog saveFileDialog1;
        private Button button2;
        private Button button3;
        private BindingSource transactionModelBindingSource;
        private NumericUpDown numericUpDown1;
        private Button button5;
        private Button button4;
        private DataGridViewTextBoxColumn scanIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn scanID2DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn torqueDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn screwingResultDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn laserResultDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn cameraResultDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn resultDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn isErrorDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn finalResultDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn screwingTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn threadCountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn errorDescDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tighteningStatusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn transactionTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn operationUserSNDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn operationIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn workNumberDataGridViewTextBoxColumn;
    }
}