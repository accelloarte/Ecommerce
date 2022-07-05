using Microsoft.Extensions.Configuration;

namespace ECommerce.Services;

public class SecretService : ISecretService
{
    public SecretService(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; set; }

    public string GetSecret(string key)
    {
        var value = Environment.GetEnvironmentVariable(key);

        if (value == null)
        {
            value = Configuration[key];
        }

        return value;
    }
}