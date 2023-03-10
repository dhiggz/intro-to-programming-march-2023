
using Moq;
using OnCallDeveloperApi.Controllers;

namespace OnCallDeveloperApi.UnitTests;

public class StandardBusinessClockTests
{
    [Fact]
    public void ReturnsTrueDuringBusinessHours()
    {
        var stubbedClock = new Mock<ISystemTime>();
        stubbedClock.Setup(clock => clock.GetCurrent()).Returns(
            new DateTime(1969, 4, 20, 09, 00, 00));
        IProvideTheBusinessClock clock = new StandardBusinessClock(stubbedClock.Object);

        Assert.True(clock.IsDuringBusinessHours());
    }

    [Fact]
    public void ReturnsFalseBeforeBusinessHours()
    {
        var stubbedClock = new Mock<ISystemTime>();
        stubbedClock.Setup(clock => clock.GetCurrent()).Returns(
            new DateTime(1969, 4, 20, 08, 59, 59));
        IProvideTheBusinessClock clock = new StandardBusinessClock(stubbedClock.Object);

        Assert.False(clock.IsDuringBusinessHours());
    }
    [Fact]
    public void ReturnsFalseAfterBusinessHours()
    {
        var stubbedClock = new Mock<ISystemTime>();
        stubbedClock.Setup(clock => clock.GetCurrent()).Returns(
            new DateTime(1969, 4, 20, 16, 00, 00));
        IProvideTheBusinessClock clock = new StandardBusinessClock(stubbedClock.Object);

        Assert.False(clock.IsDuringBusinessHours());
    }

    [Fact]
    public void TestingAControllerSux()
    {
        var controller = new OnCallDeveloperController(new Mock<IProvideTheBusinessClock>().Object);

        var response = controller.GetOnCallDeveloper();

        // 30-50 lines of code just to find out if when I call GetOnCallDeveloper I get back the right data.

         
    }
}
