namespace LearningResourcesApi.Domain;

public interface IManageLearningResources
{
    Task<LearningResourceSummaryItem> AddResourceAsync(LearningResourcesCreateRequest request);
    Task<LearningResourcesResponse> GetCurrentResourcesAsync(CancellationToken token);
    Task<LearningResourcesResponse> GetCurrentResourcesAsync(CancellationToken token, bool watched);
    Task<LearningResourceSummaryItem?> GetResourceByIdAsync(int resourceId);
    Task<bool> MoveItemToWatchedAsync(LearningResourceSummaryItem request);
    Task RemoveItemAsync(int resourceId);
}
