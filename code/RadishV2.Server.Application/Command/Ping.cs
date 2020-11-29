using MediatR;

namespace RadishV2.Application.Command
{
    /// <summary>
    /// This is the ping class.
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.String}" />
    public class Ping : IRequest<string> { }
}