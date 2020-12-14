using Xunit;

namespace RadishV2.Server.Application.Command.Tests
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