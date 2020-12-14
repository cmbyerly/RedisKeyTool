using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace RadishV2.Server.Application.Handler.Tests
{
    public class DeleteKeyHandlerTests
    {
        [Fact()]
        public void DeleteKeyHandlerTest()
        {
            var iLoggerMock = new Mock<ILogger<DeleteKeyHandler>>();
            var handler = new DeleteKeyHandler(iLoggerMock.Object);
            Assert.NotNull(handler);
        }
    }
}