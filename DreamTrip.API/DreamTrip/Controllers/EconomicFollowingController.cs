using AutoMapper;
using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services;
using DreamTrip.API.DreamTrip.Resources;
using DreamTrip.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DreamTrip.API.DreamTrip.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class EconomicFollowingsController : ControllerBase
{
    private readonly IEconomicFollowingService _economicFollowingService;
    private readonly IMapper _mapper;

    public EconomicFollowingsController(IEconomicFollowingService economicFollowingService, IMapper mapper)
    {
        _economicFollowingService = economicFollowingService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<EconomicFollowingResource>> GetAllAsync()
    {
        var economicFollowings = await _economicFollowingService.ListAsync();
        var resources = _mapper.Map<IEnumerable<EconomicFollowing>, IEnumerable<EconomicFollowingResource>>(economicFollowings);

        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveEconomicFollowingResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var economicFollowing = _mapper.Map<SaveEconomicFollowingResource, EconomicFollowing>(resource);

        var result = await _economicFollowingService.SaveAsync(economicFollowing);

        if (!result.Success)
            return BadRequest(result.Message);
        var economicFollowingResource = _mapper.Map<EconomicFollowing, EconomicFollowingResource>(result.Resource);

        return Ok(economicFollowingResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveEconomicFollowingResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var economicFollowing = _mapper.Map<SaveEconomicFollowingResource, EconomicFollowing>(resource);

        var result = await _economicFollowingService.UpdateAsync(id, economicFollowing);

        if (!result.Success)
            return BadRequest(result.Message);

        var economicFollowingResource = _mapper.Map<EconomicFollowing, EconomicFollowingResource>(result.Resource);

        return Ok(economicFollowingResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _economicFollowingService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var economicFollowingResource = _mapper.Map<EconomicFollowing, EconomicFollowingResource>(result.Resource);

        return Ok(economicFollowingResource);
    }
}
