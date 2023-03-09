namespace Banking.Domain
{
    public interface ICalculateBonuses
    {
        decimal CalculateBankAccountDepositBonusFor(decimal accountBalance, decimal amountOfDeposit);
    }
}