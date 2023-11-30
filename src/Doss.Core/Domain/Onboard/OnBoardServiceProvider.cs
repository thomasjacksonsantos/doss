
using Doss.Core.Domain.Banks;

namespace Doss.Core.Domain.OnBoard;

public class OnBoardServiceProvider
{
    public Guid Id { get; private set; }
    public Guid TokenUserId { get; set; }
    public int CoverageArea { get; private set; }
    public string AgencyBank { get; private set; } = string.Empty;
    public string AccountBank { get; private set; } = string.Empty;
    public OnBoardUser User { get; private set; } = null!;
    public OnBoardStepEnum Step { get; private set; }
    public OnBoardAddress? Address { get; private set; }
    public IEnumerable<OnBoardPlan>? Plans { get; private set; }
    public Guid? OnBoardVehicleId { get; private set; }
    public OnBoardVehicle? Vehicle { get; private set; }
    public Guid? BankId { get; private set; }
    public Bank? Bank { get; private set; }
    public OnBoardTermsAccept? TermsAccept { get; set; }

    public OnBoardServiceProvider(OnBoardStepEnum step)
        => Step = step;

    public void AddUser(Guid userId, OnBoardUser user)
    {
        TokenUserId = userId;
        User = user;
    }

    public void AddBank(Bank bank)
    {
        BankId = bank.Id;
        Bank = bank;
    }

    public void ChangeStep(OnBoardStepEnum step)
        => Step = step;

    public void AddAddress(OnBoardAddress address)
        => Address = address;

    public void ChangeCoverageArea(int coverageArea)
        => CoverageArea = coverageArea;

    public void AddVehicle(OnBoardVehicle vehicle)
        => Vehicle = vehicle;

    public void AddPlan(IEnumerable<OnBoardPlan> plans)
        => Plans = plans;

    public void RemovePlans()
        => Plans = null;
        
    public void ChangeAccountBank(string accountBank)
        => AccountBank = accountBank;

    public void ChangeAgencyBank(string agencyBank)
        => AgencyBank = agencyBank;

    public void ChangeTermsAccept(OnBoardTermsAccept termsAccept)
        => TermsAccept = termsAccept;
}