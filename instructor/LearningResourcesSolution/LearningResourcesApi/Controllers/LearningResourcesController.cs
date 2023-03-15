

namespace LearningResourcesApi.Controllers;

public class LearningResourcesController : ControllerBase
{
    private readonly LearningResourcesDataContext _context;

    public LearningResourcesController(LearningResourcesDataContext context)
    {
        _context = context;
    }

    [HttpGet("/learning-resources")]
    public async Task<ActionResult<LearningResourcesResponse>> GetLearningResources()
    {
        var data = await _context.LearningResources
            .Where(item => item.WhenRemoved == null)
            .Select(item => new LearningResourceSummaryItem(
                item.Id.ToString(), item.Name, item.Description, item.Link))
            .ToListAsync();

        var response = new LearningResourcesResponse(data);
        return Ok(response);
    }
}
