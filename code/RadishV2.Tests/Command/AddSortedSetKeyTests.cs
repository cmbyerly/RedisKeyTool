using Xunit;

namespace RadishV2.Server.Application.Command.Tests
{
    public class AddSortedSetKeyTests
    {
        [Fact()]
        public void AddSortedSetKeyTest()
        {
            AddSortedSetKey value = new AddSortedSetKey();
            Assert.NotNull(value);
        }
    }
}