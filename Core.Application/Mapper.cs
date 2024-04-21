using Core.Application.VendistaApi.Dto.Requests;
using Core.Application.VendistaApi.Dto.Responses;
using Core.Domain.VendistaApi.JsonModels.Requests;
using Core.Domain.VendistaApi.JsonModels.Responses;

namespace Core.Application;

public static class Mapper
{
    public static CommandResponseDto CommandResponseJsonToCommandResponseDto(CommandResponseJson commandResponseJson)
    {
        var res = new CommandResponseDto
        {
            Id = commandResponseJson.Id, Name = commandResponseJson.Name,
            DefaultIntValues = new Dictionary<string, int>(), DefaultStringValues = new Dictionary<string, string>()
        };

        if (commandResponseJson.ParameterName1 != null)
            res.DefaultIntValues.Add(commandResponseJson.ParameterName1, commandResponseJson.ParameterDefaultValue1!.Value);
        if (commandResponseJson.ParameterName2 != null)
            res.DefaultIntValues.Add(commandResponseJson.ParameterName2, commandResponseJson.ParameterDefaultValue2!.Value);
        if (commandResponseJson.ParameterName3 != null)
            res.DefaultIntValues.Add(commandResponseJson.ParameterName3, commandResponseJson.ParameterDefaultValue3!.Value);
        if (commandResponseJson.ParameterName4 != null)
            res.DefaultIntValues.Add(commandResponseJson.ParameterName4, commandResponseJson.ParameterDefaultValue4!.Value);
        if (commandResponseJson.ParameterName5 != null)
            res.DefaultIntValues.Add(commandResponseJson.ParameterName5, commandResponseJson.ParameterDefaultValue5!.Value);
        if (commandResponseJson.ParameterName6 != null)
            res.DefaultIntValues.Add(commandResponseJson.ParameterName6, commandResponseJson.ParameterDefaultValue6!.Value);
        if (commandResponseJson.ParameterName7 != null)
            res.DefaultIntValues.Add(commandResponseJson.ParameterName7, commandResponseJson.ParameterDefaultValue7!.Value);
        if (commandResponseJson.ParameterName8 != null)
            res.DefaultIntValues.Add(commandResponseJson.ParameterName8, commandResponseJson.ParameterDefaultValue8!.Value);
        
        if (commandResponseJson.StrParameterName1 != null)
            res.DefaultStringValues.Add(commandResponseJson.StrParameterName1, commandResponseJson.StrParameterDefaultValue1!);
        if (commandResponseJson.StrParameterName2 != null)
            res.DefaultStringValues.Add(commandResponseJson.StrParameterName2, commandResponseJson.StrParameterDefaultValue2!);

        return res;
    }
    
    public static CommandRequestJson CommandRequestDtoToCommandRequestJson(CommandRequestDto commandRequestDto)
    {
        var res = new CommandRequestJson
        {
            CommandId = commandRequestDto.Id
        };
        
        var intParams = commandRequestDto.IntParams.Cast<int?>().ToList();
        for (var i = 7; i > commandRequestDto.IntParams.Count - 1; i--)
            intParams.Add(null);
        
        var stringParams = commandRequestDto.StringParams.Cast<string?>().ToList();
        for (var i = 1; i > commandRequestDto.StringParams.Count - 1; i--)
            stringParams.Add(null);

        res.Parameter1 = intParams[0];
        res.Parameter2 = intParams[1];
        res.Parameter3 = intParams[2];
        res.Parameter4 = intParams[3];
        res.Parameter5 = intParams[4];
        res.Parameter6 = intParams[5];
        res.Parameter7 = intParams[6];
        res.Parameter8 = intParams[7];
        
        res.StrParameter1 = stringParams[0];
        res.StrParameter2 = stringParams[1];

        return res;
    }
}