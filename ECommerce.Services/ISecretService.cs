namespace ECommerce.Services;

public interface ISecretService
{
    string GetSecret(string key);
}