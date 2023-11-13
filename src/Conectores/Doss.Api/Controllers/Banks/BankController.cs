using Microsoft.AspNetCore.Mvc;
using Doss.Core.Commands.Banks;
using Doss.Core.Seedwork;
using Doss.Core.Queries.Banks;
using MediatR;

namespace Doss.Api.Controllers.Banks
{
    /// <summary>
    /// Class BankController
    /// </summary>
    [Route("api/v1/bank")]
    [ApiController]
    public class BankController : DossBaseController
    {
        /// <summary>
        /// Constructor BankController
        /// </summary>
        /// <param name="mediator"></param>
        public BankController(IMediator mediator)
            : base(mediator) { }

        /// <summary>
        /// Creates and update bank.
        /// </summary>
        /// <param name="command">Body</param>
        /// <returns>Result</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /Todo
        ///     {
        ///         "id": "E32A1315-9B12-448B-8DB0-96CB3FAE198B",
        ///         "name": "HSCB",
        ///         "bankStatus": "Active"
        ///     }
        ///     
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpPost]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] UpsertBankCommand command)
            => await HandleCommand(command);

        /// <summary>
        /// Return all registered banks.
        /// </summary>
        /// <param name="query">Quey</param>
        /// <returns>Return all bank</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result<BankAllQuery.Response>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> Get([FromBody] BankAllQuery query)
            => await HandleQuery<BankAllQuery, BankAllQuery.Response>(query);
    }
}
