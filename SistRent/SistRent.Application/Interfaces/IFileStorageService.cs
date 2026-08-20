using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.Interfaces
{
    public interface IFileStorageService
    {
        Task<string> SaveImageAsync(Stream imagenStream,string fileName);
        Task<string> DeletemageAsync(string imagePath);
    }
}
