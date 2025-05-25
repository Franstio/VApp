using System.Net;
using System.Net.Sockets;
using System.Text;

namespace AutoScrewing
{
    public partial class Form1 : Form
    {
        TcpClient _client = new TcpClient();
        TcpClient _client2 = new TcpClient();
        string baseAddress = "192.168.0.7";
        int port = 8501;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    using (_client2)
                    {
                        await _client2.ConnectAsync(IPAddress.Parse(baseAddress), port);
                        using (var stream = _client2.GetStream())
                        {
                            byte[] rd = new byte[2048];
                            await stream.ReadExactlyAsync(rd, 0, rd.Length);
                            string text = Encoding.UTF8.GetString(rd);
                            await listBox1.InvokeAsync(() =>
                            {
                                listBox1.Items.Add(text);
                            });
                        }
                    }
                }
            });
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using (_client)
            {
                await _client.ConnectAsync(IPAddress.Parse(baseAddress),port);
                byte[] cmd = Encoding.UTF8.GetBytes(cmdText.Text);
                using (var stream =  _client.GetStream())
                {
                    await stream.WriteAsync(cmd, 0, cmd.Length);
                    byte[] rd = new byte[2048];
                    await stream.ReadExactlyAsync(rd, 0, rd.Length);
                    string text = Encoding.UTF8.GetString(rd);
                    await listBox1.InvokeAsync(() =>
                    {
                        listBox1.Items.Add(text);
                    });
                }
            }
        }
    }
}
