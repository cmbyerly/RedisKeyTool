using MediatR;
using RadishV2.Server.Application.Command;
using RadishV2.Server.Application.Utils;
using RadishV2.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace RadishV2.Server.Application.Handler
{
    /// <summary>
    /// Add String Key Handler
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{RadishV2.Server.Application.Command.AddStringKey, RadishV2.Shared.ApplicationResponse}" />
    public class AddStringKeyHandler : IRequestHandler<AddStringKey, ApplicationResponse>
    {
        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public Task<ApplicationResponse> Handle(AddStringKey request, CancellationToken cancellationToken)
        {
            ApplicationResponse response;

            var redisServer = ConnectionBuilder.BuildConnectToRedis(request.KeyPayload.RedisSetting);

            if (redisServer != null)
            {
                var db = redisServer.GetDatabase(request.KeyPayload.RedisSetting.SelectedDatabase);
                db.StringSet(request.KeyPayload.KeyListItem.KeyName, request.KeyPayload.KeyListItem.KeyValues[0].Value);

                response = new ApplicationResponse(true, "Added or Updated Keys");
            }
            else
            {
                response = new ApplicationResponse(true, "Failed to Add or Update Keys");
            }

            redisServer.Dispose();

            return Task.FromResult(response);
        }
    }
}