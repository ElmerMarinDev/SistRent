using Microsoft.Extensions.Options;
using SistRent.Application.Interfaces;
using SistRent.Infrastructure.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Infrastructure.Services
{
    public class FileStorageService : IFileStorageService
    {
        private readonly FileStorageOptions _options;

        public FileStorageService(IOptions<FileStorageOptions>options)
        {
            _options = options.Value;
        }        
        
        public async Task<string> SaveImageAsync(Stream imagenStream, string fileName)
        {
            var extension = Path.GetExtension(fileName).ToLowerInvariant();
            var uniqueFileName = $"{Guid.NewGuid()}{extension}";

            var folderPath = Path.Combine(_options.BaseUrl, _options.ImagesFolder);
            var filePath = Path.Combine(folderPath, uniqueFileName);


            if(!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            using (var fileStream=new FileStream(filePath, FileMode.Create))
            {

                await imagenStream.CopyToAsync(fileStream);
            }

            return $"/{_options.ImagesFolder}/{uniqueFileName}";

        }
        public async Task<bool> DeletemageAsync(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
                return false;

            var relativePath = imagePath.TrimStart('/');
            var physicalPath = Path.Combine(_options.BaseUrl, relativePath.Replace('/',Path.DirectorySeparatorChar));

            if (File.Exists(physicalPath))
            {
                File.Delete(physicalPath);
                return await Task.FromResult(true);
            }

            return await Task.FromResult(false);
        }


    }
}
