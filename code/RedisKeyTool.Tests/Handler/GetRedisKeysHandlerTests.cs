using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace RedisKeyTool.Server.Application.Handler.Tests
{
    public class GetRedisKeysHandlerTests
    {
        [Fact()]
        public void HandleTest()
        {
            var iLoggerMock = new Mock<ILogger<GetRedisKeysHandler>>();
            var handler = new GetRedisKeysHandler(iLoggerMock.Object);
            Assert.NotNull(handler);
        }
    }
}