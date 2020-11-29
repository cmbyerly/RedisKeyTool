using MediatR;
using RadishV2.Application.Command;
using System.Threading;
using System.Threading.Tasks;

namespace RadishV2.Application.Handler
{
    /// <summary>
    /// This is the ping handler class.
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{RadishV2.Application.Command.Ping, System.String}" />
    public class PingHandler : IRequestHandler<Ping, string>
    {
        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public Task<string> Handle(Ping request, CancellationToken cancellationToken)
        {
            return Task.FromResult("Pong");
        }
    }
}