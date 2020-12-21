using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

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