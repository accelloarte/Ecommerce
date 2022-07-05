using ECommerce.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ECommerce.Services;

public class FileUploader : IFileUploader
{
    private readonly IOptions<AppSettings> _options;
    private readonly ILogger<FileUploader> _logger;

    public FileUploader(IOptions<AppSettings> options, ILogger<FileUploader> logger)
    {
        _options = options;
        _logger = logger;
    }

    public async Task<string> UploadFileAsync(string? base64String, string? fileName)
    {
        try
        {

            if (string.IsNullOrEmpty(base64String) || string.IsNullOrEmpty(fileName))
                return string.Empty;

            var bytes = Convert.FromBase64String(base64String);

            // C:\CursoNET6\Servidor\zapatilla.jpg
            // ~/pictures/zapatilla.jpg

            var path = Path.Combine(_options.Value.StorageConfiguration.Path, fileName);

            await using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await fileStream.WriteAsync(bytes, 0, bytes.Length);
            }

            // http://localhost/ecommercepictures/zapatilla.jpg

            return $"{_options.Value.StorageConfiguration.PublicUrl}{fileName}";

        }
        catch (Exception ex)
        {
            _logger.LogCritical("Ocurrio un error al registrar el archivo: {fileName}\n{message}", 
                fileName, ex.Message);
            return string.Empty;
        }
    }
}