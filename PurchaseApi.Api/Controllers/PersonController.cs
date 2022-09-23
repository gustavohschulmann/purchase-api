using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PurchaseApi.Application.DTOs;
using PurchaseApi.Application.Services.Interface;
using PurchaseApi.Domain.FiltersDb;

namespace PurchaseApi.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpPost]
    public async Task<ActionResult> PostAsync([FromBody] PersonDTO personDto)
    {
        var result = await _personService.CreateAsync(personDto);
        if (result.IsSuccess) return Ok(result);

        return BadRequest(result);
    }
    
    [HttpGet]
    public async Task<ActionResult> GetAsync()
    {
        var result = await _personService.GetAsync();
        if (result.IsSuccess) return Ok(result);

        return BadRequest(result);
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult> GetByIdAsync(int id)
    {
        var result = await _personService.GetByIdAsync(id);
        if (result.IsSuccess) return Ok(result);

        return BadRequest(result);
    }
    
    [HttpPut]
    public async Task<ActionResult> PutAsync([FromBody] PersonDTO personDto)
    {
        var result = await _personService.UpdateAsync(personDto);
        if (result.IsSuccess) return Ok(result);

        return BadRequest(result);
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var result = await _personService.DeleteAsync(id);
        if (result.IsSuccess) return Ok(result);

        return BadRequest(result);
    }
    
    [HttpGet]
    [Route("paged")] //FromQuery é da concatenação na URL
    public async Task<ActionResult> GetPagedAsync([FromQuery] PersonFilterDb personFilterDb)
    {
        var result = await _personService.GetPagedAsync(personFilterDb);
        if (result.IsSuccess) return Ok(result);

        return BadRequest(result);
    }
    
}