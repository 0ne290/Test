using System.Text.Json.Serialization;

namespace Core.Application.VendistaApi.Dto.Responses;

public class TerminalCommandResponseDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("time_created")]
    public string TimeCreated { get; set; } = "Unknown";
    
    [JsonPropertyName("name")]
    public string Name { get; set; } = "Unknown";
    
    [JsonPropertyName("parameter1")]
    public int Parameter1 { get; set; }
    
    [JsonPropertyName("parameter2")]
    public int Parameter2 { get; set; }
    
    [JsonPropertyName("parameter3")]
    public int Parameter3 { get; set; }
    
    [JsonPropertyName("status")]
    public string Status { get; set; } = "Unknown";
}