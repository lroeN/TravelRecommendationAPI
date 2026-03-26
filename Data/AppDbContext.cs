using Microsoft.EntityFrameworkCore;
using travel_recommendation_api.Features.Recommendations;

namespace travel_recommendation_api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Recommendation> Recommendations { get; set; }
}