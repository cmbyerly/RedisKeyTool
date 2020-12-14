using RadishV2.Application.Handler;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using System;
using System.Threading.Tasks;

namespace RadishV2.Application.Handler.Tests
{
    public class PingHandlerTests
    {
        [Fact()]
        public void PingHandlerTest()
        {
            var iLoggerMock = new Mock<ILogger<PingHandler>>();
            var handler = new PingHandler(iLoggerMock.Object);
            Assert.NotNull(handler);
        }
    }
}