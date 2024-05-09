using CoreBusiness;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Services;

public class DataInitializer : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public DataInitializer(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        await RoleInitializer.InitializeAsync(roleManager);
        await UserInitializer.InitializeAsync(userManager, roleManager);
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

}