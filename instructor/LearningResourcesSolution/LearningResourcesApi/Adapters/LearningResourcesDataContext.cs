using LearningResourcesApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace LearningResourcesApi.Adapters;

public class LearningResourcesDataContext : DbContext
{
    public LearningResourcesDataContext(DbContextOptions<LearningResourcesDataContext> options) : base(options)
    {
        
    }
    public DbSet<LearningResourcesEntity> LearningResources { get; set; }
}
