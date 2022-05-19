using System;
using Microsoft.AspNetCore.Mvc;
using FFXI_Tools_Api_dotnet.Services;
using FFXI_Tools_Api_dotnet.Models;

namespace FFXI_Tools_Api_dotnet.Controllers;

[Controller]
[Route("api/[controller]")]
public class UserController : Controller
{
  private readonly MongoDBService _mongoDBService;

  public UserController(MongoDBService mongoDBService)
  {
    _mongoDBService = mongoDBService;

  }
  [HttpGet]
  public async Task<List<User>> Get()
  {
    return await _mongoDBService.GetAsync();
  }

  [HttpPost]
  public async Task<IActionResult> Post([FromBody] User user)
  {
    await _mongoDBService.CreateAsync(user);
    return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> AddToUser(string id, [FromBody] string role)
  {
    await _mongoDBService.AddRolesAsync(id, role);
    return NoContent();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(string id)
  {
    await _mongoDBService.DeleteAsync(id);
    return NoContent();
  }
}