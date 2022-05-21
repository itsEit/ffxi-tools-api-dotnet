using System;
using Microsoft.AspNetCore.Mvc;
using FFXI_Tools_Api_dotnet.Services;
using FFXI_Tools_Api_dotnet.Models;

namespace FFXI_Tools_Api_dotnet.Controllers;

[Controller]
[Route("api/[controller]")]
public class ItemController : Controller
{
  private readonly ItemService _itemService;

  public ItemController(ItemService itemService)
  {
    _itemService = itemService;

  }
  [HttpGet("{id}")]
  public async Task<Item> Get(int id)
  {
    return await _itemService.GetAsync(id);
  }

}