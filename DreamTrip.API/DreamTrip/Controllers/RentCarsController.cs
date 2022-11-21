using AutoMapper;
using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services;
using DreamTrip.API.DreamTrip.Resources;
using DreamTrip.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DreamTrip.API.DreamTrip.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class RentCarsController : ControllerBase
{
    private readonly IRentCarService _rentCarService;
    private readonly IMapper _mapper;

    public RentCarsController(IRentCarService rentCarService, IMapper mapper)
    {
        _rentCarService = rentCarService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<RentCarResource>> GetAllAsync()
    {
        var rentCars = await _rentCarService.ListAsync();
        var resources = _mapper.Map<IEnumerable<RentCar>, IEnumerable<RentCarResource>>(rentCars);

        return resources;
    }
    
    [HttpGet ("filters/{locationId}/{priceMin}/{priceMax}/{capacityMin}/{capacityMax}/{brand}")]
    public async Task<IEnumerable<RentCarResource>> GetFilteredAsync(int locationId, int priceMin, int priceMax, int capacityMin, int capacityMax, string brand)
    {
        var rentCars = await _rentCarService.FindByFiltersAsync(
            locationId, priceMin, priceMax, capacityMin, capacityMax, brand);
        var resources = _mapper.Map<IEnumerable<RentCar>, IEnumerable<RentCarResource>>(rentCars);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveRentCarResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var rentCar = _mapper.Map<SaveRentCarResource, RentCar>(resource);

        var result = await _rentCarService.SaveAsync(rentCar);

        if (!result.Success)
            return BadRequest(result.Message);
        var rentCarResource = _mapper.Map<RentCar, RentCarResource>(result.Resource);

        return Ok(rentCarResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveRentCarResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var rentCar = _mapper.Map<SaveRentCarResource, RentCar>(resource);

        var result = await _rentCarService.UpdateAsync(id, rentCar);

        if (!result.Success)
            return BadRequest(result.Message);

        var rentCarResource = _mapper.Map<RentCar, RentCarResource>(result.Resource);

        return Ok(rentCarResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _rentCarService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var rentCarResource = _mapper.Map<RentCar, RentCarResource>(result.Resource);

        return Ok(rentCarResource);
    }
}
