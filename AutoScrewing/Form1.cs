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
        Barrier barrier = new Barrier(2);
        CancellationTokenSource cts = new CancellationTokenSource();
        int port = 23;
        public Form1()
        {
            InitializeComponent();
            _client = BuildPort();
        }
        SerialPort BuildPort()
        {
            SerialPort sp = new SerialPort(baseAddress, 115200, Parity.None, 8, StopBits.One);
            sp.NewLine = "\r\n";
            return sp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Task.Run(async () => {
                while (true) {
                    try
                    {
                        if (cts.IsCancellationRequested)
                        {
                            barrier.SignalAndWait();
                            continue;   
                        }
                        using (_client)
                        {
                            _client.Open();
                            _client.ReadTimeout = 500;
                            byte[] rd = new byte[8];
                            string text = _client.ReadLine();
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
            button1.Enabled = false;
            cts.Cancel();
            barrier.SignalAndWait(1000);
            DateTime dt = DateTime.Now;
            int checksum = dt.Year + dt.Month + dt.Day + dt.Hour + dt.Month + dt.Second;
            string command = $"{{{cmdText.Text},{dt.Year},{dt.Month},{dt.Day},{dt.Hour},{dt.Minute},{dt.Second}.{checksum},{checksum + 5438},1,1,}}\n\r";
            await listBox1.InvokeAsync(() =>
            {
                listBox1.Items.Add($"INPUT: {command}");
            });
            using (_client)
            {
                _client.Open();
                byte[] cmd = Encoding.ASCII.GetBytes(command);
                _client.Write(cmd, 0, cmd.Length);
                await Task.Delay(1000);
                string text = _client.ReadExisting();
                await listBox1.InvokeAsync(() =>
                {
                    listBox1.Items.Add($"OUTPUT: {text}");
                });
            }
            cts = new CancellationTokenSource();
            barrier.SignalAndWait();
            button1.Enabled = true;
        }
    }
}
