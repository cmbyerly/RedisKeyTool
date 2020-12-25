using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace RedisKeyTool.Server.Application.Handler.Tests
{
    public class AddHashKeyHandlerTests
    {
        [Fact()]
        public void AddHashKeyHandlerTest()
        {
            var iLoggerMock = new Mock<ILogger<AddHashKeyHandler>>();
            var handler = new AddHashKeyHandler(iLoggerMock.Object);
            Assert.NotNull(handler);
        }
    }
}