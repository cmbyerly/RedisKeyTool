using MediatR;

namespace RedisKeyTool.Application.Command
{
    /// <summary>
    /// This is the ping class.
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.String}" />
    public class Ping : IRequest<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ping"/> class.
        /// </summary>
        public Ping() { }
    }
}