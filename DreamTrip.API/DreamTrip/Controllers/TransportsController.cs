using AutoMapper;
using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services;
using DreamTrip.API.DreamTrip.Resources;
using DreamTrip.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DreamTrip.API.DreamTrip.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class TransportsController : ControllerBase
{
    private readonly ITransportService _transportService;
    private readonly IMapper _mapper;

    public TransportsController(ITransportService transportService, IMapper mapper)
    {
        _transportService = transportService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<TransportResource>> GetAllAsync()
    {
        var transports = await _transportService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Transport>, IEnumerable<TransportResource>>(transports);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveTransportResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var transport = _mapper.Map<SaveTransportResource, Transport>(resource);

        var result = await _transportService.SaveAsync(transport);

        if (!result.Success)
            return BadRequest(result.Message);
        var transportResource = _mapper.Map<Transport, TransportResource>(result.Resource);

        return Ok(transportResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveTransportResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var transport = _mapper.Map<SaveTransportResource, Transport>(resource);

        var result = await _transportService.UpdateAsync(id, transport);

        if (!result.Success)
            return BadRequest(result.Message);

        var transportResource = _mapper.Map<Transport, TransportResource>(result.Resource);

        return Ok(transportResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _transportService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var transportResource = _mapper.Map<Transport, TransportResource>(result.Resource);

        return Ok(transportResource);
    }
}
