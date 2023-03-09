using System.ComponentModel;

namespace Banking.Domain;

public class AdvancedBonusCalculator : ICalculateBonuses
{
    public decimal CalculateBankAccountDepositBonusFor(decimal accountCurrentBalance, decimal amountOfDeposit)
    {
        // this is where can start doing the work
        return -42;
    }
}