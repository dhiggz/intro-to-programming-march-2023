namespace StringCalculator;

public class LoggingException : Exception
{
    public LoggingException(string message) : base(message) //gives message to the base class (exception)
    {

    }
}
