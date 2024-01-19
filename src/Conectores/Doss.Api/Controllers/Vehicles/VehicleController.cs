using Microsoft.AspNetCore.Mvc;
using Doss.Core.Seedwork;
using Doss.Core.Domain.OnBoard;
using Doss.Core.Queries.Vehicles;
using Doss.Core.Commands.Vehicles;
using MediatR;

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
        ///         "residentialWithServiceProviderId": "guid",
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
        ///     PUT /Todo
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
        ///     PUT /Todo
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
        /// Update type vehicle.
        /// </summary>
        /// <param name="command">Body</param>
        /// <returns>Result</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///         "description": "Car",
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpPost("type-vehicle")]
        public async Task<IActionResult> Put([FromBody] CreateTypeVehicleCommand command)
            => await HandleCommand(command);

        /// <summary>
        /// Create brand vehicle.
        /// </summary>
        /// <param name="command">Body</param>
        /// <returns>Result</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///         "typeVehicleId": Guid,
        ///         "description": "Car",
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpPost("brand-vehicle")]
        public async Task<IActionResult> Post([FromBody] CreateBrandVehicleCommand command)
            => await HandleCommand(command);

        /// <summary>
        /// Create model vehicle.
        /// </summary>
        /// <param name="command">Body</param>
        /// <returns>Result</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///         "brandVehicleId": Guid,
        ///         "description": "Car",
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpPost("model-vehicle")]
        public async Task<IActionResult> Post([FromBody] CreateModelVehicleCommand command)
            => await HandleCommand(command);            

        /// <summary>
        /// Update type vehicle.
        /// </summary>
        /// <param name="command">Body</param>
        /// <returns>Result</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Todo
        ///     {
        ///         "typeVehicleId": Guid,
        ///         "description": "Car",
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpPut("type-vehicle")]
        public async Task<IActionResult> Put([FromBody] UpdateTypeVehicleCommand command)
            => await HandleCommand(command);

        /// <summary>
        /// Update brand vehicle.
        /// </summary>
        /// <param name="command">Body</param>
        /// <returns>Result</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Todo
        ///     {
        ///         "typeVehicleId": Guid,
        ///         "brandVehicleId": Guid,
        ///         "description": "Car",
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpPut("brand-vehicle")]
        public async Task<IActionResult> Put([FromBody] UpdateBrandVehicleCommand command)
            => await HandleCommand(command);

        /// <summary>
        /// Update model vehicle.
        /// </summary>
        /// <param name="command">Body</param>
        /// <returns>Result</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Todo
        ///     {
        ///         "modelVehicleId": Guid,
        ///         "brandVehicleId": Guid,
        ///         "description": "Car",
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpPut("model-vehicle")]
        public async Task<IActionResult> Put([FromBody] UpdateModelVehicleCommand command)
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
        public async Task<IActionResult> Get([FromQuery] ReturnVehiclesByServiceProviderIdQuery query)
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
        [HttpGet("residential/{ResidentialWithServiceProviderId}/all")]
        public async Task<IActionResult> Get([FromRoute] ReturnVehiclesByResidentialIdQuery query)
            => await HandleQuery<ReturnVehiclesByResidentialIdQuery, ReturnVehiclesByResidentialIdQuery.Response>(query);

        /// <summary>
        /// Return vehicle by id.
        /// </summary>
        /// <param name="query">Quey</param>
        /// <returns>Return all vehicle of service provider</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result<ReturnVehicleByIdQuery>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] ReturnVehicleByIdQuery query)
            => await HandleQuery<ReturnVehicleByIdQuery, ReturnVehicleByIdQuery.Response>(query);


        /// <summary>
        /// Return type vehicle.
        /// </summary>
        /// <param name="query">Quey</param>
        /// <returns>Return all type vehicle</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result<ReturnTypeVehicleAllQuery>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpGet("type-vehicles")]
        public async Task<IActionResult> Get([FromRoute] ReturnTypeVehicleAllQuery query)
            => await HandleQuery<ReturnTypeVehicleAllQuery, ReturnTypeVehicleAllQuery.Response>(query);

        /// <summary>
        /// Return brand vehicle.
        /// </summary>
        /// <param name="query">Quey</param>
        /// <returns>Return all brand vehicle</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result<ReturnBrandVehicleAllQuery>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpGet("{typeVehicleId}/brand-vehicles")]
        public async Task<IActionResult> Get([FromRoute] ReturnBrandVehicleAllQuery query)
            => await HandleQuery<ReturnBrandVehicleAllQuery, ReturnBrandVehicleAllQuery.Response>(query);

        /// <summary>
        /// Return model vehicle.
        /// </summary>
        /// <param name="query">Quey</param>
        /// <returns>Return all brand vehicle</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result<ReturnModelVehicleAllQuery>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpGet("{brandVehicleId}/model-vehicles")]
        public async Task<IActionResult> Get([FromRoute] ReturnModelVehicleAllQuery query)
            => await HandleQuery<ReturnModelVehicleAllQuery, ReturnModelVehicleAllQuery.Response>(query);
    }
}
