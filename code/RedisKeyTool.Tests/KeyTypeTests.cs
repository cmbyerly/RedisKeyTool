using Xunit;

namespace RedisKeyTool.Shared.Tests
{
    public class KeyTypeTests
    {
        [Fact()]
        public void KeyTypeTest()
        {
            KeyType keyType = new KeyType();
            Assert.Null(keyType.KeyTypeName);
        }

        [Fact()]
        public void KeyTypeTest1()
        {
            KeyType keyType = new KeyType("myName", StackExchange.Redis.RedisType.String);
            Assert.True(keyType.KeyTypeName == "myName");
            Assert.True(keyType.RedisType == StackExchange.Redis.RedisType.String);
        }
    }
}