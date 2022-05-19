using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace FFXI_Tools_Api_dotnet.Models;

public class User
{
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  public string? Id { get; set; }

  [BsonElement("name")]
  public string name { get; set; } = null!;

  [BsonElement("email")]
  public string email { get; set; } = null!;

  [BsonElement("roles")]
  [JsonPropertyName("roles")]
  public List<string> roles { get; set; } = null!;

}
