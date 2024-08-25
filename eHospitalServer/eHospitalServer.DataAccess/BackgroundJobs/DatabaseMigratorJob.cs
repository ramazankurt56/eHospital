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

        // Migration iþlemi
        await context.Database.EnsureCreatedAsync();
        await context.Database.MigrateAsync(cancellationToken);

        // Seed iþlemi
        var seedJob = scope.ServiceProvider.GetRequiredService<SeedJob>();
        await seedJob.SeedAsync();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
