
using Banking.Domain;

namespace Banking.UnitTests.TestDoubles;

public class StubbedBonusCalculator : ICalculateBonuses
{
    public decimal CalculateBankAccountDepositBonusFor(decimal accountCurrentBalance, decimal amountOfDeposit)
    {
        return accountCurrentBalance == 5000M && amountOfDeposit == 212.83M ? 12 : 0;
    }
}
// Moq