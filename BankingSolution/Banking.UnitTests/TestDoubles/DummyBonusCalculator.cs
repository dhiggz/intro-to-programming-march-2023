using Banking.Domain;

namespace Banking.UnitTests.TestDoubles;

internal class DummyBonusCalculator : ICalculateBonuses
{
    public decimal CalculateBankAccountDepositBonusFor(decimal accountBalance, decimal amountOfDeposit)
    {
        return 0;
    }
}
