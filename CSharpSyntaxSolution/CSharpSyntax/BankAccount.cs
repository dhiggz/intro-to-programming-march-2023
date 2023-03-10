namespace CSharpSyntax;

public class BankAccount
{

    private string _accountNumber = string.Empty;
    private string _firstName = string.Empty;

    public BankAccount(string accountNumber)
    {
        _accountNumber = accountNumber;
        FirstName = _firstName;
    }

    //public string GetFirstName()
    //{
    //    return _firstName;
    //}
    //
    //public void SetFirstName(string value)
    //{
    //    _firstName = value;
    //}

    public string FirstName
    {
        get { return _firstName; }
        set { _firstName = value; }
    }

    public string LastName { get; set; }

    public string GetAccountNumber()
    {
        return _accountNumber;
    }
}

//class that just does some work for me... Services

public class AccountManager
{
    public BankAccount GetAccountById(string accountNumber)
    {
        return new BankAccount(accountNumber);
    }
}
