
using Banking.Domain;
using Banking.UnitTests.TestDoubles;
using Moq;

namespace Banking.UnitTests;

public class BankAccountUsesBonusCalculator
{



    [Fact()]
    public void IntegratesWithBonusCalculator()
    {
        // This one uses our created class as a stub. it's a little flaky because it has stuff hard coded in it.

        var bankAccount = new BankAccount(new StubbedBonusCalculator());

        bankAccount.Deposit(212.83M);

        Assert.Equal(5000M + 212.83M + 12M, bankAccount.GetBalance());
    }
    [Fact()]
    public void IntegratesWithBonusCalculatorWithStubbedObject()
    {
        // Given
        var stubbedBonusCalculator = new Mock<ICalculateBonuses>(); // programmable object that looks like it can calculate boni
        var bankAccount = new BankAccount(stubbedBonusCalculator.Object);
        var openingBalance = bankAccount.GetBalance();
        var amountOfDeposit = 212.83M;

        stubbedBonusCalculator.Setup(dil => dil.CalculateBankAccountDepositBonusFor(openingBalance, amountOfDeposit)).Returns(1.92M);


        // When
        bankAccount.Deposit(amountOfDeposit);

        // Then
        Assert.Equal(openingBalance + amountOfDeposit + 1.92M, bankAccount.GetBalance());
    }
}
