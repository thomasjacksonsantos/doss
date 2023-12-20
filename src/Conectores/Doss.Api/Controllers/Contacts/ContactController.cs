using Microsoft.AspNetCore.Mvc;
using Doss.Core.Seedwork;
using Doss.Core.Queries.Residentials;
using Doss.Core.Queries.Contacts;
using MediatR;
using Doss.Core.Commands.Contacts;

namespace Doss.Api.Controllers.ResidentialsOnBoard
{
    /// <summary>
    /// Class ContactController
    /// </summary>
    [Route("api/v1/contact")]
    [ApiController]
    public class ContactController : DossBaseController
    {
        /// <summary>
        /// Constructor ContactController
        /// </summary>
        /// <param name="mediator">mediator</param>
        public ContactController(IMediator mediator)
            : base(mediator) { }

        /// <summary>
        /// Creates useful contact.
        /// </summary>
        /// <param name="command">Body</param>
        /// <returns>Result</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///         "description": "Name of contact",
        ///         "number": "12454454",
        ///    }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpPost("useful")]
        public async Task<IActionResult> Post([FromBody] CreateUsefulContactsCommand command)
            => await HandleCommand(command);

        /// <summary>
        /// Update useful contact.
        /// </summary>
        /// <param name="command">Body</param>
        /// <returns>Result</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///         "id": "Guid",
        ///         "description": "Name of contact",
        ///         "number": "12454454",
        ///    }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpPut("useful")]
        public async Task<IActionResult> Put([FromBody] UpdateUsefulContactsCommand command)
            => await HandleCommand(command);

        /// <summary>
        /// Return list of contacts useful.
        /// </summary>
        /// <param name="query">Quey</param>
        /// <returns>Return all contacts emergency</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result<UsefulContactsQuery.Response>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpGet("useful")]
        public async Task<IActionResult> Get([FromRoute] UsefulContactsQuery query)
        => await HandleQuery<UsefulContactsQuery, UsefulContactsQuery.Response>(query);

        /// <summary>
        /// Return list of contacts residential.
        /// </summary>
        /// <param name="query">Quey</param>
        /// <returns>Return all contacts emergency</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result<ResidentialContactsQuery.Response>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpGet("residential")]
        public async Task<IActionResult> Get([FromRoute] ResidentialContactsQuery query)
        => await HandleQuery<ResidentialContactsQuery, ResidentialContactsQuery.Response>(query);
    }
}
