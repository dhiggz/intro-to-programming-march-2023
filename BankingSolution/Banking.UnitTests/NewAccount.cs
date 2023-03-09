using Banking.Domain;
using Banking.UnitTests.TestDoubles;

namespace Banking.UnitTests;

public class NewAccount
{
    public void NewAccountHasCorrectOpeningBalance()
    {
        var account = new BankAccount(new StubbedBonusCalculator());
    }
}
