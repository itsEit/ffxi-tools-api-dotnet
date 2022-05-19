using FFXI_Tools_Api_dotnet.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace FFXI_Tools_Api_dotnet.Services;

public class MongoDBService
{
  private readonly IMongoCollection<User> _userCollection;

  public MongoDBService(IOptions<MongoDbSettings> mongoDbSettings)
  {
    MongoClient client = new MongoClient(mongoDbSettings.Value.ConectionURI);
    IMongoDatabase database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
    _userCollection = database.GetCollection<User>(mongoDbSettings.Value.CollectionName);
  }

  public async Task CreateAsync(User user)
  {
    await _userCollection.InsertOneAsync(user);
    return;
  }

  public async Task<List<User>> GetAsync()
  {
    return await _userCollection.Find(new BsonDocument()).ToListAsync();
  }

  public async Task AddRolesAsync(string id, string role)
  {
    FilterDefinition<User> filter = Builders<User>.Filter.Eq("Id", id);
    UpdateDefinition<User> update = Builders<User>.Update.AddToSet<string>("roles", role);
    await _userCollection.UpdateOneAsync(filter, update);
    return;
  }

  public async Task DeleteAsync(string id)
  {
    FilterDefinition<User> filter = Builders<User>.Filter.Eq("Id", id);
    await _userCollection.DeleteOneAsync(filter);
    return;
  }
}