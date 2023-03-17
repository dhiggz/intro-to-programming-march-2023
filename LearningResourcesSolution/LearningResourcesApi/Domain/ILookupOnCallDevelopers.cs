namespace LearningResourcesApi.Domain;

public interface ILookupOnCallDevelopers
{
    Task<StatusHelpInfo> GetCurrentOnCallDeveloperAsync();
}
