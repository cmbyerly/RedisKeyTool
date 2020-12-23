﻿using MediatR;
using RadishV2.Shared;

namespace RadishV2.Application.Command
{
    /// <summary>
    /// Get the redis dbs command
    /// </summary>
    /// <seealso cref="MediatR.IRequest{RadishV2.Shared.DatabaseConfigResponse}" />
    public class GetRedisServerInfo : IRequest<DatabaseConfigResponse>
    {
        public GetRedisServerInfo()
        {
        }

        /// <summary>
        /// Gets or sets the redis setting.
        /// </summary>
        /// <value>
        /// The redis setting.
        /// </value>
        public RedisSetting RedisSetting { get; set; }
    }
}