namespace LearningResourcesApi.Models;

public record LearningResourceSummaryItem(
    string Id, string Name, string Description, string Link);


public record LearningResourcesResponse(List<LearningResourceSummaryItem> Data);