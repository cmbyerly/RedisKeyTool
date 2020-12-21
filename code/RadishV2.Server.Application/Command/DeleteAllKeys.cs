using MediatR;
using RadishV2.Shared;

namespace RadishV2.Server.Application.Command
{
    /// <summary>
    /// Delete Key
    /// </summary>
    /// <seealso cref="MediatR.IRequest{RadishV2.Shared.ApplicationResponse}" />
    public class DeleteAllKeys : IRequest<ApplicationResponse>
    {
        public DeleteAllKeys()
        {
        }

        /// <summary>
        /// Gets or sets the key payload.
        /// </summary>
        /// <value>
        /// The key payload.
        /// </value>
        public KeyPayload KeyPayload { get; set; }
    }
}