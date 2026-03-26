using Microsoft.AspNetCore.Mvc;
using travel_recommendation_api.Features.Recommendations;

namespace travel_recommendation_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecommendationController : ControllerBase
{
    private readonly RecommendationService _service;
    
    public RecommendationController(RecommendationService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<ActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> Create(RecommendationCreateDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, RecommendationUpdateDto dto)
    {
        var result = await _service.UpdateAsync(id , dto);
        return result == null ? NotFound() : Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var success = await _service.DeleteAsync(id);
        return success ? NoContent() : NotFound();
        
    }
}