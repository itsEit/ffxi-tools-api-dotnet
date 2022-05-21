using FFXI_Tools_Api_dotnet.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FFXI_Tools_Api_dotnet.Services;

public class ItemService
{
  private readonly IMongoCollection<Item> _itemCollection;

  public ItemService(IOptions<MongoDbSettings> mongoDbSettings)
  {
    MongoClient client = new MongoClient(mongoDbSettings.Value.ConectionURI);
    IMongoDatabase database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
    _itemCollection = database.GetCollection<Item>("ffxi-items");
  }

  public async Task<Item> GetAsync(int id)
  {
    FilterDefinition<Item> filter = Builders<Item>.Filter.Eq("_id", id);
    return await _itemCollection.Find(filter).Limit(1).SingleAsync();
  }

}