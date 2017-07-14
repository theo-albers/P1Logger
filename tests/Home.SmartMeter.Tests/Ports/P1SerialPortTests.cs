using System;
using Xunit;
using System.IO.Ports;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace Home.SmartMeter.Ports
{
    public class P1PortTests
    {
        [Fact]
        public void OpenIsNotImplemented()
        {
            var sut = new P1SerialPort();
            Assert.Throws<NotImplementedException>(() => sut.Open());
        }
    }
}

