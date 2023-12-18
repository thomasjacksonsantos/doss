using Microsoft.AspNetCore.Mvc;
using Doss.Core.Commands.OnBoard.Residentials;
using Doss.Core.Seedwork;
using Doss.Core.Domain.OnBoard;
using Doss.Core.Queries.ResidentialsOnBoard;
using MediatR;

namespace Doss.Api.Controllers.ResidentialsOnBoard
{
    /// <summary>
    /// Class ResidentialOnBoardController
    /// </summary>
    [Route("api/v1/residential/onboard")]
    [ApiController]
    public class ResidentialOnBoardController : DossBaseController
    {
        /// <summary>
        /// Constructor ResidentialOnBoardController
        /// </summary>
        /// <param name="mediator">mediator</param>
        public ResidentialOnBoardController(IMediator mediator)
            : base(mediator) { }

        /// <summary>
        /// Creates the onboard flow resident.
        /// </summary>
        /// <param name="command">Body</param>
        /// <returns>Result</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "document": "356655887",
        ///        "name": "Thomas Jackson",
        ///        "photo": "base64",
        ///        "phone": "19994282237"
        ///    }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpPost("user-information")]
        public async Task<IActionResult> Post([FromBody] ResidentialOnBoardUserInformationCommand command)
            => await HandleCommand(command);

        /// <summary>
        /// Creates resident onboard flow address.
        /// </summary>
        /// <param name="command">Body</param>
        /// <returns>Result</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "country": "BR",
        ///        "state": "Sao Paulo",
        ///        "city": "Sao Paulo",
        ///        "street": "Rua amadeu mendes",
        ///        "complement": "Casa do fundo",
        ///        "zipCode": "13100-474",
        ///        "number": "430"
        ///    }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpPost("address")]
        public async Task<IActionResult> Post([FromBody] ResidentialOnBoardAddressCommand command)
            => await HandleCommand(command);

        /// <summary>
        /// information the terms and acceptance confirmed by the customer
        /// </summary>
        /// <param name="command">Body</param>
        /// <returns>Result</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///         "TermsAccept": true,
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpPost("terms")]
        public async Task<IActionResult> Post([FromBody] ResidentialOnBoardTermsAcceptCommand command)
            => await HandleCommand(command);

        /// <summary>
        /// Select the service provider that will secure your home.
        /// </summary>
        /// <param name="command">Body</param>
        /// <returns>Result</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///         "ServiceProviderPlanId": Guid,
        ///         "PlanId": Guid
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpPost("service-provider/{ServiceProviderPlanId}/plan/{planId}")]
        public async Task<IActionResult> Post([FromRoute] ResidentialOnBoardServiceProviderWithPlanCommand command)
            => await HandleCommand(command);            

        /// <summary>
        /// Return the residential onboard by id.
        /// </summary>
        /// <param name="query">Quey</param>
        /// <returns>Return all bank</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result<OnBoardResidential>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpGet()]
        public async Task<IActionResult> Get([FromRoute] ReturnResidentialOnBoardByIdQuery query)
        => await HandleQuery<ReturnResidentialOnBoardByIdQuery, OnBoardResidential>(query);
    }
}
