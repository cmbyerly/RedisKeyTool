using Xunit;

namespace RadishV2.Server.Application.Command.Tests
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