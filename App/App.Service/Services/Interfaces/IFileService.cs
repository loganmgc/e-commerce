using Microsoft.AspNetCore.Http;

namespace App.Service.Services.Interfaces
{
   public interface IFileService
    {
        Task<IEnumerable<string>> SaveImagesAsync(IEnumerable<IFormFile> images);
    }
}
