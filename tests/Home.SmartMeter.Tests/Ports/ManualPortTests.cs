using System;
using Xunit;
using System.IO.Ports;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace Home.SmartMeter.Tests
{
    public class ManualPortTests
    {
        class SerialPortReader
        {
            public void ReadSomeTelegrams(string comPort, int secondsToRead)
            {
                var serialPort = CreateP1Port(comPort);
                serialPort.ErrorReceived += (x, y) =>
                {
                    Console.WriteLine($"Error: {y.EventType}");
                };
                //var task = new Task(() => ReadSomeTelegrams(serialPort, 60)); // 
                //task.Start();
                var task = Task.Factory.StartNew(() => ReadSomeTelegrams(serialPort, secondsToRead));

                task.Wait();
            }

            private static void ReadSomeTelegrams(SerialPort serialPort, int secondsToRead)
            {
                try
                {
                    serialPort.Open();
                    var start = DateTime.Now;   
                    while ((DateTime.Now-start).TotalSeconds < secondsToRead)
                    {
                        try
                        {
                            var line = serialPort.ReadLine();
                            Console.WriteLine(line);
                        }
                        catch (TimeoutException)
                        {
                            Console.WriteLine($"====={DateTime.Now}=====");
                            Console.WriteLine("no data");
                        }
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Unable to open port: {ex.Message}");
                }
                finally
                {
                    serialPort.Dispose();
                }
            }
            private static SerialPort CreateP1Port(string comPort)
            {
                var baudRate = 115200;
                var dataBits = 8; //7;
                var stopBits = StopBits.One;
                var parity = Parity.None; //Parity.Even;
                var serialPort = new SerialPort(comPort, baudRate, parity, dataBits, stopBits)
                {
                    ReadTimeout = 1000 * 30, // 30 seconds timeout,
                    Handshake = Handshake.RequestToSend,
                    RtsEnable = false,
                    DtrEnable = false,
                    Encoding = Encoding.ASCII,
                    ParityReplace = (byte)'@',
                    NewLine = Environment.NewLine
                };
                return serialPort;
            }

            public void ShowSerialPortNames()
            {
                var names = SerialPort.GetPortNames();
                foreach (var name in names)
                {
                    Console.WriteLine($"Serialport {name}");
                }
            }
        }

        [Fact]
        public void ReadRawPortAsExperimentAndDumpData()
        {
            var reader = new SerialPortReader();
            reader.ShowSerialPortNames();
            reader.ReadSomeTelegrams("COM3", 10);
        }
    }
}
