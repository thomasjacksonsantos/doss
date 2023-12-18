
using Doss.Core.Domain.Plans;
using Doss.Core.Domain.ServiceProviders;

namespace Doss.Core.Domain.OnBoard;

public class OnBoardResidential
{
    public Guid Id { get; set; }
    public Guid TokenUserId { get; set; }
    public OnBoardUser OnBoardUser { get; set; } = null!;
    public OnBoardStepEnum Step { get; set; }
    public OnBoardAddress? Address { get; set; }
    public Guid? ServiceProviderPlanId { get; set; }
    public ServiceProviderPlan? ServiceProviderPlan { get; set; }
    public Guid? PlanId { get; set; }
    public Plan? Plan { get; set; }
    public OnBoardTermsAccept? TermsAccept { get; set; }

    public OnBoardResidential(OnBoardStepEnum step)
        => Step = step;

    public void AddUser(Guid userId, OnBoardUser user)
    {
        TokenUserId = userId;
        OnBoardUser = user;
    }

    public void ChangeStep(OnBoardStepEnum step)
        => Step = step;

    public void AddAddress(OnBoardAddress address)
        => Address = address;

    public void AddServiceProvider(ServiceProviderPlan serviceProviderPlan)
    {
        ServiceProviderPlanId = serviceProviderPlan.Id;
        ServiceProviderPlan = serviceProviderPlan;
    }
    public void AddPlan(Plan plan)
    {
        PlanId = plan.Id;
        Plan = plan;
    }

    public void ChangeTermsAccept(OnBoardTermsAccept termsAccept)
        => TermsAccept = termsAccept;
}