using Microsoft.AspNetCore.Mvc;
using PurchaseApi.Application.DTOs;
using PurchaseApi.Application.Services.Interface;

namespace PurchaseApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [Route("token")]
    public async Task<ActionResult> PostAsync([FromForm] UserDTO userDto)
    {
        var result = await _userService.GenerateTokenAsync(userDto);
        if (result.IsSuccess)
            return Ok(result.Data);

        return BadRequest(result);
    }
}
