using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CommStudio.Connections;

namespace Retranslator
{
    class Program
    {
        static SerialConnection connection;
        static void Main(string[] args)
        {
            var port = SerialPort.GetPortNames().First();
            connection = new SerialConnection();

            connection.Options = new SerialOptions()
            {
                PortName = port,
                BaudRate = 9600,
                DataBits = 8,
                Parity = CommStudio.Connections.Parity.None,
                StopBits = CommStopBits.One
            };

            connection.DataAvailableThreshold = 1;
            connection.DataAvailable += Connection_DataAvailable;
            connection.Open();
        }

        private static void Connection_DataAvailable(object sender, EventArgs e)
        {
            var buffer = new byte[255];
            var bytesRead = connection.Read(buffer, 0, 255);

            var text = System.Text.Encoding.Default.GetString(buffer);
            var tokens = text.Split(new char[] { '#', '-' });

            SendTime(tokens[1]);
        }

        private static void SendTime(string token)
        {
            var time = DateTime.Now;
            var client = new WebClient();

            client.DownloadString("http://test.track-me.pro/Input/Mobile?deviceId=repeater0001&number=" + token + "&ticks=" + time.Ticks);
        }
    }
}
