

namespace OnCallDeveloperApi.Controllers;

public class OnCallDeveloperController : ControllerBase
{
    private readonly IProvideTheBusinessClock _businessClock;

    public OnCallDeveloperController(IProvideTheBusinessClock businessClock)
    {
        _businessClock = businessClock;
    }


    // GET /oncalldeveloper -> 200 Ok
    [HttpGet("/oncalldeveloper")]
    public ActionResult GetOnCallDeveloper()
    {
        GetOnCallDeveloperResponse response; 
        // WTCYWYH
        if(_businessClock.IsDuringBusinessHours())
        {
            response =
            new GetOnCallDeveloperResponse("Michael N.", "555-1212", "mike@aol.com");
        } else
        {
            response =
            new GetOnCallDeveloperResponse("OnCallCorp Customer Service", "800 GOOD-LUCK", "oncall@company.com");
        }
       
        return Ok(response); // 200 status code
    }
}
