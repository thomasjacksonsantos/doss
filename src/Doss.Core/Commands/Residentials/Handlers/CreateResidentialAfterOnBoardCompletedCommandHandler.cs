using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using Doss.Core.Services;
using FluentValidation;

namespace Doss.Core.Commands.Residentials.Handlers;

public class CreateResidentialAfterOnBoardCompletedCommandHandler : BaseCommandHandler<CreateResidentialAfterOnBoardCompletedCommand, CreateResidentialAfterOnBoardCompletedCommandValidator>
{
    private readonly IOnBoardResidentialRepository onBoardResidentialRepository;
    private readonly IResidentialRepository residentialRepository;
    private readonly IBlobStorage blobStorage;

    public CreateResidentialAfterOnBoardCompletedCommandHandler(IResidentialRepository residentialRepository,
                                                       IOnBoardResidentialRepository onBoardResidentialRepository,
                                                       IBlobStorage blobStorage,
                                                       CreateResidentialAfterOnBoardCompletedCommandValidator validator)
        : base(validator)
            => (this.onBoardResidentialRepository, this.residentialRepository, this.blobStorage) = (onBoardResidentialRepository, residentialRepository, blobStorage);

    public override async Task<Result> HandleImplementation(CreateResidentialAfterOnBoardCompletedCommand command)
    {
        var onboard = await onBoardResidentialRepository.ReturnByIdAsync(command.UserId);

        if (onboard.IsNull())
            return Results.Ok("Onboard not found.");

        var residential = await residentialRepository.ReturnByIdAsync(command.UserId);

        if (residential.IsNotNull())
            return Results.Error("residential has already been registered.");

        residential = new Domain.Residentials.Residential(command.UserId, 
                                                            onboard.OnBoardUser.Name, 
                                                            onboard.OnBoardUser.TypeDocument, 
                                                            onboard.OnBoardUser.Document,
                                                            onboard.OnBoardUser.Phone, true);

        residential.AddResidentialWithServiceProvider(new Domain.Residentials.ResidentialWithServiceProvider(onboard.ServiceProviderPlanId!.Value, onboard.PlanId!.Value, onboard.Address!));
        await residentialRepository.AddAsync(residential, saveChanges: true);

        var url = $"service-provider/image/{residential.Id}";

        residential.ChangePhotoUrl(url);

        await blobStorage.SendImage(onboard.OnBoardUser.Photo, url);
        
        await residentialRepository.SaveAsync();

        return Results.Ok("Residentia user created with success.");
    }
}

public sealed class CreateResidentialAfterOnBoardCompletedCommandValidator : AbstractValidator<CreateResidentialAfterOnBoardCompletedCommand>
{
    public CreateResidentialAfterOnBoardCompletedCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
    }
}