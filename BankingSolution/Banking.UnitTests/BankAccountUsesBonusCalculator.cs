using Banking.Domain;
using Banking.UnitTests.TestDoubles;
using Moq;

namespace Banking.UnitTests; 
public class BankAccountUsesBonusCalculator
{
    [Fact]
    public void IntegrateWithBonusCalculator()
    {
        // this one uses our created class as a stub - it's a little flaky because it has stuff hard coded on it
        var bankAccount = new BankAccount(new StubbedBonusCalculator());

        bankAccount.Deposit(812.83M);

        Assert.Equal(5000M + 812.83M, bankAccount.GetBalance());
    }

    [Fact]
    public void IntegrateWithBonusCalculatorWithStubbedObject()
    {
        var stubbedBonusCalculator = new Mock<ICalculateBonuses>();  //programmable object that looks liek it can calculate bonuses
        var bankAccount = new BankAccount(stubbedBonusCalculator.Object);
        var openingBalance = bankAccount.GetBalance();
        var amountOfDeposit = 212.83M;

        stubbedBonusCalculator.Setup(x => x.CalculateBankAccountDepositBonusFor(openingBalance, amountOfDeposit)).Returns(12M);

        bankAccount.Deposit(812.83M);

        Assert.Equal(5000M + 812.83M, bankAccount.GetBalance());
    }
}