using Xunit;

namespace RedisKeyTool.Server.Application.Command.Tests
{
    public class GetRedisKeyTests
    {
        [Fact()]
        public void GetRedisKeyTest()
        {
            GetRedisKey value = new GetRedisKey();
            Assert.NotNull(value);
        }
    }
}