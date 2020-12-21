using MediatR;
using Microsoft.Extensions.Logging;
using RadishV2.Server.Application.Command;
using RadishV2.Server.Application.Utils;
using RadishV2.Shared;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RadishV2.Server.Application.Handler
{
    /// <summary>
    /// Add Hash Key Handler
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{RadishV2.Server.Application.Command.AddHashKey, RadishV2.Shared.ApplicationResponse}" />
    public class AddHashKeyHandler : IRequestHandler<AddHashKey, ApplicationResponse>
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<AddHashKeyHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddHashKeyHandler"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public AddHashKeyHandler(ILogger<AddHashKeyHandler> logger)
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
        public Task<ApplicationResponse> Handle(AddHashKey request, CancellationToken cancellationToken)
        {
            ApplicationResponse response;

            try
            {
                var redisServer = ConnectionBuilder.BuildConnectToRedis(request.KeyPayload.RedisSetting);

                if (redisServer != null)
                {
                    var db = redisServer.GetDatabase(request.KeyPayload.RedisSetting.SelectedDatabase);

                    if (ConnectionBuilder.DoesKeyExist(db, request.KeyPayload.KeyListItem.KeyName))
                    {
                        response = new ApplicationResponse(false, "Key Exists");
                    }
                    else
                    {
                        List<HashEntry> hashEntries = new List<HashEntry>();

                        foreach (var value in request.KeyPayload.KeyListItem.KeyValues)
                        {
                            HashEntry hashEntry = new HashEntry(value.Name, value.Value);
                            hashEntries.Add(hashEntry);
                        }

                        db.HashSet(request.KeyPayload.KeyListItem.KeyName, hashEntries.ToArray());

                        response = new ApplicationResponse(true, "Added or Updated Keys");
                    }

                    if (request.KeyPayload.KeyListItem.Expiry != null && request.KeyPayload.KeyListItem.Expiry != "00:00:00")
                    {
                        var expTime = TimeSpan.Parse(request.KeyPayload.KeyListItem.Expiry);
                        db.KeyExpire(request.KeyPayload.KeyListItem.KeyName, expTime);
                    }
                }
                else
                {
                    response = new ApplicationResponse(true, "Failed to Add or Update Keys");
                }

                redisServer.Dispose();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response = new ApplicationResponse(false, ex.Message);
            }

            return Task.FromResult(response);
        }
    }
}