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

        lock (Locker)
        {
            if (httpResponseMessage.StatusCode is HttpStatusCode.Unauthorized or HttpStatusCode.Forbidden)
                _token = GetToken();
        }

        httpResponseMessage.Dispose();
    }

    private string GetToken()
    {
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, VendistaApiUrls.Token("user2", "password2"));
        httpRequestMessage.Headers.Add("Accept", "application/json");

        var httpResponseMessage = _httpClient.Send(httpRequestMessage);
        
        httpRequestMessage.Dispose();

        var serializedJsonResponse = httpResponseMessage.Content.ReadAsStringAsync().Result;// Не асинхронной версии этого метода нет, поэтому будет такой костыль
        
        httpResponseMessage.Dispose();
        
        return JsonConvert.DeserializeObject<TokenResponse>(serializedJsonResponse)!.Token;
    }

    public int[] GetIDsOfAllTerminals()
    {
        
    }
    
    public int[] GetAllCommands()
    {
        
    }

    public int[] GetCommandsByTerminal()
    {

    }

    public bool SendCommandToTerminal()
    {
        
    }
    
    public void Dispose() => _httpClient.Dispose();
    
    private readonly HttpClient _httpClient;
    
    private static string _token = string.Empty;
    
    private static readonly object Locker = new ();
}