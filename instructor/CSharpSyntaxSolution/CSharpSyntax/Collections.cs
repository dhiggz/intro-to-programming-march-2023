
using System.Runtime.Serialization;

namespace CSharpSyntax;

public class Collections
{
    [Fact]
    public void UsingAGenericList()
    {
        //generics change there form based on a type parameter
        // "Parametric Polymorphism"
        var favoriteNumbers = new List<int>();
        favoriteNumbers.Add(9);
        favoriteNumbers.Add(20);
        favoriteNumbers.Add(108);

        Assert.Equal(9, favoriteNumbers[0]);
        Assert.Equal(108, favoriteNumbers[2]);

        //Assert.Equal(999, favoriteNumbers[32]);
        Assert.Equal(3, favoriteNumbers.Count());
        Assert.Contains(108, favoriteNumbers);
        // - "Roslyn" - "Compiler as a Service"

        Assert.Equal(9, favoriteNumbers[0]);
        
    }

    [Fact]
    public void ListInitializers()
    {
        //generics change there form based on a type parameter
        // "Parametric Polymorphism"
        var favoriteNumbers = new List<int>
        {
            9,
            20,
            108
        };

        Assert.Equal(3, favoriteNumbers.Count());
     
    }

    [Fact]
    public void EnumeratingAList()
    {
        //generics change there form based on a type parameter
        // "Parametric Polymorphism"
        var favoriteNumbers = new List<int>
        {
            9,
            20,
            108
        };

        int total = 0;
        for(var x = 0; x< favoriteNumbers.Count; x++)
        {
            total += favoriteNumbers[x];
        }
        Assert.Equal(137, total);
        total = 0;

        foreach(var num in favoriteNumbers)
        {
            total += num;
        }
        Assert.Equal(137, total);

    }
    [Fact]
    public void DoingThingsWithPeople()
    {
        var bob = new Employee()
        {
            Name = "Robert",
            Salary = 82_000
        };

       
        
        var jeff = new Contractor();
        jeff.Name = "Jeffry";
        jeff.HourlyRate = 28.85M;

        IProvidePayInformation sue = new Employee { Name = "Susan", Salary = 230_000 };
        

        var workers = new List<IProvidePayInformation>
        {
            bob,
            jeff,
           
        };
        
        foreach(var person in workers)
        {
            // give me whatever your pay is.
            person.GetPay();
        }

       // var dylan = new Worker();
    }

    [Fact]
    public void Dictionaries()
    {
        var myFriends = new Dictionary<char, string>
        {
            { 's', "Sam" },
            { 'd', "David" }
        };

        myFriends['s'] = "Sean";

        Assert.Equal("Sean", myFriends['s']);

        foreach(KeyValuePair<char, string> kvp in myFriends)
        {
            
        }

        foreach(var key in myFriends.Keys)
        {

        }
        foreach(var value in myFriends.Values)
        {

        }
    }
}


public interface IProvidePayInformation
{
    decimal GetPay();
}
public class Employee : IProvidePayInformation
{
    public string Name { get; set; } = string.Empty;
    public decimal Salary { get; set; }

    decimal IProvidePayInformation.GetPay()
    {
        return this.Salary;
    }
}

public class Contractor : IProvidePayInformation
{
    public string Name { get; set; } = string.Empty;
    public decimal HourlyRate { get; set; }

    decimal IProvidePayInformation.GetPay()
    {
        return this.HourlyRate * 40 * 365;
    }
}