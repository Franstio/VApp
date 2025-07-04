namespace AutoScrewing.Dialogue
{
    partial class LogForm
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
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            toBox = new DateTimePicker();
            fromBox = new DateTimePicker();
            searchBox = new TextBox();
            logTypeBox = new ComboBox();
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            logidDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            recordtimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            logtypeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            sourceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            statusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            payloadDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            resultDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            logModelBindingSource = new BindingSource(components);
            saveFileDialog1 = new SaveFileDialog();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logModelBindingSource).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(toBox);
            groupBox1.Controls.Add(fromBox);
            groupBox1.Controls.Add(searchBox);
            groupBox1.Controls.Add(logTypeBox);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(383, 696);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filter";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(207, 122);
            label4.Name = "label4";
            label4.Size = new Size(19, 15);
            label4.TabIndex = 8;
            label4.Text = "To";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 122);
            label3.Name = "label3";
            label3.Size = new Size(35, 15);
            label3.TabIndex = 7;
            label3.Text = "From";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 83);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 6;
            label2.Text = "Log Type";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 54);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 5;
            label1.Text = "Search";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button1.Location = new Point(6, 147);
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
            toBox.Location = new Point(232, 118);
            toBox.Name = "toBox";
            toBox.Size = new Size(145, 23);
            toBox.TabIndex = 3;
            toBox.ValueChanged += fromBox_ValueChanged;
            // 
            // fromBox
            // 
            fromBox.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            fromBox.Format = DateTimePickerFormat.Custom;
            fromBox.Location = new Point(62, 118);
            fromBox.Name = "fromBox";
            fromBox.Size = new Size(128, 23);
            fromBox.TabIndex = 2;
            fromBox.ValueChanged += fromBox_ValueChanged;
            // 
            // searchBox
            // 
            searchBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            searchBox.Location = new Point(62, 51);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(315, 23);
            searchBox.TabIndex = 1;
            searchBox.TextChanged += searchBox_TextChanged;
            // 
            // logTypeBox
            // 
            logTypeBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            logTypeBox.FormattingEnabled = true;
            logTypeBox.Location = new Point(62, 80);
            logTypeBox.Name = "logTypeBox";
            logTypeBox.Size = new Size(315, 23);
            logTypeBox.TabIndex = 0;
            logTypeBox.SelectedValueChanged += logTypeBox_SelectedValueChanged;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Location = new Point(401, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1081, 696);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Log Data";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { logidDataGridViewTextBoxColumn, recordtimeDataGridViewTextBoxColumn, logtypeDataGridViewTextBoxColumn, sourceDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn, statusDataGridViewTextBoxColumn, payloadDataGridViewTextBoxColumn, resultDataGridViewTextBoxColumn });
            dataGridView1.DataSource = logModelBindingSource;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 19);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(1075, 674);
            dataGridView1.TabIndex = 0;
            // 
            // logidDataGridViewTextBoxColumn
            // 
            logidDataGridViewTextBoxColumn.DataPropertyName = "log_id";
            logidDataGridViewTextBoxColumn.HeaderText = "log_id";
            logidDataGridViewTextBoxColumn.Name = "logidDataGridViewTextBoxColumn";
            logidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // recordtimeDataGridViewTextBoxColumn
            // 
            recordtimeDataGridViewTextBoxColumn.DataPropertyName = "record_time";
            recordtimeDataGridViewTextBoxColumn.HeaderText = "record_time";
            recordtimeDataGridViewTextBoxColumn.Name = "recordtimeDataGridViewTextBoxColumn";
            recordtimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // logtypeDataGridViewTextBoxColumn
            // 
            logtypeDataGridViewTextBoxColumn.DataPropertyName = "log_type";
            logtypeDataGridViewTextBoxColumn.HeaderText = "log_type";
            logtypeDataGridViewTextBoxColumn.Name = "logtypeDataGridViewTextBoxColumn";
            logtypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sourceDataGridViewTextBoxColumn
            // 
            sourceDataGridViewTextBoxColumn.DataPropertyName = "source";
            sourceDataGridViewTextBoxColumn.HeaderText = "source";
            sourceDataGridViewTextBoxColumn.Name = "sourceDataGridViewTextBoxColumn";
            sourceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
            descriptionDataGridViewTextBoxColumn.HeaderText = "description";
            descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            statusDataGridViewTextBoxColumn.DataPropertyName = "status";
            statusDataGridViewTextBoxColumn.HeaderText = "status";
            statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // payloadDataGridViewTextBoxColumn
            // 
            payloadDataGridViewTextBoxColumn.DataPropertyName = "payload";
            payloadDataGridViewTextBoxColumn.HeaderText = "payload";
            payloadDataGridViewTextBoxColumn.Name = "payloadDataGridViewTextBoxColumn";
            payloadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // resultDataGridViewTextBoxColumn
            // 
            resultDataGridViewTextBoxColumn.DataPropertyName = "result";
            resultDataGridViewTextBoxColumn.HeaderText = "result";
            resultDataGridViewTextBoxColumn.Name = "resultDataGridViewTextBoxColumn";
            resultDataGridViewTextBoxColumn.ReadOnly = true;
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
            // LogForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1494, 720);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "LogForm";
            Text = "Log Form";
            Load += LogForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)logModelBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private Button button1;
        private DateTimePicker toBox;
        private DateTimePicker fromBox;
        private TextBox searchBox;
        private ComboBox logTypeBox;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private Label label4;
        private Label label3;
        private DataGridViewTextBoxColumn logIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn recordTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn logTypeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sourceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn payloadDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn resultDataGridViewTextBoxColumn;
        private BindingSource logModelBindingSource;
        private DataGridViewTextBoxColumn logidDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn recordtimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn logtypeDataGridViewTextBoxColumn;
        private SaveFileDialog saveFileDialog1;
    }
}