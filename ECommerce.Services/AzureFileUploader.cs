using Azure.Storage.Blobs;
using ECommerce.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ECommerce.Services;

public class AzureFileUploader : IFileUploader
{
    private readonly IOptions<AppSettings> _options;
    private readonly ILogger<AzureFileUploader> _logger;

    public AzureFileUploader(IOptions<AppSettings> options, ILogger<AzureFileUploader> logger)
    {
        _options = options;
        _logger = logger;
    }

    public async Task<string> UploadFileAsync(string? base64String, string? fileName)
    {
        if (string.IsNullOrEmpty(base64String) || string.IsNullOrEmpty(fileName))
            return string.Empty;

        try
        {
            // Cuenta de almacenamiento EcuadorMitocode (BLOB)

            var client = new BlobServiceClient(_options.Value.StorageConfiguration.Path);

            // Container (carpeta) pictures

            var container = client.GetBlobContainerClient("pictures");

            // BLOB 

            var blobClient = container.GetBlobClient(fileName);

            await using var mem = new MemoryStream(Convert.FromBase64String(base64String));
            await blobClient.UploadAsync(mem, overwrite: true);

            return $"{_options.Value.StorageConfiguration.PublicUrl}{fileName}";
        }
        catch (Exception ex)
        {
            _logger.LogCritical("Error al subir a Azure blob Storage: {message}", ex.Message);
            return string.Empty;
        }
    }
}