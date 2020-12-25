using MediatR;
using Microsoft.Extensions.Logging;
using RedisKeyTool.Application.Command;
using RedisKeyTool.Server.Application.Utils;
using RedisKeyTool.Shared;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RedisKeyTool.Application.Handler
{
    /// <summary>
    /// GetRedisDbsHandler
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{RedisKeyTool.Application.Command.GetRedisDbs, System.Collections.Generic.IEnumerable{RedisKeyTool.Entities.DbListItem}}" />
    public class GetRedisServerInfoHandler : IRequestHandler<GetRedisServerInfo, DatabaseConfigResponse>
    {
        private readonly ILogger<GetRedisServerInfoHandler> _logger;

        public GetRedisServerInfoHandler(ILogger<GetRedisServerInfoHandler> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<DatabaseConfigResponse> Handle(GetRedisServerInfo request, CancellationToken cancellationToken)
        {
            DatabaseConfigResponse databaseResponse = new DatabaseConfigResponse(true, "Connected");

            try
            {
                ConnectionMultiplexer connectionMultiplexer;
                var redisServer = ConnectionBuilder.BuildConnectToRedisServer(request.RedisSetting, out connectionMultiplexer);

                databaseResponse.Version = redisServer.Version.ToString();

                databaseResponse.FeatureList.Add($" Does SET have the EX|PX|NX|XX extensions : {redisServer.Features.SetConditional.ToString()}");
                databaseResponse.FeatureList.Add($"Does SADD support varadic usage? : {redisServer.Features.SetVaradicAddRemove.ToString()}");
                databaseResponse.FeatureList.Add($"Is ZPOPMAX and ZPOPMIN available? : {redisServer.Features.SortedSetPop.ToString()}");
                databaseResponse.FeatureList.Add($"Are Redis Streams available? : {redisServer.Features.Streams.ToString()}");
                databaseResponse.FeatureList.Add($"Is STRLEN available? : {redisServer.Features.StringLength.ToString()}");
                databaseResponse.FeatureList.Add($"Is SETRANGE available? : {redisServer.Features.StringSetRange.ToString()}");
                databaseResponse.FeatureList.Add($"Is SWAPDB available? : {redisServer.Features.SwapDB.ToString()}");
                databaseResponse.FeatureList.Add($"Does EVAL / EVALSHA / etc exist? : {redisServer.Features.Scripting.ToString()}");
                databaseResponse.FeatureList.Add($"Does TIME exist? : {redisServer.Features.Time.ToString()}");
                databaseResponse.FeatureList.Add($"Are Lua changes to the calling database transparent to the calling client? : {redisServer.Features.ScriptingDatabaseSafe.ToString()}");
                databaseResponse.FeatureList.Add($"Is PFCOUNT supported on replicas? : {redisServer.Features.HyperLogLogCountReplicaSafe.ToString()}");
                databaseResponse.FeatureList.Add($"Are the GEO commands available? : {redisServer.Features.Geo.ToString()}");
                databaseResponse.FeatureList.Add($"Does SetPop support popping multiple items? : {redisServer.Features.SetPopMultiple.ToString()}");
                databaseResponse.FeatureList.Add($"Are the Touch command available? : {redisServer.Features.KeyTouch.ToString()}");
                databaseResponse.FeatureList.Add($"Does UNLINK exist? : {redisServer.Features.Unlink.ToString()}");
                databaseResponse.FeatureList.Add($"Does the server prefer 'replica' terminology - 'REPLICAOF', etc? : {redisServer.Features.ReplicaCommands.ToString()}");
                databaseResponse.FeatureList.Add($"Are cursor-based scans available? : {redisServer.Features.Scan.ToString()}");
                databaseResponse.FeatureList.Add($"Is the PERSIST operation supported? : {redisServer.Features.Persist.ToString()}");
                databaseResponse.FeatureList.Add($"Does BITOP / BITCOUNT exist? : {redisServer.Features.BitwiseOperations.ToString()}");
                databaseResponse.FeatureList.Add($"Is CLIENT SETNAME available? : {redisServer.Features.ClientName.ToString()}");
                databaseResponse.FeatureList.Add($"Does EXEC support EXECABORT if there are errors? : {redisServer.Features.ExecAbort.ToString()}");
                databaseResponse.FeatureList.Add($"Can EXPIRE be used to set expiration on a key that is already volatile (i.e. has an expiration)? : {redisServer.Features.ExpireOverwrite.ToString()}");
                databaseResponse.FeatureList.Add($"Is RPUSHX and LPUSHX available? : {redisServer.Features.PushIfNotExists.ToString()}");
                databaseResponse.FeatureList.Add($"Does HDEL support varadic usage? : {redisServer.Features.HashVaradicDelete.ToString()}");
                databaseResponse.FeatureList.Add($"Is HSTRLEN available? : {redisServer.Features.HashStringLength.ToString()}");
                databaseResponse.FeatureList.Add($"Does INFO support sections? : {redisServer.Features.InfoSections.ToString()}");
                databaseResponse.FeatureList.Add($"Is LINSERT available? : {redisServer.Features.ListInsert.ToString()}");
                databaseResponse.FeatureList.Add($"Is MEMORY available? : {redisServer.Features.Memory.ToString()}");
                databaseResponse.FeatureList.Add($"Indicates whether PEXPIRE and PTTL are supported : {redisServer.Features.MillisecondExpiry.ToString()}");
                databaseResponse.FeatureList.Add($"Is MODULE available? : {redisServer.Features.Module.ToString()}");
                databaseResponse.FeatureList.Add($"Does SRANDMEMBER support 'count'? : {redisServer.Features.MultipleRandom.ToString()}");
                databaseResponse.FeatureList.Add($"Does INCRBYFLOAT / HINCRBYFLOAT exist? : {redisServer.Features.IncrementFloat.ToString()}");
                databaseResponse.FeatureList.Add($"Do list-push commands support multiple arguments? : {redisServer.Features.PushMultiple.ToString()}");

                foreach(var configItem in redisServer.ConfigGet())
                {
                    databaseResponse.ConfigItems.Add($"{configItem.Key}: {configItem.Value}");
                }

                connectionMultiplexer.Close();
                connectionMultiplexer.Dispose();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                databaseResponse = new DatabaseConfigResponse(false, ex.Message);
            }

            return Task.FromResult(databaseResponse);
        }
    }
}