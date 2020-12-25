using Xunit;

namespace RedisKeyTool.Server.Application.Command.Tests
{
    public class DeleteKeyTests
    {
        [Fact()]
        public void DeleteKeyTest()
        {
            DeleteKey value = new DeleteKey();
            Assert.NotNull(value);
        }
    }
}