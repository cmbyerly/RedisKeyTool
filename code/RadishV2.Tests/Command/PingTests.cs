using Xunit;

namespace RadishV2.Application.Command.Tests
{
    public class PingTests
    {
        [Fact()]
        public void PingTest()
        {
            Ping value = new Ping();
            Assert.NotNull(value);
        }
    }
}