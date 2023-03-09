using Banking.Domain;
using Banking.UnitTests.TestDoubles;

namespace Banking.UnitTests;

public class OverdraftNotAllowed
{
    [Fact]
    public void OverdraftDoesNotDecreaseBalance() {
        var account = new BankAccount(new DummyBonusCalculator());
        var openingBalance = account.GetBalance();

		try
		{
			account.Withdraw(account.GetBalance() + 0.01M);
		}
		catch (OverdraftException)
		{

			//Ignore this...
		}

        Assert.Equal(openingBalance, account.GetBalance());
    }

	[Fact]
	public void OverDraftThrowsException()
	{
        var account = new BankAccount(new DummyBonusCalculator());
        var openingBalance = account.GetBalance();

		Assert.Throws<OverdraftException>(() =>
		{
			account.Withdraw(account.GetBalance() + 0.01M);
		});

		//var rightExpetionThrow = ExceptionHelpers.TryThisSuspectCode<OverdraftException>(() =>
		//{
		//	account.Withdraw(account.GetBalance() + 0.01M);
		//});
		//Assert.True(rightExpetionThrow);
	}

	//public class ExceptionHelpers
	//{
	//	public static bool TryThisSuspectCode<TException>(Action suspectCode)
    //        where TException : Exception
	//	{
	//		var rightExceptionThrown = false;
	//		try
	//		{
	//			//run suspect code
	//			suspectCode();
	//		}catch(TException)
	//		{
	//			rightExceptionThrown = true;
	//		}
	//		return rightExceptionThrown;
	//	}
	//}
	//
	//public static string FormatName(string first, string last)
	//{
	//	return $"{last}, {first}";
	//}

}
