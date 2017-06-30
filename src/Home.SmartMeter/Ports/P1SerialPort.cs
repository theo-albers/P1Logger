using System;
using System.IO.Ports;

namespace Home.SmartMeter.Ports
{
    public class P1SerialPort : ISerialPort
    {
        public void Open()
        {
            var names = SerialPort.GetPortNames();
            foreach (var name in names)
            {
                Console.WriteLine($"Serialport {name}");
            }

            throw new NotImplementedException();
        }
    }
}