using Doss.Core.Commands.OnBoard.ServiceProviders;
using Doss.Core.Domain.OnBoard;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Ageu.Core.Commands.OnBoard.ServiceProviders.Handlers;

public class ServiceProviderOnBoardUserInformationCommandHandler : BaseCommandHandler<ServiceProviderOnBoardUserInformationCommand, ServiceProviderOnBoardUserInformationCommandValidator>
{
    private readonly IOnBoardServiceProviderRepository onBoardServiceProviderRepository;

    public ServiceProviderOnBoardUserInformationCommandHandler(IOnBoardServiceProviderRepository onBoardServiceProviderRepository,
                                                                ServiceProviderOnBoardUserInformationCommandValidator validator)
        : base(validator)
            => this.onBoardServiceProviderRepository = onBoardServiceProviderRepository;

    public override async Task<Result> HandleImplementation(ServiceProviderOnBoardUserInformationCommand command)
    {
        var serviceProviderOnBoard = await onBoardServiceProviderRepository.ReturnByIdAsync(command.User!.Id);

        if (serviceProviderOnBoard.IsNull())
        {
            serviceProviderOnBoard = new OnBoardServiceProvider(OnBoardStepEnum.UserInfo);

            serviceProviderOnBoard.AddUser(command.User.Id, new OnBoardUser(command.Name,
                                                                            command.TypeDocument,
                                                                            command.Document,
                                                                            command.Phone,
                                                                            command.Photo));

            await onBoardServiceProviderRepository.AddAsync(serviceProviderOnBoard);
        }
        else
        {
            serviceProviderOnBoard.OnBoardUser.ChangeName(command.Name);
            serviceProviderOnBoard.OnBoardUser.ChangeTypeDocument(command.TypeDocument);
            serviceProviderOnBoard.OnBoardUser.ChangeDocument(command.Document);
            serviceProviderOnBoard.OnBoardUser.ChangePhone(command.Phone);
            serviceProviderOnBoard.OnBoardUser.ChangePhoto(command.Photo);
        }

        await onBoardServiceProviderRepository.SaveAsync();

        return Results.Ok("OnBoard successfully processed.");
    }
}

public sealed class ServiceProviderOnBoardUserInformationCommandValidator : AbstractValidator<ServiceProviderOnBoardUserInformationCommand>
{
    public ServiceProviderOnBoardUserInformationCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Document).NotEmpty();
        RuleFor(c => c.Phone).NotEmpty();
    }
}