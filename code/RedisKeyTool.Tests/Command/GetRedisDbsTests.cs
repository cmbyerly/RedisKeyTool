using Xunit;

namespace RedisKeyTool.Application.Command.Tests
{
    public class GetRedisDbsTests
    {
        [Fact()]
        public void GetRedisDbsTest()
        {
            GetRedisDbs value = new GetRedisDbs();
            Assert.NotNull(value);
        }
    }
}