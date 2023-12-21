using Microsoft.AspNetCore.Mvc;
using Doss.Core.Seedwork;
using Doss.Core.Queries.Residentials;
using MediatR;

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
        /// returns the total number of active users.
        /// </summary>
        /// <param name="query">Quey</param>
        /// <returns>Return response total active</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result<ActiveResidentialQuery.Response>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpGet("active")]
        public async Task<IActionResult> Get([FromRoute] ActiveResidentialQuery query)
            => await HandleQuery<ActiveResidentialQuery, ActiveResidentialQuery.Response>(query);

        /// <summary>
        /// returns the residential.
        /// </summary>
        /// <param name="query">Quey</param>
        /// <returns>Return response total active</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result<ResidentialListByServiceProviderIdQuery.Response>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] ResidentialListByServiceProviderIdQuery query)
            => await HandleQuery<ResidentialListByServiceProviderIdQuery, ResidentialListByServiceProviderIdQuery.Response>(query);            
    }
}
