using Microsoft.Identity.Client;

namespace LearningResourcesApi.Adapters;


// Create one of these classes for EACH of the external APIs you will call.
// Each "server" you call in to (http://localhost:1338)
public class OnCallDeveloperLookupApiAdapter
{
    private readonly HttpClient _httpClient;

    public OnCallDeveloperLookupApiAdapter(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
   

    public async Task<OnCallApiModel> GetOnCallDeveloperAsync()
    {
        var responseMessage = await _httpClient.GetAsync("/oncalldeveloper");
        responseMessage.EnsureSuccessStatusCode(); // 200-299? If not BLOW UP

        var message = await responseMessage.Content.ReadFromJsonAsync<OnCallApiModel>();

        if(message != null)
        {
            return message;
        } else
        {
            throw new Exception("Didn't get any data base - do this better in the real world");
        }
    }
}
