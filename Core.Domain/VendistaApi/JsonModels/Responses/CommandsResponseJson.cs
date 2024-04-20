using Newtonsoft.Json;

namespace Core.Domain.VendistaApi.JsonModels.Responses;

public class CommandsResponseJson
{
    [JsonProperty("page_number")]
    public int PageNumber { get; set; }
    
    [JsonProperty("items_per_page")]
    public int ItemsPerPage { get; set; }
    
    [JsonProperty("items_count")]
    public int ItemsCount { get; set; }
    
    [JsonProperty("items")]
    public List<CommandResponseJson> Items { get; set; }
    
    [JsonProperty("success")]
    public bool Success { get; set; }
}