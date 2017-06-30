using System;
using System.IO.Ports;

namespace P1Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("P1 Logger");
            var names = SerialPort.GetPortNames();
            foreach (var name in names)
            {
                Console.WriteLine($"Serialport {name}");
            }
        }
    }
}
