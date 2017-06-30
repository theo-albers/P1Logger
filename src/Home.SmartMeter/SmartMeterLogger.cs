using System;
using Home.SmartMeter.Ports;

namespace Home.SmartMeter
{
    public class SmartMeterLogger
    {
        private ISerialPort port;

        public SmartMeterLogger(ISerialPort port)
        {
            if (port == null)
                throw new NullReferenceException("Expected port");
            this.port = port;
        }

        public void Start()
        {
            Console.WriteLine("Home Smart Meter - P1 Logger");
            port.Open();
        }
        
    }
}