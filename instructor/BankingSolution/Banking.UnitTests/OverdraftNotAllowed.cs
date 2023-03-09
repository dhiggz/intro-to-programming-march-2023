
using Banking.Domain;
using Banking.UnitTests.TestDoubles;
using System.Security.Principal;
using Xunit.Sdk;

namespace Banking.UnitTests;

public class OverdraftNotAllowed
{


    [Fact]
    public void OverdraftDoesNotDecreaseBalance()
    {
        // Given
        var account = new BankAccount(new DummyBonusCalculator());
        var openingBalance = account.GetBalance();

        try
        {
            account.Withdraw(account.GetBalance() + .01M);
        }
        catch (OverdraftException)
        {

            // Ignore this..
        }

        Assert.Equal(openingBalance, account.GetBalance());
    }

    [Fact]
    public void OverdraftThrowsException()
    {
        var account = new BankAccount(new DummyBonusCalculator());
        var openingBalance = account.GetBalance();

        Assert.Throws<OverdraftException>(() =>
        {
            account.Withdraw(account.GetBalance() + .01M);

        });


        //var rightExecptionThrow = ExceptionHelpers.Throws<OverdraftException>(() =>
        //{
        //    account.Withdraw(account.GetBalance() + .01M);
        //}); 

        //Assert.True(rightExecptionThrow);
    }
}


public class ExceptionHelpers 
{
    public static bool Throws<TException>(Action suspectCode) 
        where TException : Exception // Generic Constraint
    {
        var rightExceptionThrown = false;
        try
        {
            suspectCode();
        }
        catch (TException)
        {

            rightExceptionThrown = true;
        }
        return rightExceptionThrown;
    }

    public static string FormatName(string first, string last)
    {
        return $"{last}, {first}";
    }
}
