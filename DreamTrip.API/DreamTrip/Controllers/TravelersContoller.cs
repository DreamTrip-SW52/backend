using AutoMapper;
using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services;
using DreamTrip.API.DreamTrip.Resources;
using DreamTrip.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DreamTrip.API.DreamTrip.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class TravelersController : ControllerBase
{
    private readonly ITravelerService _travelerService;
    private readonly IMapper _mapper;

    public TravelersController(ITravelerService travelerService, IMapper mapper)
    {
        _travelerService = travelerService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<TravelerResource>> GetAllAsync()
    {
        var travelers = await _travelerService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Traveler>, IEnumerable<TravelerResource>>(travelers);

        return resources;
    }
    
    [HttpGet ("{id}")]
    public async Task<TravelerResource> GetByIdAsync(int id)
    {
        var traveler = await _travelerService.FindByIdAsync(id);
        var travelerResource = _mapper.Map<Traveler, TravelerResource>(traveler);
        return travelerResource;
    }
    
    [HttpGet("EmailAndPassword/{email}/{password}")]
    public async Task<TravelerResource> GetByEmailAndPasswordAsync(string email, string password)
    {
        var traveler = await _travelerService.FindByEmailAndPasswordAsync(email, password);
        var travelerResource = _mapper.Map<Traveler, TravelerResource>(traveler);
        return travelerResource;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveTravelerResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var traveler = _mapper.Map<SaveTravelerResource, Traveler>(resource);
        
        var result = await _travelerService.SaveAsync(traveler);

        if (!result.Success)
            return BadRequest(result.Message);
        var travelerResource = _mapper.Map<Traveler, TravelerResource>(result.Resource);

        return Ok(travelerResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveTravelerResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var traveler = _mapper.Map<SaveTravelerResource, Traveler>(resource);
        
        var result = await _travelerService.UpdateAsync(id, traveler);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var travelerResource = _mapper.Map<Traveler, TravelerResource>(result.Resource);
        
        return Ok(travelerResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _travelerService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var travelerResource = _mapper.Map<Traveler, TravelerResource>(result.Resource);

        return Ok(travelerResource);
    }
}