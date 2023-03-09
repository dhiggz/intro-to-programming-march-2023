namespace Banking.Domain;

public class StandardBonusCalculator : ICalculateBonuses
{

    public decimal CalculateBankAccountDepositBonusFor(decimal accountCurrentBalance, decimal amountOfDeposit)
    {
        return accountCurrentBalance >= 5000M ? amountOfDeposit * .10M : 0;
    }
}