using Xunit;

namespace RadishV2.Application.Command.Tests
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