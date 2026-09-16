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
        
        public Task<string> SaveImageAsync(Stream imagenStream, string fileName)
        {
            var extension = Path.GetExtension(fileName).ToLowerInvariant();
            var uniqueFileName = $"{Guid.NewGuid()}{extension}";
        }
        public Task<string> DeletemageAsync(string imagePath)
        {
            throw new NotImplementedException();
        }


    }
}
