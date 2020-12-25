using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace RedisKeyTool.Server.Application.Handler.Tests
{
    public class AddStringKeyHandlerTests
    {
        [Fact()]
        public void AddStringKeyHandlerTest()
        {
            var iLoggerMock = new Mock<ILogger<AddStringKeyHandler>>();
            var handler = new AddStringKeyHandler(iLoggerMock.Object);
            Assert.NotNull(handler);
        }
    }
}