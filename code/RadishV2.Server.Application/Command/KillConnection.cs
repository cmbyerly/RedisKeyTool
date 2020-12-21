using MediatR;
using RadishV2.Shared;

namespace RadishV2.Server.Application.Command
{
    /// <summary>
    /// Get the redis keys command
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{RadishV2.Shared.KeyListItem}}" />
    public class KillConnection : IRequest<bool>
    {
        public KillConnection()
        {
        }

        /// <summary>
        /// Gets or sets the redis setting.
        /// </summary>
        /// <value>
        /// The redis setting.
        /// </value>
        public ConnectionKiller ConnectionKiller { get; set; }
    }
}