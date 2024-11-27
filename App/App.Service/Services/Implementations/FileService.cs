using System.Reflection;
using App.Data.Repositories.Interfaces;
using App.Service.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace App.Service.Services.Implementations
{
    public class FileService : ServiceBase, IFileService
    {
        private readonly string _wwwRootPath;

        public FileService(IRepositoryManager repositoryManager, IMapper mapper, string wwwRootPath) : base(repositoryManager, mapper)
        {
            _wwwRootPath = wwwRootPath;
        }

        public async Task<IEnumerable<string>> SaveImagesAsync(IEnumerable<IFormFile> images)
        {
            List<string> imagesUrl = new();
            foreach (var image in images)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
                var filePath = Path.Combine(_wwwRootPath, "images", fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }
                imagesUrl.Add(filePath);
            }
            return imagesUrl;
        }
    }
}
