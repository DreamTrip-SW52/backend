using AutoMapper;
using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services;
using DreamTrip.API.DreamTrip.Resources;
using DreamTrip.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DreamTrip.API.DreamTrip.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class HealthCenterController : ControllerBase
{
    private readonly IHealthCenterService _healthCenterService;
    private readonly IMapper _mapper;

    public HealthCenterController(IHealthCenterService healthCenterService, IMapper mapper)
    {
        _healthCenterService = healthCenterService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<HealthCenterResource>> GetAllAsync()
    {
        var healthCenters = await _healthCenterService.ListAsync();
        var resources = _mapper.Map<IEnumerable<HealthCenter>, IEnumerable<HealthCenterResource>>(healthCenters);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveHealthCenterResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var healthCenter = _mapper.Map<SaveHealthCenterResource, HealthCenter>(resource);
        
        var result = await _healthCenterService.SaveAsync(healthCenter);

        if (!result.Success)
            return BadRequest(result.Message);
        var healthCenterResource = _mapper.Map<HealthCenter, HealthCenterResource>(result.Resource);

        return Ok(healthCenterResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveHealthCenterResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var healthCenter = _mapper.Map<SaveHealthCenterResource, HealthCenter>(resource);
        
        var result = await _healthCenterService.UpdateAsync(id, healthCenter);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var healthCenterResource = _mapper.Map<HealthCenter, HealthCenterResource>(result.Resource);
        
        return Ok(healthCenterResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _healthCenterService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var healthCenterResource = _mapper.Map<HealthCenter, HealthCenterResource>(result.Resource);

        return Ok(healthCenterResource);
    }
}
