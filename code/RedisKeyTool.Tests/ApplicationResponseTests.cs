using Xunit;

namespace RedisKeyTool.Shared.Tests
{
    public class ApplicationResponseTests
    {
        [Fact()]
        public void ApplicationResponseTest()
        {
            ApplicationResponse resp = new ApplicationResponse();
            Assert.True(resp.IsSuccess == false);
        }

        [Fact()]
        public void ApplicationResponseTest1()
        {
            ApplicationResponse resp = new ApplicationResponse(false);
            Assert.True(resp.IsSuccess == false);
        }

        [Fact()]
        public void ApplicationResponseTest2()
        {
            ApplicationResponse resp = new ApplicationResponse(false, "Some message");
            Assert.True(resp.IsSuccess == false);
            Assert.True(resp.Message == "Some message");
        }
    }
}