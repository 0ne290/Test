using Newtonsoft.Json;

namespace Core.Domain.VendistaApi.JsonModels.Responses;

public class TerminalCommandResponseJson
{
    [JsonProperty("terminal_id")]
    public int TerminalId { get; set; }
    
    [JsonProperty("user_name")]
    public string? UserName { get; set; }
    
    [JsonProperty("command_id")]
    public int CommandId { get; set; }
    
    [JsonProperty("parameter1")]
    public int Parameter1 { get; set; }
    
    [JsonProperty("parameter2")]
    public int Parameter2 { get; set; }
    
    [JsonProperty("parameter3")]
    public int Parameter3 { get; set; }
    
    [JsonProperty("parameter4")]
    public int Parameter4 { get; set; }
    
    [JsonProperty("parameter5")]
    public int Parameter5 { get; set; }
    
    [JsonProperty("parameter6")]
    public int Parameter6 { get; set; }
    
    [JsonProperty("parameter7")]
    public int Parameter7 { get; set; }
    
    [JsonProperty("parameter8")]
    public int Parameter8 { get; set; }
    
    [JsonProperty("str_parameter1")]
    public string? StrParameter1 { get; set; }
    
    [JsonProperty("str_parameter2")]
    public string? StrParameter2 { get; set; }
    
    [JsonProperty("state")]
    public int State { get; set; }
    
    [JsonProperty("state_name")]
    public string? StateName { get; set; }
    
    [JsonProperty("time_created")]
    public string? TimeCreated { get; set; }
    
    [JsonProperty("time_delivered")]
    public string? TimeDelivered { get; set; }
    
    [JsonProperty("id")]
    public int Id { get; set; }
}