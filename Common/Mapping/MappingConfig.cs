using Mapster;
using travel_recommendation_api.Features.Recommendations;
namespace travel_recommendation_api.Common.Mapping;

public class MappingConfig
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<Recommendation, RecommendationDto>.NewConfig();
        TypeAdapterConfig<Recommendation, RecommendationDtos>.NewConfig();
        TypeAdapterConfig<RecommendationCreateDto, Recommendation>.NewConfig();
        TypeAdapterConfig<RecommendationUpdateDto, Recommendation>.NewConfig();
    }
}