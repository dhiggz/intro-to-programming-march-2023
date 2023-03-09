using Banking.Domain;

namespace Banking.UnitTests.BonusCalculations;

public class BasicBonusCalculatorTests
{
    [Theory]
    [InlineData(5000, 100, 10)]
    [InlineData(5000, 200, 20)]
    [InlineData(4999.99, 100, 0)]
    public void DepositsGetBonusBasedOnBalance(decimal balance, decimal amount, decimal expectedBonus)
    {
        //Given
        var bonusCalculator = new StandardBonusCalculator();


        //When
        decimal bonus = bonusCalculator.CalculateBankAccountDepositBonusFor(balance, amount);

        //Then
        Assert.Equal(expectedBonus, bonus);
    }
}
