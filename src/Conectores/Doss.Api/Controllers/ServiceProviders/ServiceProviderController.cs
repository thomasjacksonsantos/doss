using Microsoft.AspNetCore.Mvc;
using Doss.Core.Commands.ServiceProviders;
using Doss.Core.Seedwork;
using Doss.Core.Queries.ServiceProviders;
using Doss.Core.Domain.Plans;
using MediatR;

namespace Doss.Api.Controllers.ServiceProviders;

/// <summary>
/// Class ServiceProviderController
/// </summary>
[Route("api/v1/service-provider")]
[ApiController]
public class ServiceProviderController : DossBaseController
{
    /// <summary>
    /// Constructor ServiceProviderController
    /// </summary>
    /// <param name="mediator">mediator</param>
    public ServiceProviderController(IMediator mediator)
        : base(mediator) { }

    /// <summary>
    /// Creates the onboard flow service provider.
    /// </summary>
    /// <param name="command">Body</param>
    /// <returns>Result</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Todo
    ///     {
    ///         "name": "Maria dos Santos",
    ///         "document": "12454454",
    ///         "phone": "19594561545",
    ///         "photo": "Rua amadeu mendes",
    ///         "completedRegistration": true,
    ///         "userStatus": "Active"
    ///    }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] UpsertServiceProviderCommand command)
        => await HandleCommand(command);

    /// <summary>
    /// Create new alert to service provider.
    /// </summary>
    /// <param name="command">command</param>
    /// <returns>Results ok</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Todo
    ///     {
    ///         "description": "Alert to service provider"
    ///    }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [HttpPost("alert")]
    public async Task<IActionResult> Post([FromBody] ServiceProviderAlertCommand command)
        => await HandleCommand(command);

    /// <summary>
    /// Create new alert to service provider.
    /// </summary>
    /// <param name="command">command</param>
    /// <returns>Results ok</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Todo
    ///     {
    ///         "userStatus": "Active" --Inactive
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [HttpPut("status/{UserStatus}")]
    public async Task<IActionResult> Put([FromRoute] UpdateServiceProviderStatusCommand command)
        => await HandleCommand(command);

