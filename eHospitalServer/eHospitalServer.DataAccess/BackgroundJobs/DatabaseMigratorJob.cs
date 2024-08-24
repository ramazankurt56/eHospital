using eHospitalServer.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace eHospitalServer.DataAccess.BackgroundJobs;

public class DatabaseMigratorJob : IHostedService
{
    private readonly IServiceProvider _serviceProvider;
    public DatabaseMigratorJob(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;


    }
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();


        await context.Database.EnsureCreatedAsync();


        await context.Database.MigrateAsync(cancellationToken);
    }


    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
