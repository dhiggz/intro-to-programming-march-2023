using OnCallDeveloperApi.Controllers;

namespace OnCallDeveloperApi.Services;

public class TwentyFourHourBusinessClock : IProvideTheBusinessClock
{
    public bool IsDuringBusinessHours()
    {
        return true;
    }
}
