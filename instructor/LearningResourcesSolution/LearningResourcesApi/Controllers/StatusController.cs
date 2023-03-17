

namespace LearningResourcesApi.Controllers;

public class StatusController : ControllerBase
{
    private readonly ILookupOnCallDevelopers _onCallDeveloperLookup;

    public StatusController(ILookupOnCallDevelopers onCallDeveloperLookup)
    {
        _onCallDeveloperLookup = onCallDeveloperLookup;
    }

    [HttpGet("/status")]
    public async Task<ActionResult> GetServiceStatus()
    {
        StatusHelpInfo helpInfo;
        try
        {
           helpInfo = await _onCallDeveloperLookup.GetCurrentOnCallDeveloperAsync();
        }
        catch (Exception)
        {
            // What's the plan b? Maybe notify someone?
            helpInfo = new StatusHelpInfo("Help Info Unavailable - Try Again Later", new Dictionary<string, string>());
            
        }
        var response = new StatusResponse(StatusLevel.OnFire, DateTime.Now.AddDays(-268), new List<DateTime>(), helpInfo);
        return Ok(response);
    }
}
