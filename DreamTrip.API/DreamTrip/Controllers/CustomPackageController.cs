using AutoMapper;
using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services;
using DreamTrip.API.DreamTrip.Resources;
using DreamTrip.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DreamTrip.API.DreamTrip.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class CustomPackagesController : ControllerBase
{
    private readonly ICustomPackageService _customPackageService;
    private readonly IMapper _mapper;

    public CustomPackagesController(ICustomPackageService customPackageService, IMapper mapper)
    {
        _customPackageService = customPackageService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<CustomPackageResource>> GetAllAsync()
    {
        var agencies = await _customPackageService.ListAsync();
        var resources = _mapper.Map<IEnumerable<CustomPackage>, IEnumerable<CustomPackageResource>>(agencies);

        return resources;
    }
    
    [HttpGet ("{id}")]
    public async Task<CustomPackageResource> GetByIdAsync(int id)
    {
        var customPackage = await _customPackageService.FindByIdAsync(id);
        var customPackageResource = _mapper.Map<CustomPackage, CustomPackageResource>(customPackage);
        return customPackageResource;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveCustomPackageResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var customPackage = _mapper.Map<SaveCustomPackageResource, CustomPackage>(resource);
        
        var result = await _customPackageService.SaveAsync(customPackage);

        if (!result.Success)
            return BadRequest(result.Message);
        var customPackageResource = _mapper.Map<CustomPackage, CustomPackageResource>(result.Resource);

        return Ok(customPackageResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCustomPackageResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var customPackage = _mapper.Map<SaveCustomPackageResource, CustomPackage>(resource);
        
        var result = await _customPackageService.UpdateAsync(id, customPackage);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var customPackageResource = _mapper.Map<CustomPackage, CustomPackageResource>(result.Resource);
        
        return Ok(customPackageResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _customPackageService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var customPackageResource = _mapper.Map<CustomPackage, CustomPackageResource>(result.Resource);

        return Ok(customPackageResource);
    }
}
