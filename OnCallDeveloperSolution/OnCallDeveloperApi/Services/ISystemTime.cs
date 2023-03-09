namespace OnCallDeveloperApi;

public interface ISystemTime
{
    public DateTime GetCurrent();
}

public class SystemTime : ISystemTime
{
    public DateTime GetCurrent()
    {
        return DateTime.Now;
    }
}