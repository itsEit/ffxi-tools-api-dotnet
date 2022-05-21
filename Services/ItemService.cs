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

  public async Task<Item?> GetAsync(int id) =>
        await _itemCollection.Find(x => x._id == id).FirstOrDefaultAsync();

  public async Task<List<Item>> GetMatchingAsync(int[] ids)
  {
    return await _itemCollection.Find(Builders<Item>.Filter.In("_id", ids)).ToListAsync();
  }

  //   public async Task<List<Book>> GetAsync() =>
  //       await _booksCollection.Find(_ => true).ToListAsync();

  //   public async Task<Book?> GetAsync(string id) =>
  //       await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

  //   public async Task CreateAsync(Book newBook) =>
  //       await _booksCollection.InsertOneAsync(newBook);

  //   public async Task UpdateAsync(string id, Book updatedBook) =>
  //       await _booksCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

  //   public async Task RemoveAsync(string id) =>
  //       await _booksCollection.DeleteOneAsync(x => x.Id == id);

}