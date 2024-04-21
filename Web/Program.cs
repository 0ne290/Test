using Core.Application.VendistaApi;
using Core.Application.VendistaApi.Dto.Requests;
using Core.Domain.VendistaApi;
using Web.Middlewares;

namespace Web;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        /*var x = new VendistaApiInteractor(new VendistaApiEntity(new HttpClient()));

        await x.ValidateToken();

        var y = await x.GetIDsOfAllTerminals();
        var y1 = await x.GetAllCommands();
        await x.SendCommandToTerminal(129, new CommandRequestDto { Id = 8, IntParams = new[] { 666, 777, 888 } });
        Thread.Sleep(1000);
        var y2 = await x.GetCommandsByTerminal(129);

        Console.WriteLine("Идентификаторы всех терминалов:");
        foreach (var ey in y)
            Console.WriteLine(ey);
        
        Console.WriteLine("\nВсе команды:");
        foreach (var ey1 in y1)
        {
            var xc = "";
            foreach (var eey1 in ey1.DefaultIntValues)
            {
                xc += eey1.Key + " := ";
                xc += eey1.Value + "; ";
            }
            
            var xt = "";
            foreach (var eey1 in ey1.DefaultStringValues)
            {
                xt += eey1.Key + " := ";
                xt += eey1.Value + "; ";
            }
            
            Console.WriteLine($"{ey1.Id}; {ey1.Name}; {{ {xc}}}; {{ {xt}}}");
        }
        
        Console.WriteLine("\nВсе команды на терминале:");
        foreach (var ey2 in y2)
        {
            Console.WriteLine($"{ey2.Id} {ey2.TimeCreated} {ey2.Name} {ey2.Parameter1} {ey2.Parameter2} {ey2.Parameter3} {ey2.Status}");// У всех команд ID равен 0 потому что у внешнего апи таково значение подтягиваемого параметра у всех команд на терминалах
        }
        
        x.Dispose();
        
        return;*/
        
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddHttpClient();
        builder.Services.AddScoped<VendistaApiInteractor>(serviceProvider => new VendistaApiInteractor(new VendistaApiEntity(serviceProvider.GetService<IHttpClientFactory>()!.CreateClient())));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        
        app.UseMiddleware<VendistaApiTokenValidator>();

        await app.RunAsync();
    }
}