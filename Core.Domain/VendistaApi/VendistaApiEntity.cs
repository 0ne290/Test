using System.Net;
using Core.Domain.VendistaApi.JsonModels.Requests;
using Core.Domain.VendistaApi.JsonModels.Responses;
using Newtonsoft.Json;

namespace Core.Domain.VendistaApi;

public class VendistaApiEntity : IDisposable
{
    public VendistaApiEntity(HttpClient httpClient)
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
        
        return JsonConvert.DeserializeObject<TokenResponseJson>(serializedJsonResponse)!.Token;
    }

    public int[] GetIDsOfAllTerminals()
    {
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, VendistaApiUrls.Terminals(_token));
        httpRequestMessage.Headers.Add("Accept", "text/plain");

        var httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage);
        
        httpRequestMessage.Dispose();

        var deserializedJsonResponse = JObject.Parse(await httpResponseMessage.Content.ReadAsStringAsync())

        httpResponseMessage.Dispose();

        return deserializedJsonResponse["items"].Children().Select(terminalJsonResponse => (int)terminalJsonResponse["id"]);
    }
    
    public async Task<CommandsResponseJson> GetAllCommands()
    {
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, VendistaApiUrls.CommandTypes(_token));
        httpRequestMessage.Headers.Add("Accept", "text/plain");

        var httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage);
        
        httpRequestMessage.Dispose();

        var serializedJsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
        
        httpResponseMessage.Dispose();

        return JsonConvert.DeserializeObject<CommandsResponseJson>(serializedJsonResponse)!;
    }

    public int[] GetCommandsByTerminal()
    {

    }

    public async Task SendCommandToTerminal(int terminalId, CommandRequestJson commandRequestJson)
    {
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, VendistaApiUrls.TerminalCommands(_token, terminalId));
        httpRequestMessage.Headers.Add("Accept", "text/plain");
        httpRequestMessage.Headers.Add("Content-Type", "application/json-patch+json");
        httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(commandRequestJson));

        var httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage);
        httpRequestMessage.Dispose();
        httpResponseMessage.Dispose();
    }
    
    public void Dispose() => _httpClient.Dispose();
    
    private readonly HttpClient _httpClient;
    
    private static string _token = string.Empty;
    
    private static readonly object Locker = new ();
}
