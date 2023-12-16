using Microsoft.AspNetCore.Mvc;
using Doss.Core.Commands.OnBoard.Residentials;
using Doss.Core.Seedwork;
using Doss.Core.Domain.OnBoard;
using Doss.Core.Queries.ResidentialsOnBoard;
using MediatR;
using Doss.Core.Domain.Residentials;
using Doss.Core.Commands.Verifications;
using Doss.Core.Queries.Residentials;
using Doss.Core.Queries.ServiceProviders;

namespace Doss.Api.Controllers.ResidentialsOnBoard
{
    /// <summary>
    /// Class ResidentialController
    /// </summary>
    [Route("api/v1/residential")]
    [ApiController]
    public class ResidentialController : DossBaseController
    {
        /// <summary>
        /// Constructor ResidentialController
        /// </summary>
        /// <param name="mediator">mediator</param>
        public ResidentialController(IMediator mediator)
            : base(mediator) { }

        /// <summary>
        /// message requesting a check on the owner's residence.
        /// </summary>
        /// <param name="command">Body</param>
        /// <returns>Result</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "residentialWithServiceProviderId": Guid,
        ///        "message": "Description "
        ///    }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpPost("verification-request")]
        public async Task<IActionResult> Post([FromBody] ResidentialVerificationRequestCommand command)
            => await HandleCommand(command);


        /// <summary>
        /// Return the residential info by id.
        /// </summary>
        /// <param name="query">Quey</param>
        /// <returns>Return all bank</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result<ResidentialInfoQuery.Response>), StatusCodes.Status200OK)] 
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpGet("info")]
        public async Task<IActionResult> Get([FromRoute] ResidentialInfoQuery query)
        => await HandleQuery<ResidentialInfoQuery, ResidentialInfoQuery.Response>(query);


        /// <summary>
        /// Check if residential is completed register.
        /// </summary>
        /// <param name="query">Quey</param>
        /// <returns>Return all bank</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result<ResidentialCheckQuery.Response>), StatusCodes.Status200OK)] 
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpGet("check")]
        public async Task<IActionResult> Get([FromRoute] ResidentialCheckQuery query)
        => await HandleQuery<ResidentialCheckQuery, ResidentialCheckQuery.Response>(query);

        /// <summary>
        /// return all service provider checks.
        /// </summary>
        /// <param name="query">Quey</param>
        /// <returns>Return all bank</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result<ServiceProviderVerificationRequestAllQuery.Response>), StatusCodes.Status200OK)] 
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpGet("verification/all")]
        public async Task<IActionResult> Get([FromRoute] ServiceProviderVerificationRequestAllQuery query)
        => await HandleQuery<ServiceProviderVerificationRequestAllQuery, ServiceProviderVerificationRequestAllQuery.Response>(query);
    }
}
