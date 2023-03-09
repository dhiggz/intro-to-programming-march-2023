namespace Banking.Domain
{
    public class StandardBonusCalculator : ICalculateBonuses
    {

        public decimal CalculateBankAccountDepositBonusFor(decimal accountBalance, decimal amountOfDeposit)
        {
            return accountBalance >= 5000M ? amountOfDeposit * 0.10M : 0;
        }
    }
}