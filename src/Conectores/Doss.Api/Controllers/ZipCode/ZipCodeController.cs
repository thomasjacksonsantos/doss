using Microsoft.AspNetCore.Mvc;
using Doss.Core.Commands.OnBoard.ServiceProviders;
using Doss.Core.Seedwork;
using MediatR;
using Doss.Core.Queries.ZipCode;

namespace Doss.Api.Controllers.ServiceProvidersOnBoard
{
    /// <summary>
    /// Class ServiceProviderOnBoardAddressController
    /// </summary>
    [Route("api/v1/zipcode")]
    [ApiController]
    public class ZipCodeController : DossBaseController
    {
        /// <summary>
        /// Constructor ServiceProviderOnBoardAddressController
        /// </summary>
        /// <param name="mediator">mediator</param>
        public ZipCodeController(IMediator mediator)
            : base(mediator) { }

        /// <summary>
        /// Return the service provider onboard by id.
        /// </summary>
        /// <param name="query">Quey</param>
        /// <returns>Return all bank</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpGet("search/{code}")]
        public async Task<IActionResult> Get([FromRoute] ZipCodeQuery query)
                => await HandleQuery<ZipCodeQuery, ZipCodeQuery.Response>(query);

    }
}
