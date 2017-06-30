using System;
using Xunit;

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