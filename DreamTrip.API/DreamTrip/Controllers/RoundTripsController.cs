using AutoMapper;
using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services;
using DreamTrip.API.DreamTrip.Resources;
using DreamTrip.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DreamTrip.API.DreamTrip.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class RoundTripsController : ControllerBase
{
    private readonly IRoundTripService _roundTripService;
    private readonly IMapper _mapper;

    public RoundTripsController(IRoundTripService roundTripService, IMapper mapper)
    {
        _roundTripService = roundTripService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<RoundTripResource>> GetAllAsync()
    {
        var roundTrips = await _roundTripService.ListAsync();
        var resources = _mapper.Map<IEnumerable<RoundTrip>, IEnumerable<RoundTripResource>>(roundTrips);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveRoundTripResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var roundTrip = _mapper.Map<SaveRoundTripResource, RoundTrip>(resource);

        var result = await _roundTripService.SaveAsync(roundTrip);

        if (!result.Success)
            return BadRequest(result.Message);
        var roundTripResource = _mapper.Map<RoundTrip, RoundTripResource>(result.Resource);

        return Ok(roundTripResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveRoundTripResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var roundTrip = _mapper.Map<SaveRoundTripResource, RoundTrip>(resource);

        var result = await _roundTripService.UpdateAsync(id, roundTrip);

        if (!result.Success)
            return BadRequest(result.Message);

        var roundTripResource = _mapper.Map<RoundTrip, RoundTripResource>(result.Resource);

        return Ok(roundTripResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _roundTripService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var roundTripResource = _mapper.Map<RoundTrip, RoundTripResource>(result.Resource);

        return Ok(roundTripResource);
    }
}
