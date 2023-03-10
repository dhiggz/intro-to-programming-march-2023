
namespace CSharpSyntax;

public class BankAccountTests
{
    [Fact]
    public void GettingMyAccount()
    {
        var service = new AccountManager();
        var myAccount = service.GetAccountById("93939");

        Assert.Equal("93939", myAccount.GetAccountNumber());

        Assert.Equal("Jeff", myAccount.FirstName);

        //myAccount.LastName = "Gonzalez";

        //Assert.Equal("Gonzalez", myAccount.LastName);
        //myAccount.FirstName = "Jeffry";

        //Assert.Equal("Jeffry", myAccount.FirstName);
    }

    [Fact]
    public void WorkingWithTransactions()
    {
        var t1 = new BankTransaction2
        {
            TransactionType = TransactionType.Deposit,
            Amount = 5000
        };

        /// send it to the bank.
        /// 
        // t1.Amount = 8000;

        // var t2 = t1;
        var t2 = new BankTransaction2
        {
            TransactionType = TransactionType.Deposit,
            Amount = 5000
        };

        Assert.Equal(t1, t2);


        //t2.Amount = 5100;

        var t3 = new BankTransaction2 { Amount = 1000, TransactionType = TransactionType.Withdrawal, Note = "For Work" };
        

        var t4 = t3 with { Amount = 1200, Note = t3.Note + " overtime" };

        var song1 = new Song2
        {
            Title = "Scenario",
            Artist = "A Tribe Called Quest",
            Album = "Low End Theory"
        };
        Assert.Equal("Scenario", song1.Title);
       

        var song2 = new Song("Bring the Ruckus", "Wu-Tang Clan", "36 Chambers");

        Assert.Equal("36 Chambers", song2.Album);
       

    }
}


public enum TransactionType {  Deposit, Withdrawal, Fee}
public class BankTransaction 
{
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

public record Song(string Title, string Artist, string Album);

public record Song2
{
    public string Title { get; init; } = string.Empty;
    public string Artist { get; init; } = string.Empty;
    public string Album { get; init; } = string.Empty;
}