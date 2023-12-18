using Microsoft.AspNetCore.Mvc;
using Doss.Core.Seedwork;
using Doss.Core.Commands.Verifications;
using Doss.Core.Queries.Verifications;
using MediatR;
using Doss.Core.Queries.ServiceProviders;

namespace Doss.Api.Controllers.ServiceProviders;

/// <summary>
/// Class VerificationController
/// </summary>
[Route("api/v1/verification-request")]
[ApiController]
public class VerificationController : DossBaseController
{
    /// <summary>
    /// Constructor VerificationController
    /// </summary>
    /// <param name="mediator">mediator</param>
    public VerificationController(IMediator mediator)
        : base(mediator) { }

    /// <summary>
    /// Update status verification
    /// </summary>
    /// <param name="command">command</param>
    /// <returns>Results ok</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Todo
    ///     {
    ///         "VerificationId": "Guid",
    ///         "Status": "VerificationStatus"
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [HttpPut("{VerificationId}/status/{Status}")]
    public async Task<IActionResult> Put([FromRoute] UpdateServiceProviderVerificationStatusCommand command)
        => await HandleCommand(command);

    /// <summary>
    /// return all service provider checks paged.
    /// </summary>
    /// <param name="query">Quey</param>
    /// <returns>Return all bank</returns>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    [ProducesResponseType(typeof(Result<ServiceProviderVerificationRequestAllQuery.Response>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [HttpGet("all")]
    public async Task<IActionResult> Get([FromRoute] ServiceProviderVerificationRequestAllQuery query)
    => await HandleQuery<ServiceProviderVerificationRequestAllQuery, ServiceProviderVerificationRequestAllQuery.Response>(query);

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
    [HttpPost()]
    public async Task<IActionResult> Post([FromBody] ResidentialVerificationRequestCommand command)
        => await HandleCommand(command);

    /// <summary>
    /// Create verification message.
    /// </summary>
    /// <param name="command">Command</param>
    /// <returns>Return all bank</returns>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [HttpPost("chat")]
    public async Task<IActionResult> Post([FromBody] VerificationChatCommand command)
            => await HandleCommand(command);

    /// <summary>
    /// Checks if there is any verification requested by the resident.
    /// </summary>
    /// <param name="query">Quey</param>
    /// <returns>Return all bank</returns>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    [ProducesResponseType(typeof(Result<ExistsVerificationRequestByResidentialQuery.Response>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [HttpGet("check")]
    public async Task<IActionResult> Get([FromRoute] ExistsVerificationRequestByResidentialQuery query)
            => await HandleQuery<ExistsVerificationRequestByResidentialQuery, ExistsVerificationRequestByResidentialQuery.Response>(query);
}