using Core.Application.VendistaApi;

namespace Web.Middlewares;

public class VendistaApiTokenValidator
{
    public VendistaApiTokenValidator(RequestDelegate next) => _next = next;
 
    public async Task InvokeAsync(HttpContext context, VendistaApiInteractor vendistaApi)
    {
        await vendistaApi.ValidateToken();
        
        await _next.Invoke(context);
    }
    
    private readonly RequestDelegate _next;
}