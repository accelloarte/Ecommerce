using System.Net;

namespace ECommerce.Entities;

public class AppSettings
{
    public StorageConfiguration StorageConfiguration { get; set; }
    public Jwt Jwt { get; set; }
    public string SendGridApiKey { get; set; }
}

public class Jwt
{
    public string SigningKey { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public double TokenExpiration { get; set; }
}

public class StorageConfiguration
{
    public string Path { get; set; }
    public string PublicUrl { get; set; }
}