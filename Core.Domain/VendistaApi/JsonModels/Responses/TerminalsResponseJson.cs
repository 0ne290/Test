using Newtonsoft.Json;

namespace Core.Domain.VendistaApi.JsonModels.Responses;

public class TerminalsResponseJson : PageBaseJson
{
    [JsonProperty("items")]
    public List<TerminalResponseJson>? Items { get; set; }
    
    [JsonProperty("success")]
    public bool Success { get; set; }
}