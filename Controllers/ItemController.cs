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
  public async Task<ActionResult<Item>> Get(int id)
  {
    Item? item = await _itemService.GetAsync(id);
    if (item == null)
    {
      return NotFound(new { message = "Item not Found" });
    }
    return Ok(item);
  }

  [HttpGet]
  public async Task<IActionResult> Get([FromQuery] string itemIds)
  {
    string[] list = itemIds.Split(new char[] { ',' }); //TODO: Need to come up with a cleaner solution
    int[] intList = list.Select(s => int.Parse(s)).ToList().ToArray();
    List<Item> items = await _itemService.GetMatchingAsync(intList);
    if (items == null)
    {
      return NotFound(new { message = "Item not Found" });
    }
    return Ok(items);
  }

}