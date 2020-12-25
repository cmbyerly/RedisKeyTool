using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace RedisKeyTool.Application.Handler.Tests
{
    public class GetRedisDbsHandlerTests
    {
        [Fact()]
        public void GetRedisDbsHandlerTest()
        {
            var iLoggerMock = new Mock<ILogger<GetRedisDbsHandler>>();
            var handler = new GetRedisDbsHandler(iLoggerMock.Object);
            Assert.NotNull(handler);
        }
    }
}