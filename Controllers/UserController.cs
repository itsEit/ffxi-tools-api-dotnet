using System;
using Microsoft.AspNetCore.Mvc;
using FFXI_Tools_Api_dotnet.Services;
using FFXI_Tools_Api_dotnet.Models;

namespace FFXI_Tools_Api_dotnet.Controllers;

[Controller]
[Route("api/[controller]")]
public class UserController : Controller
{
  private readonly UserService _userService;

  public UserController(UserService userService)
  {
    _userService = userService;

  }
  [HttpGet]
  public async Task<List<User>> Get()
  {
    return await _userService.GetAsync();
  }

  [HttpPost]
  public async Task<IActionResult> Post([FromBody] User user)
  {
    await _userService.CreateAsync(user);
    return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> AddToUser(string id, [FromBody] string role)
  {
    await _userService.AddRolesAsync(id, role);
    return NoContent();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(string id)
  {
    await _userService.DeleteAsync(id);
    return NoContent();
  }
}