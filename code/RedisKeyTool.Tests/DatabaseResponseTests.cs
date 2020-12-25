using System.Collections.Generic;
using Xunit;

namespace RedisKeyTool.Shared.Tests
{
    public class DatabaseResponseTests
    {
        [Fact()]
        public void DatabaseResponseTest()
        {
            DatabaseResponse databaseResponse = new DatabaseResponse();
            Assert.True(databaseResponse.IsSuccess == false);
        }

        [Fact()]
        public void DatabaseResponseTest1()
        {
            DatabaseResponse databaseResponse = new DatabaseResponse(true, "message");
            Assert.True(databaseResponse.IsSuccess == true);
            Assert.True(databaseResponse.Message == "message");
        }

        [Fact()]
        public void DatabaseResponseTest2()
        {
            DatabaseResponse databaseResponse = new DatabaseResponse(new List<DbListItem>(), true, "message");
            Assert.True(databaseResponse.IsSuccess == true);
            Assert.True(databaseResponse.Message == "message");
            Assert.True(databaseResponse.DbListItems.Count == 0);
        }
    }
}