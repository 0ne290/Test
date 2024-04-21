using Newtonsoft.Json;

namespace Core.Domain.VendistaApi.JsonModels.Responses;

public class CommandsResponseJson : PageBaseJson
{
    [JsonProperty("items")]
    public List<CommandResponseJson>? Items { get; set; }
    
    [JsonProperty("success")]
    public bool Success { get; set; }
}