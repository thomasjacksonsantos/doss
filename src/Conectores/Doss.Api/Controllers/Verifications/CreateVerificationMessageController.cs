using Microsoft.AspNetCore.Mvc;
using Doss.Core.Seedwork;
using MediatR;
using Doss.Core.Commands.ServiceProviders;

namespace Doss.Api.Controllers.Verifications
{
    /// <summary>
    /// Class CreateVerificationMessageController
    /// </summary>
    [Route("api/verification/message")]
    [ApiController]
    public class CreateVerificationMessageController : DossBaseController
    {
        /// <summary>
        /// Constructor CreateVerificationMessageController
        /// </summary>
        /// <param name="mediator">mediator</param>
        public CreateVerificationMessageController(IMediator mediator)
            : base(mediator) { }

        /// <summary>
        /// Create verification message.
        /// </summary>
        /// <param name="command">Command</param>
        /// <returns>Return all bank</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpPost("verification/message")]
        public async Task<IActionResult> Post([FromBody] CreateVerificationMessageCommand command)
                => await HandleCommand(command);

    }
}
