namespace Core.Application.VendistaApi.Dto.Responses;

public class TerminalCommandResponseDto
{
    public int Id { get; set; }

    public string TimeCreated { get; set; } = "Unknown";
    
    public string Name { get; set; } = "Unknown";
    
    public int Parameter1 { get; set; }
    
    public int Parameter2 { get; set; }
    
    public int Parameter3 { get; set; }
    
    public string Status { get; set; } = "Unknown";
}