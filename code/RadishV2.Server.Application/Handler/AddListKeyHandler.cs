using MediatR;
using RadishV2.Server.Application.Command;
using RadishV2.Server.Application.Utils;
using RadishV2.Shared;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RadishV2.Server.Application.Handler
{
    /// <summary>
    /// Add List Key Handler
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{RadishV2.Server.Application.Command.AddListKey, RadishV2.Shared.ApplicationResponse}" />
    public class AddListKeyHandler : IRequestHandler<AddListKey, ApplicationResponse>
    {
        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public Task<ApplicationResponse> Handle(AddListKey request, CancellationToken cancellationToken)
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
                        request.KeyPayload.KeyListItem.KeyValues.Reverse();

                        foreach (var value in request.KeyPayload.KeyListItem.KeyValues)
                        {
                            db.ListLeftPush(request.KeyPayload.KeyListItem.KeyName, value.Value);
                        }

                        response = new ApplicationResponse(true, "Added or Updated Keys");
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
                response = new ApplicationResponse(false, ex.Message);
            }

            return Task.FromResult(response);
        }
    }
}