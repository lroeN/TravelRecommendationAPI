namespace travel_recommendation_api.Features.Recommendations;

public class RecommendationDtos
{
    public record RecommendationDto(int Id, string Name, string Description);
    public record RecommendationCreateDto(string Name, string Description);
    public record RecommendationUpdateDto(string Name, string Description);
}

public class RecommendationDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}

public class RecommendationCreateDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}

public class RecommendationUpdateDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}