using System;
using Moq;
using Xunit;
using Home.SmartMeter.Ports;

namespace Home.SmartMeter
{
    public class SmartMeterLoggerTests
    {
        [Fact]
        public void ConstructorThrowsWhenNullPort()
        {
            Assert.Throws<NullReferenceException>(() => new SmartMeterLogger(null));
        }

        [Fact]
        public void RunOpensSerialPort()
        {
            // Arrange
            var mock = new Mock<ISerialPort>();
            mock.Setup(x => x.Open()).Verifiable();
            var sut = new SmartMeterLogger(mock.Object);
            // Act
            sut.Start();
            // Assert
            mock.VerifyAll();
        }
        
    }
}