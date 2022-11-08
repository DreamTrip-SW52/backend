﻿using AutoMapper;
using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Domain.Services;
using DreamTrip.DreamTrip.Resources;
using DreamTrip.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DreamTrip.DreamTrip.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class PurchasedPackageController : ControllerBase
{
    private readonly IPurchasedPackageService _purchasedPackageService;
    private readonly IMapper _mapper;

    public PurchasedPackageController(IPurchasedPackageService purchasedPackageService, IMapper mapper)
    {
        _purchasedPackageService = purchasedPackageService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<PurchasedPackageResource>> GetAllAsync()
    {
        var purchasedPackage = await _purchasedPackageService.ListAsync();
        var resources = _mapper.Map<IEnumerable<PurchasedPackage>, IEnumerable<PurchasedPackageResource>>(purchasedPackage);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SavePurchasedPackageResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var purchasedPackage = _mapper.Map<SavePurchasedPackageResource, PurchasedPackage>(resource);
        
        var result = await _purchasedPackageService.SaveAsync(purchasedPackage);

        if (!result.Success)
            return BadRequest(result.Message);
        var purchasedPackageResource = _mapper.Map<PurchasedPackage, PurchasedPackageResource>(result.Resource);

        return Ok(purchasedPackageResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SavePurchasedPackageResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var purchasedPackage = _mapper.Map<SavePurchasedPackageResource, PurchasedPackage>(resource);
        
        var result = await _purchasedPackageService.UpdateAsync(id, purchasedPackage);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var purchasedPackageResource = _mapper.Map<PurchasedPackage, PurchasedPackageResource>(result.Resource);
        
        return Ok(purchasedPackageResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _purchasedPackageService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var purchasedPackageResource = _mapper.Map<PurchasedPackage, PurchasedPackageResource>(result.Resource);

        return Ok(purchasedPackageResource);
    }
}
