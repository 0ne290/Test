using System.Net;
using Core.Domain.VendistaApi.JsonModels.Responses;
using Newtonsoft.Json;

namespace Core.Domain.VendistaApi;

public class VendistaApi : IDisposable
{
    public VendistaApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(VendistaApiUrls.Root);
    }
    
    public async Task ValidateToken()
    {
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"{VendistaApiUrls.Terminals(_token)}&ItemsOnPage=1");
        httpRequestMessage.Headers.Add("Accept", "text/plain");

        var httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage);
        
        httpRequestMessage.Dispose();

        if (httpResponseMessage.StatusCode is HttpStatusCode.Unauthorized or HttpStatusCode.Forbidden)
            _token = await GetToken();
            
        httpResponseMessage.Dispose();
    }

    private async Task<string> GetToken()
    {
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, VendistaApiUrls.Token("user2", "password2"));
        httpRequestMessage.Headers.Add("Accept", "application/json");

        var httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage);
        
        httpRequestMessage.Dispose();

        var serializedJsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
        
        httpResponseMessage.Dispose();
        
        return JsonConvert.DeserializeObject<TokenResponse>(serializedJsonResponse)!.Token;
    }
    
    public void Dispose() => _httpClient.Dispose();
    
    private readonly HttpClient _httpClient;

    private static string _token = string.Empty;
}