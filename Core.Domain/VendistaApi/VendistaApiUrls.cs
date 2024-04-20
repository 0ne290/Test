namespace Core.Domain.VendistaApi;

public static class VendistaApiUrls
{
    public static string Token(string login, string password) => $"token?login={login}&password={password}";
    
    public static string CommandTypes(string token) => $"commands/types?token={token}";
    
    public static string Terminals(string token) => $"terminals?token={token}";
    
    public static string TerminalCommands(string token, int terminalId) => $"terminals/{terminalId}/commands?token={token}";
    
    public const string Root = "http://178.57.218.210:398/";
}