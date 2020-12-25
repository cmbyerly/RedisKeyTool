using RedisKeyTool.Shared;
using StackExchange.Redis;
using System.Text;

namespace RedisKeyTool.Server.Application.Utils
{
    /// <summary>
    /// This is the shared connection builder.
    /// </summary>
    public static class ConnectionBuilder
    {
        /// <summary>
        /// Builds the connect to redis.
        /// </summary>
        /// <param name="redisSetting">The redis setting.</param>
        /// <returns></returns>
        public static ConnectionMultiplexer BuildConnectToRedis(RedisSetting redisSetting)
        {
            StringBuilder connectionString = new StringBuilder();

            connectionString.Append(redisSetting.RedisUrl);

            if (redisSetting.RedisUsername != null && !string.IsNullOrEmpty(redisSetting.RedisUsername))
            {
                connectionString.Append($",user={redisSetting.RedisUsername}");
            }

            if (redisSetting.RedisPassword != null && !string.IsNullOrEmpty(redisSetting.RedisPassword))
            {
                connectionString.Append($",password={redisSetting.RedisPassword}");
            }

            if (redisSetting.AllowAdmin)
            {
                connectionString.Append($",allowAdmin=true");
            }

            var redisServer = ConnectionMultiplexer.Connect(connectionString.ToString());

            return redisServer;
        }

        /// <summary>
        /// Builds the connect to redis server.
        /// </summary>
        /// <param name="redisSetting">The redis setting.</param>
        /// <param name="connectionMultiplexer">The connection multiplexer.</param>
        /// <returns></returns>
        public static IServer BuildConnectToRedisServer(RedisSetting redisSetting, out ConnectionMultiplexer connectionMultiplexer)
        {
            StringBuilder connectionString = new StringBuilder();

            connectionString.Append(redisSetting.RedisUrl);

            if (redisSetting.RedisUsername != null && !string.IsNullOrEmpty(redisSetting.RedisUsername))
            {
                connectionString.Append($",user={redisSetting.RedisUsername}");
            }

            if (redisSetting.RedisPassword != null && !string.IsNullOrEmpty(redisSetting.RedisPassword))
            {
                connectionString.Append($",password={redisSetting.RedisPassword}");
            }

            if (redisSetting.AllowAdmin)
            {
                connectionString.Append($",allowAdmin=true");
            }

            var mp = ConnectionMultiplexer.Connect(connectionString.ToString());

            connectionMultiplexer = mp;

            var redisServer = mp.GetServer(redisSetting.RedisUrl);

            return redisServer;
        }

        /// <summary>
        /// Does the key exist.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="keyName">Name of the key.</param>
        /// <returns>
        /// Whether key exists.
        /// </returns>
        public static bool DoesKeyExist(IDatabase db, string keyName)
        {
            return db.KeyExists(keyName);
        }
    }
}