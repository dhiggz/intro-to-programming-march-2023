
namespace CSharpSyntax;

internal class Customer
{
    private decimal CreditValue = 5000;
    public decimal GetCurrentAvailableCredit()
    {
        return CreditValue;
    }
    public void IncreaseAvailableCredit(decimal amount)
    {
        CreditValue += amount;
    }
}
