namespace LearningResourcesApi.Domain;

public class EntityFrameworkResourceManager : IManageLearningResources
{
    private readonly LearningResourcesDataContext _context;

    public EntityFrameworkResourceManager(LearningResourcesDataContext context)
    {
        _context = context;
    }

    public async Task<LearningResourceSummaryItem> AddResourceAsync(LearningResourcesCreateRequest request)
    {
      
       var entity = new LearningResourcesEntity
       {
           // "Mapping" - AutoMapper
           Name = request.Name,
           Description = request.Description,
           Link = request.Link,
           WhenCreated = DateTime.Now
       };
        //   - tell our DataContext about it.
        _context.LearningResources.Add(entity);
        //   - tell the DataContext to save the data.
        await _context.SaveChangesAsync(); // Order Up!
        // Return a Success Status Code*
        //   - With a copy of the brand new entity
        var response = MapFromDomain(entity);
        return response;
    }


    public async Task<LearningResourcesResponse> GetCurrentResourcesAsync(CancellationToken token, bool watched)
    {
        var data = await GetItems().Where(item => item.HasBeenWatched == watched).ToListAsync(); // + this

        var response = new LearningResourcesResponse(data);
        return response;
    }
    public async Task<LearningResourcesResponse> GetCurrentResourcesAsync(CancellationToken token)
    {

        var data = await GetItems().ToListAsync(token);
        var response = new LearningResourcesResponse(data);
        return response;
    }

    private  IQueryable<LearningResourceSummaryItem> GetItems()
    {
        return _context.GetActiveLearningResources()
            .Select(item => MapFromDomain(item)); // This!
    }

    public async Task<LearningResourceSummaryItem?> GetResourceByIdAsync(int resourceId)
    {
        var response = await _context.GetActiveLearningResources()
            .Where(item => item.Id == resourceId)
            .Select(item => MapFromDomain(item))
            .SingleOrDefaultAsync();

        return response;
    }

    public async Task RemoveItemAsync(int resourceId)
    {
        // Can you spot the bug?
        var item = await _context.GetActiveLearningResources()
            .SingleOrDefaultAsync(item => item.Id == resourceId);
        if(item != null)
        {
            item.WhenRemoved = DateTime.Now;
            await _context.SaveChangesAsync();
        }
    }

    // "Never type private, always refactor to it!"
    private static LearningResourceSummaryItem MapFromDomain(LearningResourcesEntity item)
    {
        return new LearningResourceSummaryItem(item.Id.ToString(), item.Name, item.Description, item.Link, item.HasBeenWatched);
    }

    public async Task<bool> MoveItemToWatchedAsync(LearningResourceSummaryItem request)
    {
        var id = int.Parse(request.Id);
        var item = await _context.GetActiveLearningResources().SingleOrDefaultAsync(item => item.Id == id);
        if(item != null) {
            item.HasBeenWatched = true;
            await _context.SaveChangesAsync();
            return true;
        } else
        {
            return false;
        }
    }


}
