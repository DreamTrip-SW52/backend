using AutoMapper;
using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services;
using DreamTrip.API.DreamTrip.Resources;
using DreamTrip.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DreamTrip.API.DreamTrip.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class TransportClassesController : ControllerBase
{
    private readonly ITransportClassService _transportClassService;
    private readonly IMapper _mapper;

    public TransportClassesController(ITransportClassService transportClassService, IMapper mapper)
    {
        _transportClassService = transportClassService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<TransportClassResource>> GetAllAsync()
    {
        var transportClasses = await _transportClassService.ListAsync();
        var resources = _mapper.Map<IEnumerable<TransportClass>, IEnumerable<TransportClassResource>>(transportClasses);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveTransportClassResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var transportClass = _mapper.Map<SaveTransportClassResource, TransportClass>(resource);

        var result = await _transportClassService.SaveAsync(transportClass);

        if (!result.Success)
            return BadRequest(result.Message);
        var transportClassResource = _mapper.Map<TransportClass, TransportClassResource>(result.Resource);

        return Ok(transportClassResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveTransportClassResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var transportClass = _mapper.Map<SaveTransportClassResource, TransportClass>(resource);

        var result = await _transportClassService.UpdateAsync(id, transportClass);

        if (!result.Success)
            return BadRequest(result.Message);

        var transportClassResource = _mapper.Map<TransportClass, TransportClassResource>(result.Resource);

        return Ok(transportClassResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _transportClassService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var transportClassResource = _mapper.Map<TransportClass, TransportClassResource>(result.Resource);

        return Ok(transportClassResource);
    }
}
