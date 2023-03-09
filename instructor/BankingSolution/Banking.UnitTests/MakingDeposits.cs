

using Banking.Domain;
using Banking.UnitTests.TestDoubles;
using Xunit;

namespace Banking.UnitTests;

public class MakingDeposits
{
    [Theory]
    [InlineData(100)]
    [InlineData(1.25)]
    public void DepositsIncreasesTheBalance(decimal amountToDeposit)
    {
        // given
        var account = new BankAccount(new DummyBonusCalculator());
        var openingBalance = account.GetBalance(); // Query (Func)
        
        // when
        account.Deposit(amountToDeposit); // Command (Action)

        // then
        Assert.Equal(openingBalance + amountToDeposit , 
            account.GetBalance());
    }
}
