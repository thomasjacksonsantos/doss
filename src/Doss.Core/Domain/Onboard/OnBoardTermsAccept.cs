namespace Doss.Core.Domain.OnBoard;

public class OnBoardTermsAccept
{    
    public bool TermsAccept { get; set; }
    public DateTime DateTimeAccept { get; set; }

    public OnBoardTermsAccept(bool termsAccept, DateTime dateTimeAccept)
        => (TermsAccept, DateTimeAccept) = (termsAccept, dateTimeAccept);
}