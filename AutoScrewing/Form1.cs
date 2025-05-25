using System.Net;
using System.Net.Sockets;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace AutoScrewing
{
    public partial class Form1 : Form
    {
        TcpClient _client = new TcpClient();
        TcpClient _client2 = new TcpClient();
        string baseAddress = "192.168.0.7";
        int port = 23;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Task.Run(async () => {
                while (true) {
                    try
                    {
                        using (_client)
                        {
                            await _client2.ConnectAsync(IPAddress.Parse(baseAddress), port);
                            byte[] rd = new byte[2048];
                            await _client2.GetStream().ReadAsync(rd, 0, rd.Length);
                            string text = Encoding.ASCII.GetString(rd);
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
            if (cmdText.Text.Contains("REQ100"))
            {
                DateTime dt = DateTime.Now;
                int checksum = dt.Year + dt.Month + dt.Day + dt.Hour + dt.Month + dt.Second;
                cmdText.Text = $"{{REQ100,{dt.Year},{dt.Month},{dt.Date},{dt.Hour},{dt.Minute},{dt.Second}.{checksum},{checksum + 5438},{0},100}}";
                await listBox1.InvokeAsync(() =>
                {
                    listBox1.Items.Add(cmdText.Text);
                });
            }
            using (_client)
            {
                await _client.ConnectAsync(IPAddress.Parse(baseAddress), port);
                byte[] cmd = Encoding.ASCII.GetBytes(cmdText.Text);
                await _client.GetStream().WriteAsync(cmd, 0, cmd.Length);
                byte[] rd = new byte[2048];
                await _client.GetStream().ReadAsync(rd, 0, rd.Length);
                string text = Encoding.ASCII.GetString(rd);
                await listBox1.InvokeAsync(() =>
                {
                    listBox1.Items.Add(text);
                });
            }
        }
    }
}
