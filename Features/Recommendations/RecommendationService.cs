using Microsoft.EntityFrameworkCore;
using travel_recommendation_api.Data;
namespace travel_recommendation_api.Features.Recommendations;
using Mapster;

public class RecommendationService
{
   private readonly AppDbContext _context;

   public RecommendationService(AppDbContext context)
   {
       _context = context;
   }

   public async Task<List<RecommendationDtos>> GetAllAsync()
   {
       return await  _context.Recommendations
           .ProjectToType<RecommendationDtos>()
           .ToListAsync();
   }

   public async Task<RecommendationDto?> GetByIdAsync(int id)
   {
       return await _context.Recommendations
           .Where(r => r.Id == id)
           .ProjectToType<RecommendationDto>()
           .FirstOrDefaultAsync();
   }

   public async Task<RecommendationDto> CreateAsync(RecommendationCreateDto dto)
   {
       var entity = dto.Adapt<Recommendation>();
       _context.Recommendations.Add(entity);
       await  _context.SaveChangesAsync();
       return entity.Adapt<RecommendationDto>(); 
   }

   public async Task<RecommendationDtos> UpdateAsync(int id ,RecommendationUpdateDto dto)
   {
       var entity = await _context.Recommendations.FindAsync(id);
       if (entity ==  null) return  null!;
       dto.Adapt(entity);
       await  _context.SaveChangesAsync();
       return entity.Adapt<RecommendationDtos>();
   }

   public async Task<bool> DeleteAsync(int id)
   {
       var entity = await _context.Recommendations.FindAsync(id);
       if (entity == null) return false;
       _context.Recommendations.Remove(entity);
       await _context.SaveChangesAsync();
       return true;
   }
}