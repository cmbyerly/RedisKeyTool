using MediatR;
using Microsoft.AspNetCore.Mvc;
using RedisKeyTool.Application.Command;
using RedisKeyTool.Server.Application.Command;
using RedisKeyTool.Shared;

namespace RedisKeyTool.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RedisController : ControllerBase
    {
        public IMediator _mediatr;

        /// <summary>
        /// Initializes a new instance of the <see cref="RedisController"/> class.
        /// </summary>
        /// <param name="mediatr">The mediatr.</param>
        public RedisController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        /// <summary>
        /// Gets the database list items.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <returns></returns>
        [HttpPost("dbs")]
        public DatabaseResponse GetDbListItems([FromBody] RedisSetting setting)
        {
            var result = _mediatr.Send(new GetRedisDbs() { RedisSetting = setting }).Result;
            return result;
        }

        /// <summary>
        /// Gets the keys.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <returns></returns>
        [HttpPost("keys")]
        public KeyListItem[] GetKeys([FromBody] RedisSetting setting)
        {
            var result = _mediatr.Send(new GetRedisKeys() { RedisSetting = setting }).Result.ToArray();
            return result;
        }

        /// <summary>
        /// Gets the keys count.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <returns></returns>
        [HttpPost("keys/count")]
        public ApplicationResponse GetKeysCount([FromBody] RedisSetting setting)
        {
            var result = _mediatr.Send(new GetRedisKeysCount() { RedisSetting = setting }).Result;
            return result;
        }

        /// <summary>
        /// Gets the clients.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <returns></returns>
        [HttpPost("clients")]
        public ClientListItem[] GetClients([FromBody] RedisSetting setting)
        {
            var result = _mediatr.Send(new GetServerClients() { RedisSetting = setting }).Result.ToArray();
            return result;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <returns></returns>
        [HttpPost("config")]
        public DatabaseConfigResponse GetConfiguration([FromBody] RedisSetting setting)
        {
            var result = _mediatr.Send(new GetRedisServerInfo() { RedisSetting = setting }).Result;
            return result;
        }

        /// <summary>
        /// Kills the connection.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <returns></returns>
        [HttpPost("kill")]
        public ClientListItem[] KillConnection([FromBody] ConnectionKiller setting)
        {
            var kresult = _mediatr.Send(new KillConnection() { ConnectionKiller = setting }).Result;
            var result = _mediatr.Send(new GetServerClients() { RedisSetting = setting }).Result.ToArray();
            return result;
        }

        /// <summary>
        /// Deletes the key.
        /// </summary>
        /// <param name="payload">The payload.</param>
        /// <returns></returns>
        [HttpPost("keys/delete")]
        public ApplicationResponse DeleteKey([FromBody] KeyPayload payload)
        {
            var result = _mediatr.Send(new DeleteKey() { KeyPayload = payload }).Result;
            return result;
        }

        /// <summary>
        /// Adds the string key.
        /// </summary>
        /// <param name="payload">The payload.</param>
        /// <returns></returns>
        [HttpPost("keys/add/string")]
        public ApplicationResponse AddStringKey([FromBody] KeyPayload payload)
        {
            var result = _mediatr.Send(new AddStringKey() { KeyPayload = payload }).Result;
            return result;
        }

        /// <summary>
        /// Adds the sorted set key.
        /// </summary>
        /// <param name="payload">The payload.</param>
        /// <returns></returns>
        [HttpPost("keys/add/sortedset")]
        public ApplicationResponse AddSortedSetKey([FromBody] KeyPayload payload)
        {
            var result = _mediatr.Send(new AddSortedSetKey() { KeyPayload = payload }).Result;
            return result;
        }

        /// <summary>
        /// Adds the set key.
        /// </summary>
        /// <param name="payload">The payload.</param>
        /// <returns></returns>
        [HttpPost("keys/add/set")]
        public ApplicationResponse AddSetKey([FromBody] KeyPayload payload)
        {
            var result = _mediatr.Send(new AddSetKey() { KeyPayload = payload }).Result;
            return result;
        }

        /// <summary>
        /// Adds the list key.
        /// </summary>
        /// <param name="payload">The payload.</param>
        /// <returns></returns>
        [HttpPost("keys/add/list")]
        public ApplicationResponse AddListKey([FromBody] KeyPayload payload)
        {
            var result = _mediatr.Send(new AddListKey() { KeyPayload = payload }).Result;
            return result;
        }

        /// <summary>
        /// Adds the hash key.
        /// </summary>
        /// <param name="payload">The payload.</param>
        /// <returns></returns>
        [HttpPost("keys/add/hash")]
        public ApplicationResponse AddHashKey([FromBody] KeyPayload payload)
        {
            var result = _mediatr.Send(new AddHashKey() { KeyPayload = payload }).Result;
            return result;
        }

        /// <summary>
        /// Adds the string key.
        /// </summary>
        /// <param name="payload">The payload.</param>
        /// <returns></returns>
        [HttpPost("keys/update/string")]
        public ApplicationResponse UpdateStringKey([FromBody] KeyPayload payload)
        {
            var delresult = _mediatr.Send(new DeleteKey() { KeyPayload = payload }).Result;
            var result = _mediatr.Send(new AddStringKey() { KeyPayload = payload }).Result;
            return result;
        }

        /// <summary>
        /// Adds the sorted set key.
        /// </summary>
        /// <param name="payload">The payload.</param>
        /// <returns></returns>
        [HttpPost("keys/update/sortedset")]
        public ApplicationResponse UpdateSortedSetKey([FromBody] KeyPayload payload)
        {
            var delresult = _mediatr.Send(new DeleteKey() { KeyPayload = payload }).Result;
            var result = _mediatr.Send(new AddSortedSetKey() { KeyPayload = payload }).Result;
            return result;
        }

        /// <summary>
        /// Adds the set key.
        /// </summary>
        /// <param name="payload">The payload.</param>
        /// <returns></returns>
        [HttpPost("keys/update/set")]
        public ApplicationResponse UpdateSetKey([FromBody] KeyPayload payload)
        {
            var delresult = _mediatr.Send(new DeleteKey() { KeyPayload = payload }).Result;
            var result = _mediatr.Send(new AddSetKey() { KeyPayload = payload }).Result;
            return result;
        }

        /// <summary>
        /// Adds the list key.
        /// </summary>
        /// <param name="payload">The payload.</param>
        /// <returns></returns>
        [HttpPost("keys/update/list")]
        public ApplicationResponse UpdateListKey([FromBody] KeyPayload payload)
        {
            var delresult = _mediatr.Send(new DeleteKey() { KeyPayload = payload }).Result;
            var result = _mediatr.Send(new AddListKey() { KeyPayload = payload }).Result;
            return result;
        }

        /// <summary>
        /// Adds the hash key.
        /// </summary>
        /// <param name="payload">The payload.</param>
        /// <returns></returns>
        [HttpPost("keys/update/hash")]
        public ApplicationResponse UpdateHashKey([FromBody] KeyPayload payload)
        {
            var delresult = _mediatr.Send(new DeleteKey() { KeyPayload = payload }).Result;
            var result = _mediatr.Send(new AddHashKey() { KeyPayload = payload }).Result;
            return result;
        }

        /// <summary>
        /// Inflates the keys.
        /// </summary>
        /// <param name="payload">The payload.</param>
        /// <returns></returns>
        [HttpPost("keys/inflate")]
        public KeyListItem InflateKeys([FromBody] KeyPayload payload)
        {
            var result = _mediatr.Send(new GetRedisKey() { KeyPayload = payload }).Result;
            return result;
        }

        /// <summary>
        /// Deletes all keys.
        /// </summary>
        /// <param name="payload">The payload.</param>
        /// <returns></returns>
        [HttpPost("keys/delete/all")]
        public ApplicationResponse DeleteAllKeys([FromBody] KeyPayload payload)
        {
            var result = _mediatr.Send(new DeleteAllKeys() { KeyPayload = payload }).Result;
            return result;
        }
    }
}