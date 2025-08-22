using AutoScrewing.Database.Models;
using AutoScrewing.Database.Repository;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AutoScrewing.Lib
{
    public class PLCController
    {
        public string PLC_TARGET { get; set; } = "192.168.0.10";//255.255.255.0
        private LogRepository logRepository = new LogRepository();
        public record PLCItem(string type,string command,int value,string description,bool isLogging=true);
        private CancellationTokenSource cancelToken = new CancellationTokenSource();
        public bool isActive { get; private set; } = false;
        private static SemaphoreSlim SemaphoreSlim = new SemaphoreSlim(1);
        public PLCController()
        {
            PLC_TARGET = Settings1.Default.PLC_TARGET;
        }
        TcpClient BuildTcpClient()
        {
            TcpClient tcpClient = new TcpClient();
            tcpClient.NoDelay  = true;
            tcpClient.SendTimeout = 3000;
            tcpClient.ReceiveTimeout = 3000;
            return tcpClient;
        }
        private async Task<string> GetMessage(Stream stream)
        {
            byte[] buffer = new byte[64];
            await stream.ReadAsync(buffer, 0,buffer.Length);
            return  Encoding.ASCII.GetString(buffer);
        }
        public async Task<string> Send(PLCItem item)
        {
            await SemaphoreSlim.WaitAsync();
            LogModel Log = new LogModel(DateTime.Now, "PLC-Send", "PLC Controller Send", item.description, "SEND");
            Log.payload = JsonSerializer.Serialize(item);
            try
            {
                using (var tcpClient = BuildTcpClient())
                {
                    string val = item.type == "WR" ? $" {item.value.ToString()}" : "";
                    await tcpClient.ConnectAsync(IPAddress.Parse(PLC_TARGET), 8501).WaitAsync(TimeSpan.FromMilliseconds(100));
                    string command = $"{item.type} {item.command}{val}\r\n";
                    byte[] buffer = Encoding.ASCII.GetBytes(command);

                    await tcpClient.GetStream().WriteAsync(buffer, 0, buffer.Length);

                    await Task.Delay(100);

                    string res = await GetMessage(tcpClient.GetStream());
                    Console.WriteLine($"Writing {item.command} with value {item.value} and result {res} {DateTime.Now.ToLongDateString()} | {item.description}");
                    Log.result = res;
                    Log.status = $"{Log.status}-Success";
                    if (Settings1.Default.logPlc)
                        await logRepository.RecordLog(Log);
                    isActive = true;
                    SemaphoreSlim.Release();
                    return res.Replace("\0", "").Replace("\r", "").Replace("\n", "").Trim();
                }
            }
            catch (Exception e)
            {
                Log.result = e.Message + " | " + e.StackTrace;
                Log.status = $"{Log.status}-Failed";
                if (Settings1.Default.logPlc && item.isLogging)
                    await logRepository.RecordLog(Log);
                Console.Error.WriteLine(e.StackTrace);
                Console.Error.WriteLine(e.Message);
                isActive = false;
                SemaphoreSlim.Release();
                return string.Empty;
            }
        }

    }
}
