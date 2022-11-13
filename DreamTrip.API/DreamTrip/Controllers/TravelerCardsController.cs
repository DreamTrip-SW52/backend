using AutoMapper;
using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services;
using DreamTrip.API.DreamTrip.Resources;
using DreamTrip.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DreamTrip.API.DreamTrip.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class TravelerCardsController : ControllerBase
{
    private readonly ITravelerCardService _tavelerCardService;
    private readonly IMapper _mapper;

    public TravelerCardsController(ITravelerCardService tavelerCardService, IMapper mapper)
    {
        _tavelerCardService = tavelerCardService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<TravelerCardResource>> GetAllAsync()
    {
        var travelerCards = await _tavelerCardService.ListAsync();
        var resources = _mapper.Map<IEnumerable<TravelerCard>, IEnumerable<TravelerCardResource>>(travelerCards);

        return resources;
    }

    [HttpGet("travelerId/{travelerId}")]
    public async Task<IEnumerable<TravelerCardResource>> GetByTravelerId(int travelerId)
    {
        var travelerCards = await _tavelerCardService.FindByTravelerIdAsync(travelerId);
        var resources = _mapper.Map<IEnumerable<TravelerCard>, IEnumerable<TravelerCardResource>>(travelerCards);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveTravelerCardResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var tavelerCard = _mapper.Map<SaveTravelerCardResource, TravelerCard>(resource);

        var result = await _tavelerCardService.SaveAsync(tavelerCard);

        if (!result.Success)
            return BadRequest(result.Message);
        var tavelerCardResource = _mapper.Map<TravelerCard, TravelerCardResource>(result.Resource);

        return Ok(tavelerCardResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveTravelerCardResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var tavelerCard = _mapper.Map<SaveTravelerCardResource, TravelerCard>(resource);

        var result = await _tavelerCardService.UpdateAsync(id, tavelerCard);

        if (!result.Success)
            return BadRequest(result.Message);

        var tavelerCardResource = _mapper.Map<TravelerCard, TravelerCardResource>(result.Resource);

        return Ok(tavelerCardResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _tavelerCardService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var tavelerCardResource = _mapper.Map<TravelerCard, TravelerCardResource>(result.Resource);

        return Ok(tavelerCardResource);
    }
}
