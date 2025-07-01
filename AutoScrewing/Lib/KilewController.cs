using AutoScrewing.Database.Models;
using AutoScrewing.Database.Repository;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AutoScrewing.Lib
{
    public class KilewController
    {
        SerialPort _client = new SerialPort();
        string baseAddress = "COM4";
        SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1);
        private LogRepository logRepository  = new LogRepository();
        SerialPort BuildPort()
        {
            SerialPort sp = new SerialPort(baseAddress, 115200, Parity.None, 8, StopBits.One);
            sp.NewLine = "\r\n";
            sp.ReadTimeout = 1000;
            sp.WriteTimeout = 1000;
            return sp;
        }

        string GetCommand(string cmd)
        {


            DateTime dt = DateTime.Now;
            int checksum = dt.Year + dt.Month + dt.Day + dt.Hour + dt.Month + dt.Second;
            string command = $"{{{cmd},{dt.Year},{dt.Month},{dt.Day},{dt.Hour},{dt.Minute},{dt.Second},{checksum},{checksum + 5438},1,1,}}\n\r";
            return command;
        }

        public async Task<string> Send(string cmd, [CallerMemberName] string? methodName = null, [CallerFilePath] string? filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            LogModel log = new LogModel("Kilew", "Kilew Controller", $"Called by `{methodName}` in `{System.IO.Path.GetFileName(filePath)}` at line `{lineNumber}`", "Send");
            cmd = GetCommand(cmd);
            log.Payload = cmd;
            await semaphoreSlim.WaitAsync();
                if (_client == null || _client.PortName != baseAddress)
                    _client = BuildPort();
            using (_client)
            {
                try
                {

                    if (!_client.IsOpen)
                        _client.Open();
                    byte[] buffer = Encoding.ASCII.GetBytes(cmd);
                    _client.Write(buffer, 0, buffer.Length);
                    await Task.Delay(1000);
                    byte[] rd = new byte[8];
                    string text = _client.ReadLine();
                    log.Result = text;
                    log.Status += "-Success";
                    await logRepository.RecordLog(log);
                    semaphoreSlim.Release();
                    return text;
                }
                catch (FileNotFoundException e)
                {
                    log.Result = e.Message + " | " + e.StackTrace;
                    log.Status += "-Failed";
                    await logRepository.RecordLog(log);
                    semaphoreSlim.Release();
                    return string.Empty;
                }
                catch (Exception e)
                {
                    log.Result = e.Message + " | " + e.StackTrace;
                    log.Status += "-Failed";
                    await logRepository.RecordLog(log);
                    semaphoreSlim.Release();
                    return string.Empty;
                }
            }

        }
    }
}
