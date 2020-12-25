using Xunit;

namespace RedisKeyTool.Shared.Tests
{
    public class DbListItemTests
    {
        [Fact()]
        public void DbListItemTest()
        {
            DbListItem dbListItem = new DbListItem();
            Assert.True(dbListItem.DbNumber == 0);
            Assert.Null(dbListItem.DbDisplay);
        }

        [Fact()]
        public void DbListItemTest1()
        {
            DbListItem dbListItem = new DbListItem(1);
            Assert.True(dbListItem.DbNumber == 1);
            Assert.True(dbListItem.DbDisplay == "DB-1");
        }
    }
}