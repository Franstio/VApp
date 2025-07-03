using AutoScrewing.Database.Models;
using AutoScrewing.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoScrewing.Dialogue
{
    public partial class SampleForm : Form
    {
        public SampleForm()
        {
            InitializeComponent();
        }

        private void SampleForm_Load(object sender, EventArgs e)
        {

            var payload = new { serialnumber = "Test", status = "NG", data = new TransactionModel()};
            richTextBox1.Text = "Input: \n"+JsonSerializer.Serialize( new InputFileModel("",""))+"\n Output: \n"+ JsonSerializer.Serialize(payload);
        }
    }
}
