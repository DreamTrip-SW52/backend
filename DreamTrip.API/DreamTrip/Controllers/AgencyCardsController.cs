using AutoMapper;
using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services;
using DreamTrip.API.DreamTrip.Resources;
using DreamTrip.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DreamTrip.API.DreamTrip.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class AgencyCardController : ControllerBase
{
    private readonly IAgencyCardService _agencyCardService;
    private readonly IMapper _mapper;

    public AgencyCardController(IAgencyCardService agencyCardService, IMapper mapper)
    {
        _agencyCardService = agencyCardService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<AgencyCardResource>> GetAllAsync()
    {
        var agencyCards = await _agencyCardService.ListAsync();
        var resources = _mapper.Map<IEnumerable<AgencyCard>, IEnumerable<AgencyCardResource>>(agencyCards);

        return resources;
    }
    
    [HttpGet ("agencyId/{agencyId}")]
    public async Task<IEnumerable<AgencyCardResource>> GetByAgencyId(int agencyId)
    {
        var agencyCards = await _agencyCardService.FindByAgencyIdAsync(agencyId);
        var resources = _mapper.Map<IEnumerable<AgencyCard>, IEnumerable<AgencyCardResource>>(agencyCards);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveAgencyCardResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var agencyCard = _mapper.Map<SaveAgencyCardResource, AgencyCard>(resource);
        
        var result = await _agencyCardService.SaveAsync(agencyCard);

        if (!result.Success)
            return BadRequest(result.Message);
        var AgencyCardResource = _mapper.Map<AgencyCard, AgencyCardResource>(result.Resource);

        return Ok(AgencyCardResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAgencyCardResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var agencyCard = _mapper.Map<SaveAgencyCardResource, AgencyCard>(resource);
        
        var result = await _agencyCardService.UpdateAsync(id, agencyCard);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var AgencyCardResource = _mapper.Map<AgencyCard, AgencyCardResource>(result.Resource);
        
        return Ok(AgencyCardResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _agencyCardService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var AgencyCardResource = _mapper.Map<AgencyCard, AgencyCardResource>(result.Resource);

        return Ok(AgencyCardResource);
    }
}
