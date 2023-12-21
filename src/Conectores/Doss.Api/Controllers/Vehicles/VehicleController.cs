using Microsoft.AspNetCore.Mvc;
using Doss.Core.Commands.OnBoard.ServiceProviders;
using Doss.Core.Seedwork;
using Doss.Core.Domain.OnBoard;
using Doss.Core.Queries.ServiceProvidersOnBoard;
using MediatR;
using Doss.Core.Queries.Vehicles;
using Doss.Core.Commands.Vehicles;

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
        /// Create vehicle of residential.
        /// </summary>
        /// <param name="command">Body</param>
        /// <returns>Result</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///         "brand": "honda",
        ///         "model": "civic",
        ///         "color": "black",
        ///         "plate": "xxx8dd",
        ///         "photo": "base64",
        ///         "defaultVehicle": true,
        ///         "vehicleType": "Car"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpPost("residential")]
        public async Task<IActionResult> Post([FromBody] CreateResidentialVehicleCommand command)
                => await HandleCommand(command);               

        /// <summary>
        /// Create vehicle of service provider.
        /// </summary>
        /// <param name="command">Body</param>
        /// <returns>Result</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///         "brand": "honda",
        ///         "model": "civic",
        ///         "color": "black",
        ///         "plate": "xxx8dd",
        ///         "photo": "base64",
        ///         "defaultVehicle": true,
        ///         "vehicleType": "Car"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpPost("service-provider")]
        public async Task<IActionResult> Post([FromBody] CreateServiceProviderVehicleCommand command)
                => await HandleCommand(command);                

        /// <summary>
        /// Update vehicle of residential.
        /// </summary>
        /// <param name="command">Body</param>
        /// <returns>Result</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///         "id": Guid,
        ///         "brand": "honda",
        ///         "model": "civic",
        ///         "color": "black",
        ///         "plate": "xxx8dd",
        ///         "photo": "base64",
        ///         "defaultVehicle": true,
        ///         "vehicleType": "Car"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpPut("residential")]
        public async Task<IActionResult> Put([FromBody] UpdateResidentialVehicleCommand command)
            => await HandleCommand(command);                 
       
        /// <summary>
        /// Update vehicle of service provider.
        /// </summary>
        /// <param name="command">Body</param>
        /// <returns>Result</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///         "id": Guid,
        ///         "brand": "honda",
        ///         "model": "civic",
        ///         "color": "black",
        ///         "plate": "xxx8dd",
        ///         "photo": "base64",
        ///         "defaultVehicle": true,
        ///         "vehicleType": "Car"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpPut("service-provider")]
        public async Task<IActionResult> Put([FromBody] UpdateServiceProviderVehicleCommand command)
            => await HandleCommand(command);

        /// <summary>
        /// Return list vehicles service provider.
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

        /// <summary>
        /// Return list vehicles residential.
        /// </summary>
        /// <param name="query">Quey</param>
        /// <returns>Return all vehicle of service provider</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result<OnBoardServiceProvider>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpGet("residential/all")]
        public async Task<IActionResult> Get([FromRoute] ReturnVehiclesByResidentialIdQuery query)
            => await HandleQuery<ReturnVehiclesByResidentialIdQuery, ReturnVehiclesByResidentialIdQuery.Response>(query);
    }
}
