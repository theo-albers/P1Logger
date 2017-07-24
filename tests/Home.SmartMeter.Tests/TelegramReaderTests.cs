using System;
using System.Linq;
using System.IO;
using Xunit;
using System.Collections.Generic;

namespace Home.SmartMeter.Tests
{
    public class TelegramReaderTests
    {
        private static IEnumerable<string> ReadLines(StreamReader me)
        {
            var line = string.Empty;
            while ((line = me.ReadLine()) != null)
                yield return line;
        }

        [Theory]
        [InlineData(@"TestData\P1LogStream.txt", 60)]
        [InlineData(@"TestData\P1LogStream.noheaders.txt", 0)]
        public void ReadTelegramsFromValidStream(string telegramTestFile, int expectedTelegrams)
        {
            using (var reader = new StreamReader(telegramTestFile))
            {
                var telegrams = (from line in ReadLines(reader)
                                 where line.StartsWith(@"/XMX5")
                                 select line).Count();
                Assert.Equal(expectedTelegrams, telegrams);
            }
        }
        
    }
}