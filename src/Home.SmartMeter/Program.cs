using System;
using System.IO.Ports;

namespace Home.SmartMeter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Home Smart Meter - P1 Logger");

            var names = SerialPort.GetPortNames();
            foreach (var name in names)
            {
                Console.WriteLine($"Serialport {name}");
            }
        }
    }
}
