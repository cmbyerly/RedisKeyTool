using Xunit;

namespace RedisKeyTool.Shared.Tests
{
    public class RedisSettingTests
    {
        [Fact()]
        public void RedisSettingTest()
        {
            RedisSetting redisSetting = new RedisSetting();
            Assert.True(redisSetting.SelectedDatabase == 0);
            Assert.True(redisSetting.SettingName == string.Empty);
            Assert.True(redisSetting.RedisUrl == "localhost:6379");
            Assert.True(redisSetting.RedisUsername == string.Empty);
            Assert.True(redisSetting.RedisPassword == string.Empty);
            Assert.True(redisSetting.AllowAdmin == true);
        }
    }
}