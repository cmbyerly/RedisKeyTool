using Xunit;

namespace RedisKeyTool.Shared.Tests
{
    public class KeyValueTests
    {
        [Fact()]
        public void KeyValueTest()
        {
            KeyValue keyValue = new KeyValue();
            Assert.True(keyValue.Name == string.Empty);
            Assert.True(keyValue.Value == string.Empty);
            Assert.True(keyValue.Score == 0.0);
        }

        [Fact()]
        public void KeyValueTest1()
        {
            KeyValue keyValue = new KeyValue("value");
            Assert.True(keyValue.Value == "value");
        }

        [Fact()]
        public void KeyValueTest2()
        {
            KeyValue keyValue = new KeyValue("name", "value");
            Assert.True(keyValue.Value == "value");
            Assert.True(keyValue.Name == "name");
        }

        [Fact()]
        public void KeyValueTest3()
        {
            KeyValue keyValue = new KeyValue("value", 0.0);
            Assert.True(keyValue.Value == "value");
            Assert.True(keyValue.Score == 0.0);
        }

        [Fact()]
        public void KeyValueTest4()
        {
            KeyValue keyValue = new KeyValue("name", "value", 0.0);
            Assert.True(keyValue.Value == "value");
            Assert.True(keyValue.Name == "name");
            Assert.True(keyValue.Score == 0.0);
        }
    }
}