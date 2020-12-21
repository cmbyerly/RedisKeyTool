using MediatR;
using RadishV2.Shared;

namespace RadishV2.Server.Application.Command
{
    /// <summary>
    /// Add a list key
    /// </summary>
    /// <seealso cref="MediatR.IRequest{RadishV2.Shared.ApplicationResponse}" />
    public class AddListKey : IRequest<ApplicationResponse>
    {
        public AddListKey()
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