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
        return IsOpenNow();
    }

    private bool IsOpenNow()
    {
        return DuringWorkingHours() && IsNotWeekend();
    }

    private bool IsNotWeekend()
    {
        return _systemTime.GetCurrent().DayOfWeek != DayOfWeek.Sunday && _systemTime.GetCurrent().DayOfWeek != DayOfWeek.Saturday;
    }

    private  bool DuringWorkingHours()
    {
        var currentHour = _systemTime.GetCurrent().Hour;
        return currentHour >= 9 && currentHour < 15;
    }

    
}