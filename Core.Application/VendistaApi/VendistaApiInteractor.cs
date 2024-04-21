using Core.Application.VendistaApi.Dto.Requests;
using Core.Application.VendistaApi.Dto.Responses;
using Core.Domain.VendistaApi;

namespace Core.Application.VendistaApi;

public class VendistaApiInteractor : IDisposable
{
    public VendistaApiInteractor(VendistaApiEntity vendistaApi) => _vendistaApi = vendistaApi;

    public async Task ValidateToken() => await _vendistaApi.ValidateToken();

    public async Task<IEnumerable<int>> GetIDsOfAllTerminals() =>
        (await _vendistaApi.GetAllTerminals()).Items!.Select(i => i.Id);
    
    public async Task<IEnumerable<CommandResponseDto>> GetAllCommands()
    {
        var commandsResponseJson = await _vendistaApi.GetAllCommands();

        var commandResponseDtos = commandsResponseJson.Items.Select(Mapper.CommandResponseJsonToCommandResponseDto).ToArray();
        
        lock (Locker)
        {
            foreach (var commandResponseDto in commandResponseDtos)
                TerminalNamesByIDs.TryAdd(commandResponseDto.Id, commandResponseDto.Name);
        }
        
        return commandResponseDtos;
    }
    
    public async Task<TerminalCommandResponseDto> GetCommandsByTerminal(int terminalId)
    {
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, VendistaApiUrls.TerminalCommands(_token, terminalId));
        httpRequestMessage.Headers.Add("Accept", "text/plain");

        var httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage);
        
        httpRequestMessage.Dispose();

        var serializedJsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
        
        httpResponseMessage.Dispose();

        return JsonConvert.DeserializeObject<TerminalCommandsJsonResponse>(serializedJsonResponse)!;
    }

    public async Task SendCommandToTerminal(int terminalId, CommandRequestDto commandRequestDto) =>
        await _vendistaApi.SendCommandToTerminal(terminalId,
            Mapper.CommandRequestDtoToCommandRequestJson(commandRequestDto));
    
    public void Dispose() => _vendistaApi.Dispose();
    
    private readonly VendistaApiEntity _vendistaApi;

    private static readonly Dictionary<int, string> TerminalNamesByIDs = new();

    private static readonly object Locker = new();
}