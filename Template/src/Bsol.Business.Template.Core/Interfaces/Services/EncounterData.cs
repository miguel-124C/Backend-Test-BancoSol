using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bsol.Business.Template.Core.Interfaces.Services;

public class EncounterData
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public required string Name { get; set; }
    [JsonPropertyName("names")]
    public required IEnumerable<NameModel> Names { get; set; }
    [JsonPropertyName("order")]
    public int Order { get; set; }
}
public class NameModel
{
    [JsonPropertyName("language")]
    public required Language Language { get; set; }
    [JsonPropertyName("name")]
    public required string Name { get; set; }
}
public class Language
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }
    [JsonPropertyName("url")]
    public required string Url { get; set; }
}