    /// <summary>
    /// Update service provider.
    /// </summary>
    /// <param name="command">command</param>
    /// <returns>Results ok</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT /Todo
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    [ProducesResponseType(typeof(Result<UpdateServiceProviderCommand>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<IActionResult> Put([FromRoute] UpdateServiceProviderCommand command)
        => await HandleCommand(command);


    /// <summary>
    /// Return a service provider list by zipcode.
    /// </summary>
    /// <param name="query">Quey</param>
    /// <returns>Return all bank</returns>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    [ProducesResponseType(typeof(Result<IEnumerable<Core.Domain.ServiceProviders.ServiceProvider>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [HttpGet("zipcode/{zipcode}")]
    public async Task<IActionResult> Get([FromRoute] ReturnServiceProvidersByZipCodeQuery query)
        => await HandleQuery<ReturnServiceProvidersByZipCodeQuery, IEnumerable<Core.Domain.ServiceProviders.ServiceProvider>>(query);

    /// <summary>
    /// Return a list of provider plans.
    /// </summary>
    /// <param name="query">Quey</param>
    /// <returns>Return all bank</returns>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    [ProducesResponseType(typeof(Result<IEnumerable<Plan>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [HttpGet("{id}/plans")]
    public async Task<IActionResult> Get([FromRoute] ReturnServiceProviderPlanByIdQuery query)
        => await HandleQuery<ReturnServiceProviderPlanByIdQuery, IEnumerable<Plan>>(query);

    /// <summary>
    /// Check status service provider.
    /// </summary>
    /// <param name="query">Quey</param>
    /// <returns>ServiceProviderCheck</returns>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    [ProducesResponseType(typeof(Result<ServiceProviderCheckQuery.Response>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [HttpGet("check")]
    public async Task<IActionResult> Get([FromRoute] ServiceProviderCheckQuery query)
        => await HandleQuery<ServiceProviderCheckQuery, ServiceProviderCheckQuery.Response>(query);


    /// <summary>
    /// Return a service provider list by zipcode.
    /// </summary>
    /// <param name="query">Quey</param>
    /// <returns>Return all bank</returns>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    [ProducesResponseType(typeof(Result<ServiceProviderInfoQuery.Response>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [HttpGet("info")]
    public async Task<IActionResult> Get([FromRoute] ServiceProviderInfoQuery query)
        => await HandleQuery<ServiceProviderInfoQuery, ServiceProviderInfoQuery.Response>(query);

    /// <summary>
    /// Return list alerts to service provider with paged.
    /// </summary>
    /// <param name="query">Quey</param>
    /// <returns>Return list alert</returns>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    [ProducesResponseType(typeof(Result<ServiceProviderAlertByIdQuery.Response>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [HttpGet("alert")]
    public async Task<IActionResult> Get([FromRoute] ServiceProviderAlertByIdQuery query)
        => await HandleQuery<ServiceProviderAlertByIdQuery, ServiceProviderAlertByIdQuery.Response>(query);

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
    /// returns the total profit by active and month.
    /// </summary>
    /// <param name="query">Quey</param>
    /// <returns>Return response total active</returns>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    [ProducesResponseType(typeof(Result<ActiveResidentialQuery.Response>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [HttpGet("profit")]
    public async Task<IActionResult> Get([FromRoute] ReturnServiceProviderPlanTotalProfitQuery query)
        => await HandleQuery<ReturnServiceProviderPlanTotalProfitQuery, ReturnServiceProviderPlanTotalProfitQuery.Response>(query);

    /// <summary>
    /// returns all customers related to the service provider
    /// </summary>
    /// <param name="query">Quey</param>
    /// <returns>Return response total active</returns>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    [ProducesResponseType(typeof(Result<ResidentialListByServiceProviderIdQuery.Response>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [HttpGet("customers")]
    public async Task<IActionResult> Get([FromQuery] ResidentialListByServiceProviderIdQuery query)
        => await HandleQuery<ResidentialListByServiceProviderIdQuery, ResidentialListByServiceProviderIdQuery.Response>(query);

    /// <summary>
    /// returns the residential details.
    /// </summary>
    /// <param name="query">Quey</param>
    /// <returns>Return response total active</returns>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    [ProducesResponseType(typeof(Result<ResidentialListByServiceProviderIdQuery.Response>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [HttpGet("customer/{residentialId}/details")]
    public async Task<IActionResult> Get([FromRoute] ResidentialDetailsByServiceProviderIdQuery query)
        => await HandleQuery<ResidentialDetailsByServiceProviderIdQuery, ResidentialDetailsByServiceProviderIdQuery.Response>(query);

    /// <summary>
    /// returns the vehicles by residential id.
    /// </summary>
    /// <param name="query">Quey</param>
    /// <returns>Return response vehicle all</returns>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    [ProducesResponseType(typeof(Result<ResidentialVehicleListByServiceProviderIdQuery.Response>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [HttpGet("customer/{residentialId}/vehicles")]
    public async Task<IActionResult> Get([FromRoute] ResidentialVehicleListByServiceProviderIdQuery query)
        => await HandleQuery<ResidentialVehicleListByServiceProviderIdQuery, ResidentialVehicleListByServiceProviderIdQuery.Response>(query);

    /// <summary>
    /// return service provider.
    /// </summary>
    /// <param name="query">Quey</param>
    /// <returns>Return response vehicle all</returns>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    [ProducesResponseType(typeof(Result<ResidentialVehicleListByServiceProviderIdQuery.Response>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<IActionResult> Get([FromRoute] ReturnServiceProviderById query)
        => await HandleQuery<ReturnServiceProviderById, ReturnServiceProviderById.Response>(query);        
}