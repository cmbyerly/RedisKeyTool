using Xunit;

namespace RedisKeyTool.Server.Application.Command.Tests
{
    public class AddListKeyTests
    {
        [Fact()]
        public void AddListKeyTest()
        {
            AddListKey value = new AddListKey();
            Assert.NotNull(value);
        }
    }
}