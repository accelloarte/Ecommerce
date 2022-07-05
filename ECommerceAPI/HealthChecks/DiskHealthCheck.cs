using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ECommerceAPI.HealthChecks;

public class DiskHealthCheck : IHealthCheck
{
    private readonly IConfiguration _configuration;

    public DiskHealthCheck(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
    {
        var driveInfo = new DriveInfo("C:");

        var maxSpace = _configuration.GetValue<long>("StorageConfiguration:FreeDiskSpaceMax");

        var espacioSuficiente = (driveInfo.AvailableFreeSpace / (1024 * 1024 * 1024)) > maxSpace;

        return await Task.FromResult(espacioSuficiente ? HealthCheckResult.Healthy("Todo bien") : HealthCheckResult.Degraded("No hay espacio suficiente"));
    }
}