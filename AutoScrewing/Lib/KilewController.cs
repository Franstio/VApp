using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoScrewing.Lib
{
    public class KilewController
    {
        SerialPort _client = new SerialPort();
        string baseAddress = "COM4";
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

        public async Task<string> Send(string cmd)
        {
            if (_client == null || _client.PortName != baseAddress)
                _client = BuildPort();
            using (_client)
            {
                if (!_client.IsOpen)
                    _client.Open();
                cmd = GetCommand(cmd);
                byte[] buffer = Encoding.ASCII.GetBytes(cmd);
                _client.Write(buffer, 0, buffer.Length);
                await Task.Delay(1000);
                byte[] rd = new byte[8];
                string text = _client.ReadLine();
                return text;
            }
        }
    }
}
