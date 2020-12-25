using System;
using Xunit;

namespace RedisKeyTool.Server.Application.Utils.Tests
{
    public class ConnectionBuilderTests
    {
        [Fact()]
        public void BuildConnectToRedisTest()
        {
            Assert.NotNull(ConnectionBuilder.BuildConnectToRedis(new Shared.RedisSetting()));
        }

        [Fact()]
        public void DoesKeyExistTest()
        {
            var server = ConnectionBuilder.BuildConnectToRedis(new Shared.RedisSetting());
            Assert.Throws<NullReferenceException>(() => ConnectionBuilder.DoesKeyExist(null, "blah"));
        }

        [Fact()]
        public void DoesKeyExistTest1()
        {
            var server = ConnectionBuilder.BuildConnectToRedis(new Shared.RedisSetting());
            Assert.False(ConnectionBuilder.DoesKeyExist(server.GetDatabase(0), "blah"));
        }
    }
}