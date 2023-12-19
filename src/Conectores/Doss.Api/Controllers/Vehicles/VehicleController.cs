using Microsoft.AspNetCore.Mvc;
using Doss.Core.Commands.OnBoard.ServiceProviders;
using Doss.Core.Seedwork;
using Doss.Core.Domain.OnBoard;
using Doss.Core.Queries.ServiceProvidersOnBoard;
using MediatR;
using Doss.Core.Queries.Vehicles;

namespace Doss.Api.Controllers.ServiceProvidersOnBoard
{
    /// <summary>
    /// Class VehicleController
    /// </summary>
    [Route("api/v1/vehicle")]
    [ApiController]
    public class VehicleController : DossBaseController
    {
        /// <summary>
        /// Constructor VehicleController
        /// </summary>
        /// <param name="mediator">mediator</param>
        public VehicleController(IMediator mediator)
            : base(mediator) { }

        /// <summary>
        /// Create the address in the onboard service provider flow.
        /// </summary>
        /// <param name="command">Body</param>
        /// <returns>Result</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///         "country": "BR",
        ///         "state": "Sao Paulo",
        ///         "city": "Sao Paulo",
        ///         "street": "Rua amadeu mendes",
        ///         "complement": "Casa do fundo",
        ///         "zipCode": "13100-474",
        ///         "number": "430"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        // [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        // [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        // [HttpPost("address")]
        // public async Task<IActionResult> Post([FromBody] ServiceProviderOnBoardAddressCommand command)
        //         => await HandleCommand(command);
       
        /// <summary>
        /// Return list vehicles.
        /// </summary>
        /// <param name="query">Quey</param>
        /// <returns>Return all vehicle of service provider</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result<OnBoardServiceProvider>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpGet("service-provider/all")]
        public async Task<IActionResult> Get([FromRoute] ReturnVehiclesByServiceProviderIdQuery query)
            => await HandleQuery<ReturnVehiclesByServiceProviderIdQuery, ReturnVehiclesByServiceProviderIdQuery.Response>(query);
    }
}
