using Xunit;

namespace RedisKeyTool.Server.Application.Command.Tests
{
    public class AddSetKeyTests
    {
        [Fact()]
        public void AddSetKeyTest()
        {
            AddSetKey value = new AddSetKey();
            Assert.NotNull(value);
        }
    }
}