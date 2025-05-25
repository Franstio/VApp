using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace AutoScrewing
{
    public partial class Form1 : Form
    {
        SerialPort _client = new SerialPort();
        string baseAddress = "COM4";
        int port = 23;
        public Form1()
        {
            InitializeComponent();
            _client = BuildPort();
        }
        SerialPort BuildPort()
        {
            SerialPort sp = new SerialPort(baseAddress, 115200, Parity.None, 8, StopBits.One);
            return sp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Task.Run(async () => {
                while (true) {
                    try
                    {
                        using (_client)
                        {
                            _client.Open();
                            byte[] rd = new byte[8];
                            string text = _client.ReadExisting();
                            await listBox1.InvokeAsync(() =>
                            {
                                listBox1.Items.Add(text);
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine(ex.Message);
                    }
                }
            });
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (cmdText.Text.Contains("CMD100"))
            {
                DateTime dt = DateTime.Now;
                int checksum = dt.Year + dt.Month + dt.Day + dt.Hour + dt.Month + dt.Second;
                cmdText.Text = $"{{REQ100,{dt.Year},{dt.Month},{dt.Date},{dt.Hour},{dt.Minute},{dt.Second}.{checksum},{checksum + 5438},1,1,}}\n\r";
                await listBox1.InvokeAsync(() =>
                {
                    listBox1.Items.Add(cmdText.Text);
                });
            }
            using (_client)
            {
                _client.Open();
                byte[] cmd = Encoding.ASCII.GetBytes(cmdText.Text);
                 _client.Write(cmd, 0, cmd.Length); 
                string text = _client.ReadExisting();
                await listBox1.InvokeAsync(() =>
                {
                    listBox1.Items.Add(text);
                });
            }
        }
    }
}
