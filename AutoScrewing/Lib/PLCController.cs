using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AutoScrewing.Lib
{
    public class PLCController
    {
        public string PLC_TARGET { get; set; } = "192.168.0.10";//255.255.255.0
        public record PLCItem(string type,string command,int value,string description);
        private CancellationTokenSource cancelToken = new CancellationTokenSource();

        private static SemaphoreSlim SemaphoreSlim = new SemaphoreSlim(1);
        public PLCController()
        {
            PLC_TARGET = Settings1.Default.PLC_TARGET;
        }
        TcpClient BuildTcpClient()
        {
            var client = new TcpClient();
            client.NoDelay  = true;
            client.SendTimeout = 1500;
            client.ReceiveTimeout = 1500;
            return client;
        }
        private async Task<string> GetMessage(Stream stream)
        {
            byte[] buffer = new byte[64];
            await stream.ReadExactlyAsync(buffer);
            return  Encoding.ASCII.GetString(buffer);
        }
        public async Task<string> Send(PLCItem item)
        {
            await SemaphoreSlim.WaitAsync();
            try
            {
                using (var tcpClient = BuildTcpClient())
                {
                    string val = item.type == "WR" ? item.value.ToString() : "";
                    await tcpClient.ConnectAsync(IPAddress.Parse(PLC_TARGET), 8501);
                    string command = $"{item.type} {item.command} {val}\r\n";
                    byte[] buffer = Encoding.ASCII.GetBytes(command);

                    await tcpClient.GetStream().WriteAsync(buffer, 0, buffer.Length);

                    await Task.Delay(100);

                    string res = await GetMessage(tcpClient.GetStream());
                    Console.WriteLine($"Writing {item.command} with value {item.value} and result {res} {DateTime.Now.ToLongDateString()} | {item.description}");
                    SemaphoreSlim.Release();
                    return res;
                }
            }
            catch (Exception e )
            {
                Console.Error.WriteLine(e.InnerException);
                Console.Error.WriteLine(e.Message);
                SemaphoreSlim.Release();
                return string.Empty;
            }
        }

    }
}
