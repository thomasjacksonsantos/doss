using Microsoft.AspNetCore.Mvc;
using Doss.Core.Seedwork;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using Microsoft.Identity.Web.Resource;

namespace Doss.Api.Controllers;

/// <summary>
/// Class DossBaseController
/// </summary>
[Authorize]
[ApiController]
[RequiredScope("tasks.read")]
public class DossBaseController : ControllerBase
{
    private UsuarioLogado? usuarioLogado;
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor DossBaseController
    /// </summary>
    /// <param name="mediator">mediator</param>
    public DossBaseController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    
    /// <summary>
    /// HandlerCommand
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    /// <param name="command">command</param>
    /// <returns>IActionResult</returns>
    protected async Task<IActionResult> HandleCommand<T>(T command)
      where T : Doss.Core.Seedwork.Command
    {
        var user = SetupUsuarioLogado();
        command.User = new UserCommand(user.Id, user.Name, user.Lastname, user.Emails);
        return Result(await mediator.Send(command));
    }

    /// <summary>
    /// HandleCommand
    /// </summary>
    /// <typeparam name="TCommand">TCommand</typeparam>
    /// <typeparam name="TResponse">TResponse</typeparam>
    /// <param name="command">Command</param>
    /// <returns>IActionResult</returns>
    /// <exception cref="NotImplementedException">Exception</exception>
    protected async Task<IActionResult> HandleCommand<TCommand, TResponse>(TCommand command)
        where TCommand : Command<TResponse>
    {
        var user = SetupUsuarioLogado();

        if (user is not { }) throw new NotImplementedException("User not found in token.");

        command.User = new UserCommand(user.Id, user.Name, user.Lastname, user.Emails);

        return Result(await mediator.Send(command));
    }

    /// <summary>
    /// HandleQuery
    /// </summary>
    /// <typeparam name="TRequest">TRequest</typeparam>
    /// <typeparam name="TResponse">TResponse</typeparam>
    /// <param name="request">request</param>
    /// <returns>IActionResult</returns>
    protected async Task<IActionResult> HandleQuery<TRequest, TResponse>(TRequest request)
        where TRequest : Query<TResponse>
    {
        var user = SetupUsuarioLogado();

        request.User = new UserQuery(user.Id, user.Name, user.Lastname, user.Emails);

        return Result(await mediator.Send(request));
    }

    private IActionResult Result(Result result)
    {
        //var usuario = await mediator.Send(new GetUsuarioByIdQuery { Id = usuarioLogado.Id });
        //if (usuario.Success)
        //    if (!User.Claims.Any(c => c.ValueType == "perfil" && c.Value == usuario.Data.Perfil.PerfilNome))
        //    {
        //        var claimsIdentity = (ClaimsIdentity)User.Identity;
        //        claimsIdentity.AddClaim(new Claim("perfil", $"{usuario.Data.Perfil.PerfilNome}"));
        //        foreach (var claim in usuario.Data.Perfil.Claims)
        //            claimsIdentity.AddClaim(new Claim($"{claim.Id}", $"{claim.Value}"));
        //    }

        return result.ResultType switch
        {
            ResultType.Ok => Ok(result),
            ResultType.NotFound => NotFound(result),
            ResultType.Error => BadRequest(result),
            _ => throw new NotImplementedException(),
        };
    }

    /// <summary>
    /// Setup usuario logado
    /// </summary>
    /// <returns>UsuarioLogado</returns>
    /// <exception cref="NotImplementedException">Exception</exception>
    protected UsuarioLogado SetupUsuarioLogado()
    {
        if (usuarioLogado is not null)
            return usuarioLogado;

        var userClaims = User.Claims.Select(x => new { x.Type, x.Value }).ToList();
        var subject = userClaims.FirstOrDefault(x => x.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (subject is null)
            throw new NotImplementedException("User not found in token.");

        usuarioLogado = new UsuarioLogado(Guid.ParseExact(subject, "D"),
                                               userClaims!.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.GivenName)!.Value,
                                               userClaims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Surname)!.Value,
                                               userClaims.Where(c => c.Type == "emails").Select(c => c.Value).ToList());

        return usuarioLogado;
    }
}

/// <summary>
/// Class UsuarioLogado
/// </summary>
public class UsuarioLogado
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Lastname
    /// </summary>
    public string Lastname { get; set; }
    /// <summary>
    /// Emails
    /// </summary>
    public IEnumerable<string> Emails { get; set; }
    /// <summary>
    /// Constructor UsuarioLogado
    /// </summary>
    /// <param name="id">Id</param>
    /// <param name="name">Name</param>
    /// <param name="lastname">Lastname</param>
    /// <param name="emails">Emails</param>
    public UsuarioLogado(Guid id, string name, string lastname, IEnumerable<string> emails)
        => (Id, Name, Lastname, Emails) = (id, name, lastname, emails);
}
