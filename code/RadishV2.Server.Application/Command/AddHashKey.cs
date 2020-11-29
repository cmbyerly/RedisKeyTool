using MediatR;
using RadishV2.Shared;

namespace RadishV2.Server.Application.Command
{
    /// <summary>
    /// Add a hash key
    /// </summary>
    /// <seealso cref="MediatR.IRequest{RadishV2.Shared.ApplicationResponse}" />
    public class AddHashKey : IRequest<ApplicationResponse>
    {
        /// <summary>
        /// Gets or sets the key payload.
        /// </summary>
        /// <value>
        /// The key payload.
        /// </value>
        public KeyPayload KeyPayload { get; set; }
    }
}