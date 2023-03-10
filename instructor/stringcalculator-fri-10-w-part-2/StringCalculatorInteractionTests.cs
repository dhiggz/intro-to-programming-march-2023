

namespace StringCalculator;

public class StringCalculatorInteractionTests
{

    [Theory]
    [InlineData("1,2,3", "6")]
    [InlineData("42","42")]
    [InlineData("", "0")]
    public void ResultsAreLogged(string numbers, string expected)
    {
        // Given
        var mockedLogger = new Mock<ILogger>(); // "Spy"
        var calculator = new StringCalculator(mockedLogger.Object, new Mock<IWebService>().Object);

        // When
       
        calculator.Add(numbers);

        // Then
        // Did the calculator call the Write method on the 
        // logger with the value "6"
        mockedLogger.Verify(m => m.Write(expected), Times.Once);
        
    }

    [Theory]
    [InlineData("1", "Logging Failed")]
    [InlineData("2", "Logging Failed")]
    [InlineData("2", "Blammo")]
    public void WebServiceIsNotifedIfLoggerFails(string numbers, string expectedMessage)
    {
        // Given
        // We are testing the string calculator's add method.
        // Scenario: When the logger blows up,
        // we want to make sure it is calling the web service.
        var stubbedLogger = new Mock<ILogger>();
        stubbedLogger.Setup(logger => logger.Write(It.IsAny<string>())).Throws<LoggingException>(() =>
                   new LoggingException(expectedMessage)
        );

        var mockedWebService = new Mock<IWebService>();
        var calculator = new StringCalculator(stubbedLogger.Object, mockedWebService.Object);
        // When
        calculator.Add(numbers);  // what are you going to when you get punched in the nose.

        // Then

        mockedWebService.Verify(w => w.LoggingFailed(expectedMessage), Times.Once);

    }

    [Fact]
    public void TheWebServiceIsNotCalledWithNoLoggingException()
    {
        var stubbedLogger = new Mock<ILogger>();
        var mockedWebService = new Mock<IWebService>();
        var calculator = new StringCalculator(stubbedLogger.Object, mockedWebService.Object);
        // When
        calculator.Add("1");  // what are you going to when you get punched in the nose.

        // Then

        mockedWebService.Verify(w => w.LoggingFailed(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public void TheLoggingException()
    {
        var le = new LoggingException("Taco Salad");

        Assert.Equal("Taco Salad", le.Message);
    }
}
