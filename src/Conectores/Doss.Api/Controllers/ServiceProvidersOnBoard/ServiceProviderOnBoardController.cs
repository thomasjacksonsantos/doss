using Microsoft.AspNetCore.Mvc;
using Doss.Core.Commands.OnBoard.ServiceProviders;
using Doss.Core.Seedwork;
using Doss.Core.Domain.OnBoard;
using Doss.Core.Queries.ServiceProvidersOnBoard;
using MediatR;

namespace Doss.Api.Controllers.ServiceProvidersOnBoard
{
    /// <summary>
    /// Class ServiceProviderOnBoardAddressController
    /// </summary>
    [Route("api/v1/service-provider/onboard")]
    [ApiController]
    public class ServiceProviderOnBoardController : DossBaseController
    {
        /// <summary>
        /// Constructor ServiceProviderOnBoardAddressController
        /// </summary>
        /// <param name="mediator">mediator</param>
        public ServiceProviderOnBoardController(IMediator mediator)
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
        ///         "zipCode": "13100-474",
        ///         "number": "430"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpPost("address")]
        public async Task<IActionResult> Post([FromBody] ServiceProviderOnBoardAddressCommand command)
                => await HandleCommand(command);

        /// <summary>
        /// Criar a area de cobertura no fluxo de onboard service provider.
        /// </summary>
        /// <param name="command">Body</param>
        /// <returns>Result</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///         "CoverageArea": 50
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpPost("coverage-area")]
        public async Task<IActionResult> Post([FromBody] ServiceProviderOnBoardCoverageCommand command)
            => await HandleCommand(command);

        /// <summary>
        /// Create the payment method in the onboard service provider flow.
        /// </summary>
        /// <param name="command">Body</param>
        /// <returns>Result</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpPost("finalize")]
        public async Task<IActionResult> Post([FromBody] ServiceProviderOnBoardFinalizeCommand command)
            => await HandleCommand(command);

        /// <summary>
        /// Create the payment method in the onboard service provider flow.
        /// </summary>
        /// <param name="command">Body</param>
        /// <returns>Result</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///         "bankId": "7fb25057-7bcc-4caa-9e45-b87512f27307",
        ///         "agency": "202020",
        ///         "account": "20203-34",
        ///         "plans": [
        ///             {
        ///                 "description": "Residencia",
        ///                 "price": 100.00
        ///             },
        ///             {
        ///                 "description": "Comercial",
        ///                 "price": 300.00
        ///             }
        ///         ]
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpPost("form-payment")]
        public async Task<IActionResult> Post([FromBody] ServiceProviderOnBoardFormPaymentCommand command)
            => await HandleCommand(command);

        /// <summary>
        /// Create the service provider in the onboard flow.
        /// </summary>
        /// <param name="command">Body</param>
        /// <returns>Result</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///         "document": "356655887",
        ///         "name": "Thomas Jackson",
        ///         "photo": "base64",
        ///         "phone": "19994282237"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpPost("user-information")]
        public async Task<IActionResult> Post([FromBody] ServiceProviderOnBoardUserInformationCommand command)
            => await HandleCommand(command);

        /// <summary>
        /// Create the vehicle in the onboard service provider flow.
        /// </summary>
        /// <param name="command">Body</param>
        /// <returns>Result</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///         "brand": "Honda",
        ///         "model": "Civic",
        ///         "color": "Preto",
        ///         "plate": "dxu-5427",
        ///         "photo": "base64",
        ///         "defaultVehicle": true,
        ///         "vehicleType": "car"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpPost("vehicle")]
        public async Task<IActionResult> Post([FromBody] ServiceProviderOnBoardVehicleCommand command)
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
        public async Task<IActionResult> Post([FromBody] ServiceProviderOnBoardTermsAcceptCommand command)
            => await HandleCommand(command);

        /// <summary>
        /// Return the service provider onboard by id.
        /// </summary>
        /// <param name="query">Quey</param>
        /// <returns>Return all bank</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(typeof(Result<OnBoardServiceProvider>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] ReturnServiceProviderOnBoardByIdQuery query)
            => await HandleQuery<ReturnServiceProviderOnBoardByIdQuery, OnBoardServiceProvider>(query);
    }
}
