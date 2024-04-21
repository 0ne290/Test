using Newtonsoft.Json;

namespace Core.Domain.VendistaApi.JsonModels.Responses;

public class TerminalCommandsResponseJson : PageBaseJson
{
    [JsonProperty("items")]
    public List<TerminalCommandResponseJson>? Items { get; set; }
    
    [JsonProperty("success")]
    public bool Success { get; set; }
}