﻿using AutoMapper;
using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Services;
using DreamTrip.DreamTrip.Resources;
using DreamTrip.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DreamTrip.DreamTrip.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class PackageController : ControllerBase
{
    private readonly IPackageService _packageService;
    private readonly IMapper _mapper;

    public PackageController(IPackageService packageService, IMapper mapper)
    {
        _packageService = packageService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<PackageResource>> GetAllAsync()
    {
        var packages = await _packageService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Package>, IEnumerable<PackageResource>>(packages);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SavePackageResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var package = _mapper.Map<SavePackageResource, Package>(resource);
        
        var result = await _packageService.SaveAsync(package);

        if (!result.Success)
            return BadRequest(result.Message);
        var packageResource = _mapper.Map<Package, PackageResource>(result.Resource);

        return Ok(packageResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SavePackageResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var package = _mapper.Map<SavePackageResource, Package>(resource);
        
        var result = await _packageService.UpdateAsync(id, package);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var packageResource = _mapper.Map<Package, PackageResource>(result.Resource);
        
        return Ok(packageResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _packageService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var packageResource = _mapper.Map<Package, PackageResource>(result.Resource);

        return Ok(packageResource);
    }
}
