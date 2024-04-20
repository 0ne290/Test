namespace Core.Application.VendistaApi.Dto.Responses;

public class CommandResponseDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public Dictionary<string, int> DefaultIntValues { get; set; }
        
    public Dictionary<string, string> DefaultStringValues { get; set; }
}