namespace CSharpSyntax;

public class BankAccountTests
{
    [Fact]
    public void GettingMyAccount()
    {
        var service = new AccountManager();
        var myAccount = service.GetAccountById("93939");

        Assert.Equal("93939", myAccount.GetAccountNumber());

        //Assert.Equal("Jeff", myAccount.FirstName);

        myAccount.FirstName = "Jeffry";

        Assert.Equal("Jeffry", myAccount.FirstName);
    }

    [Fact]
    public void WorkingWithTransactions()
    {
        var t1 = new BankTransaction2
        {
            TransactionType = TransactionType.Deposit,
            Amount = 100,
        };
        var t2 = new BankTransaction2
        {
            TransactionType = TransactionType.Deposit,
            Amount = 100,
        };

        Assert.Equal(t1, t2);

        var t3 = new BankTransaction2 { Amount = 1000, TransactionType = TransactionType.Withdrawal, Note = "For work" };

    }
}

public enum TransactionType { Deposit, Withdrawal, Fee }
public class BankTransaction 
{ 
    //can't use required in progressive code yet
    public required TransactionType TransactionType { get; init; }
    public required decimal Amount { get; init; }
    public string Note { get; init; } = string.Empty;
}

public record BankTransaction2
{
    public required TransactionType TransactionType { get; init; }
    public required decimal Amount { get; init; }
    public string Note { get; init; } = string.Empty;
}