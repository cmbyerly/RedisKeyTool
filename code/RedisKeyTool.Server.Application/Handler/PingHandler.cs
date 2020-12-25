using MediatR;
using Microsoft.Extensions.Logging;
using RedisKeyTool.Application.Command;
using System.Threading;
using System.Threading.Tasks;

namespace RedisKeyTool.Application.Handler
{
    /// <summary>
    /// This is the ping handler class.
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{RedisKeyTool.Application.Command.Ping, System.String}" />
    public class PingHandler : IRequestHandler<Ping, string>
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<PingHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PingHandler"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public PingHandler(ILogger<PingHandler> logger)
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
        public Task<string> Handle(Ping request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("PONG");
            return Task.FromResult("Pong");
        }
    }
}