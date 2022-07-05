using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net.NetworkInformation;

namespace ECommerceAPI.HealthChecks;

public class PingHealthCheck : IHealthCheck
{
    private readonly string _host;

    public PingHealthCheck(string host)
    {
        _host = host;
    }
    
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
    {
        var ping = await new Ping().SendPingAsync(_host);

        switch (ping.Status)
        {
            case IPStatus.Success:
                return HealthCheckResult.Healthy("Ping to " + _host + " was successful.");
            case IPStatus.TimedOut:
                return HealthCheckResult.Degraded("Ping to " + _host + " timed out.");
            case IPStatus.DestinationHostUnreachable:
                return HealthCheckResult.Unhealthy("The destination host " + _host + " was unreachable.");
        }

        return HealthCheckResult.Unhealthy("The host did not respond to the ping.");
    }
}