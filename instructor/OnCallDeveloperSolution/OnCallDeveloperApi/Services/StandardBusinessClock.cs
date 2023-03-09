namespace OnCallDeveloperApi;

public class StandardBusinessClock : IProvideTheBusinessClock
{
    private readonly ISystemTime _systemTime;

    public StandardBusinessClock(ISystemTime systemTime)
    {
        _systemTime = systemTime;
    }

    public bool IsDuringBusinessHours()
    {
        var currentHour = _systemTime.GetCurrent().Hour;
        return currentHour >= 9 && currentHour < 15;
    }
}