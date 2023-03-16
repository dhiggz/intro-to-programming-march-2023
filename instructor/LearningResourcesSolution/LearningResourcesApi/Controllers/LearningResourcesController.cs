

using LearningResourcesApi.Domain;

namespace LearningResourcesApi.Controllers;

public class LearningResourcesController : ControllerBase
{
   
    private readonly IManageLearningResources _resourceManager;

    public LearningResourcesController(IManageLearningResources resourceManager)
    {
        _resourceManager = resourceManager;
    }

    [HttpPost("/watched-learning-resources")]
    public async Task<ActionResult> MoveToWatched([FromBody] LearningResourceSummaryItem request)
    {
       bool exists = await _resourceManager.MoveItemToWatchedAsync(request);
        if (!exists) {
            return BadRequest();
        } else
        {
            return NoContent();
        }

    }

    [HttpDelete("/learning-resources/{resourceId:int}")]
    public async Task<ActionResult> Remove(int resourceId)
    {
        // Idempotent - doing it multiple times is the same as doing it once.
        // check to see if there is a resource with id, and if there is "remove"
        await _resourceManager.RemoveItemAsync(resourceId);
        return NoContent(); // passive-aggressive "Fine!"
    }


    [HttpPost("/learning-resources")]
    public async Task<ActionResult<LearningResourceSummaryItem>> AddResources(
        [FromBody] LearningResourcesCreateRequest request)
    {

        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        LearningResourceSummaryItem response = await _resourceManager.AddResourceAsync(request);
        return Ok(response);

    }


    [HttpGet("/learning-resources")]
    public async Task<ActionResult<LearningResourcesResponse>> GetLearningResources(CancellationToken token, [FromQuery] bool? watched = null)
    {
        LearningResourcesResponse response;
        if(watched.HasValue)
        {
            response = await _resourceManager.GetCurrentResourcesAsync(token, watched.Value);

        } else
        {

          response = await _resourceManager.GetCurrentResourcesAsync(token);
        }
        
        // Write the Code I wish I had
        return Ok(response);
    }

    [HttpGet("/learning-resources/{resourceId:int}")]
    public async Task<ActionResult<LearningResourceSummaryItem>> GetById(int resourceId)
    {
        // Either a 200 Ok, with item, or 404
        LearningResourceSummaryItem? response = await _resourceManager.GetResourceByIdAsync(resourceId);
        if(response == null)
        {
            return NotFound();
        } else
        {
            return Ok(response);
        }
    }
}
