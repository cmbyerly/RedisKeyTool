using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace RedisKeyTool.Server.Application.Handler.Tests
{
    public class AddSortedSetKeyHandlerTests
    {
        [Fact()]
        public void AddSortedSetKeyHandlerTest()
        {
            var iLoggerMock = new Mock<ILogger<AddSortedSetKeyHandler>>();
            var handler = new AddSortedSetKeyHandler(iLoggerMock.Object);
            Assert.NotNull(handler);
        }
    }
}