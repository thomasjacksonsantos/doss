using Doss.Core.Domain.Verifications;
using NUnit.Framework;

namespace Doss.Test.Verifications;


public class VerificationTest
{
    [Test]
    public void Crreate_Verification_Instance()
    {
        var serviceProviderId = Guid.NewGuid();
        var resdientialId = Guid.NewGuid();
        var title = "Verify my gate is open";

        var verification = new Verification(serviceProviderId, resdientialId, title);
        verification.AddMessage(serviceProviderId, "I'll verify.");
        verification.AddMessage(serviceProviderId, "The gate is close.");
        verification.AddMessage(resdientialId, "Ah its ok.");
        verification.AddMessage(resdientialId, "Thansk");
        verification.ChangeStatus(Core.Domain.Enums.VerificationStatus.Done);
    }
}
