namespace Banking.Domain;

public interface ICalculateBonuses
{
    decimal CalculateBankAccountDepositBonusFor(decimal accountCurrentBalance, decimal amountOfDeposit);
}