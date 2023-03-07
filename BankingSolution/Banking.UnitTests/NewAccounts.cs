
using Banking.Domain;

namespace Banking.UnitTests;

public class NewAccounts
{
    [Fact]
    public void NewAccountHasCorrectOpeningBalance()
    {
        // "Write the code you wish you had"

        //Given
        BankAccount account = new BankAccount();

        //Then
        decimal balance = account.GetBalance();

        //When
        Assert.Equal(5000, balance);

    }
}
