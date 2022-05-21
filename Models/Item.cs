using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace FFXI_Tools_Api_dotnet.Models;

[BsonIgnoreExtraElements]
public class Item
{
  [BsonId]
  [BsonElement("id")]
  public int? _id { get; set; }

  [BsonElement("name")]
  public string name { get; set; } = null!;

  [BsonElement("nameFull")]
  public string nameFull { get; set; } = null!;

  [BsonElement("category")]
  public string category { get; set; } = null!;

  [BsonElement("level")]
  public int level { get; set; }

  [BsonElement("desc")]
  public string desc { get; set; } = null!;

  [BsonElement("slotName")]
  public string slotName { get; set; } = null!;

  [BsonElement("jobSlots")]
  [JsonPropertyName("jobSlots")]
  public List<string> jobSlots { get; set; } = null!;

}
