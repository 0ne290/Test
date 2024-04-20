using Newtonsoft.Json;

namespace Core.Domain.VendistaApi.JsonModels.Responses;

public class TokenResponse
{
    [JsonProperty("token")]
    public string Token { get; set; }
    
    [JsonProperty("owner_id")]
    public int OwnerId { get; set; }
    
    [JsonProperty("role_id")]
    public int RoleId { get; set; }
    
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("user_id")]
    public int UserId { get; set; }
}