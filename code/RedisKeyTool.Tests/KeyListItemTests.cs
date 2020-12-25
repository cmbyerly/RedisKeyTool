using System.Collections.Generic;
using Xunit;

namespace RedisKeyTool.Shared.Tests
{
    public class KeyListItemTests
    {
        [Fact()]
        public void KeyListItemTest()
        {
            KeyListItem keyListItem = new KeyListItem();
            Assert.True(keyListItem.KeyValues.Count == 0);
        }

        [Fact()]
        public void KeyListItemTest1()
        {
            KeyListItem keyListItem = new KeyListItem("myKey", StackExchange.Redis.RedisType.String);
            Assert.True(keyListItem.KeyValues.Count == 0);
            Assert.True(keyListItem.KeyName == "myKey");
            Assert.True(keyListItem.KeyType == "string");
        }

        [Fact()]
        public void KeyListItemTest2()
        {
            KeyListItem keyListItem = new KeyListItem("myKey", new List<KeyValue>(), false);
            Assert.True(keyListItem.KeyValues.Count == 0);
            Assert.True(keyListItem.KeyName == "myKey");
            Assert.True(keyListItem.KeyType == "string");
            Assert.True(keyListItem.IsNumeric == false);
        }

        [Fact()]
        public void KeyListItemTest3()
        {
            KeyListItem keyListItem = new KeyListItem("myKey", new List<KeyValue>(), false, StackExchange.Redis.RedisType.Hash, null);
            Assert.True(keyListItem.KeyValues.Count == 0);
            Assert.True(keyListItem.KeyName == "myKey");
            Assert.True(keyListItem.KeyType == "hash");
            Assert.True(keyListItem.IsNumeric == false);
        }
    }
}