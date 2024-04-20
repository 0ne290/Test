using Core.Application.VendistaApi.Dto.Requests;
using Core.Application.VendistaApi.Dto.Responses;
using Core.Domain.VendistaApi;

namespace Core.Application.VendistaApi;

public class VendistaApiInteractor : IDisposable
{
    public VendistaApiInteractor(VendistaApiEntity vendistaApi) => _vendistaApi = vendistaApi;

    public async Task ValidateToken() => await _vendistaApi.ValidateToken();
    
    public async Task<IEnumerable<CommandResponseDto>> GetAllCommands()
    {
        var commandsResponseJson = await _vendistaApi.GetAllCommands();

        return commandsResponseJson.Items.Select(Mapper.CommandResponseJsonToCommandResponseDto);
    }

    public async Task SendCommandToTerminal(int terminalId, CommandRequestDto commandRequestDto) =>
        await _vendistaApi.SendCommandToTerminal(terminalId,
            Mapper.CommandRequestDtoToCommandRequestJson(commandRequestDto));
    
    public void Dispose() => _vendistaApi.Dispose();
    
    private readonly VendistaApiEntity _vendistaApi;
}