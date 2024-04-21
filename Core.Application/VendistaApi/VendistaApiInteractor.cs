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
    
    public async Task<CommandResponseDto[]> GetAllCommands()
    {
        var commandsResponseJson = await _vendistaApi.GetAllCommands();

        var commandResponseDtos = commandsResponseJson.Items?.Select(Mapper.CommandResponseJsonToCommandResponseDto).ToArray() ?? Array.Empty<CommandResponseDto>();
        
        lock (Locker)
        {
            foreach (var commandResponseDto in commandResponseDtos)
                CommandNamesByIDs.TryAdd(commandResponseDto.Id, commandResponseDto.Name);
        }
        
        return commandResponseDtos;
    }

    public async Task<TerminalCommandResponseDto[]> GetCommandsByTerminal(int terminalId) =>
        (await _vendistaApi.GetCommandsByTerminal(terminalId)).Items?.Select(i =>
            Mapper.TerminalCommandResponseJsonToTerminalCommandResponseDto(i, CommandNamesByIDs[i.CommandId])).ToArray() ??
        Array.Empty<TerminalCommandResponseDto>();

    public async Task SendCommandToTerminal(int terminalId, CommandRequestDto commandRequestDto) =>
        await _vendistaApi.SendCommandToTerminal(terminalId,
            Mapper.CommandRequestDtoToCommandRequestJson(commandRequestDto));
    
    public void Dispose() => _vendistaApi.Dispose();
    
    private readonly VendistaApiEntity _vendistaApi;

    private static readonly Dictionary<int, string> CommandNamesByIDs = new();

    private static readonly object Locker = new();
}