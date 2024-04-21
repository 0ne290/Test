using Newtonsoft.Json;

namespace Core.Domain.VendistaApi.JsonModels;

public abstract class PageBaseJson
{
    [JsonProperty("page_number")]
    public int PageNumber { get; set; }
    
    [JsonProperty("items_per_page")]
    public int ItemsPerPage { get; set; }
    
    [JsonProperty("items_count")]
    public int ItemsCount { get; set; }
}