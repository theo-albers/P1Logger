using System;
using System.IO.Ports;
using Home.SmartMeter.Ports;

namespace Home.SmartMeter
{
    class Program
    {
        static void Main(string[] args)
        {
            var port = new P1SerialPort();
            new SmartMeterLogger(port).Start();
        }
    }
}
