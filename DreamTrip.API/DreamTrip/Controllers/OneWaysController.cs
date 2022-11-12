using AutoMapper;
using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services;
using DreamTrip.API.DreamTrip.Resources;
using DreamTrip.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DreamTrip.API.DreamTrip.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class OneWayController : ControllerBase
{
    private readonly IOneWayService _oneWayService;
    private readonly IMapper _mapper;

    public OneWayController(IOneWayService oneWayService, IMapper mapper)
    {
        _oneWayService = oneWayService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<OneWayResource>> GetAllAsync()
    {
        var oneWays = await _oneWayService.ListAsync();
        var resources = _mapper.Map<IEnumerable<OneWay>, IEnumerable<OneWayResource>>(oneWays);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveOneWayResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var oneWay = _mapper.Map<SaveOneWayResource, OneWay>(resource);
        
        var result = await _oneWayService.SaveAsync(oneWay);

        if (!result.Success)
            return BadRequest(result.Message);
        var oneWayResource = _mapper.Map<OneWay, OneWayResource>(result.Resource);

        return Ok(oneWayResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveOneWayResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var oneWay = _mapper.Map<SaveOneWayResource, OneWay>(resource);
        
        var result = await _oneWayService.UpdateAsync(id, oneWay);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var oneWayResource = _mapper.Map<OneWay, OneWayResource>(result.Resource);
        
        return Ok(oneWayResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _oneWayService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var oneWayResource = _mapper.Map<OneWay, OneWayResource>(result.Resource);

        return Ok(oneWayResource);
    }
}
