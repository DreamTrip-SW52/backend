using AutoMapper;
using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Services;
using DreamTrip.DreamTrip.Resources;
using DreamTrip.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DreamTrip.DreamTrip.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ToursController : ControllerBase
{
    private readonly ITourService _tourService;
    private readonly IMapper _mapper;

    public ToursController(ITourService tourService, IMapper mapper)
    {
        _tourService = tourService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<TourResource>> GetAllAsync()
    {
        var tours = await _tourService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Tour>, IEnumerable<TourResource>>(tours);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveTourResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var tour = _mapper.Map<SaveTourResource, Tour>(resource);

        var result = await _tourService.SaveAsync(tour);

        if (!result.Success)
            return BadRequest(result.Message);
        var tourResource = _mapper.Map<Tour, TourResource>(result.Resource);

        return Ok(tourResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveTourResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var tour = _mapper.Map<SaveTourResource, Tour>(resource);

        var result = await _tourService.UpdateAsync(id, tour);

        if (!result.Success)
            return BadRequest(result.Message);

        var tourResource = _mapper.Map<Tour, TourResource>(result.Resource);

        return Ok(tourResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _tourService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var tourResource = _mapper.Map<Tour, TourResource>(result.Resource);

        return Ok(tourResource);
    }
}
