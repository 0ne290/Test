namespace Core.Application.VendistaApi.Dto.Requests;

public class CommandRequestDto
{
    public int Id { get; set; }

    public IList<int> IntParams { get; set; } = Array.Empty<int>();

    public IList<string> StringParams { get; set; } = Array.Empty<string>();
}