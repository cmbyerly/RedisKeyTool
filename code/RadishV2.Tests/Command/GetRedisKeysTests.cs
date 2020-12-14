using Xunit;

namespace RadishV2.Server.Application.Command.Tests
{
    public class GetRedisKeysTests
    {
        [Fact()]
        public void GetRedisKeysTest()
        {
            GetRedisKeys value = new GetRedisKeys();
            Assert.NotNull(value);
        }
    }
}