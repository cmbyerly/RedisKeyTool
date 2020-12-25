using Xunit;

namespace RedisKeyTool.Application.Command.Tests
{
    public class PingTests
    {
        [Fact()]
        public void PingTest()
        {
            Ping value = new Ping();
            Assert.NotNull(value);
        }
    }
}