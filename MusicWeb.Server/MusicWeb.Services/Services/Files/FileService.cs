using Microsoft.AspNetCore.Hosting;
using MusicWeb.Models.Constants;
using MusicWeb.Models.Enums;
using MusicWeb.Services.Interfaces.Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Services.Files
{
    public class FileService : IFileService
    {
        private string _rootPath;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _rootPath = webHostEnvironment.WebRootPath;

            if (string.IsNullOrWhiteSpace(_rootPath))
            {
                _rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            }

            if (!string.IsNullOrEmpty(_rootPath) && !Directory.Exists(_rootPath))
                Directory.CreateDirectory(_rootPath);
        }

        public async Task<string> UploadFile(byte[] fileBytes, string dir)
        {
            var path = Path.Combine(_rootPath, dir);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var fileName = Guid.NewGuid().ToString() + ".jpg";
            var filePath = Path.Combine(path, fileName);

            await File.WriteAllBytesAsync(filePath, fileBytes);

            await using FileStream fs = new(filePath, FileMode.Create);
            new MemoryStream(fileBytes).CopyTo(fs);

            return filePath;
        }

        public void DeleteFile(string name, string dir)
        {
            var path = Path.Combine(_rootPath, dir, name);

            if (File.Exists(path))
                File.Delete(path);
        }

        private string GetPathFromImageType(ImageTypeEnum imageType)
        {
            switch (imageType)
            {
                case ImageTypeEnum.User: return FilePathConsts.UserPath;
                case ImageTypeEnum.Artist: return FilePathConsts.ArtistPath;
                case ImageTypeEnum.Album: return FilePathConsts.AlbumPath;
                case ImageTypeEnum.Song: return FilePathConsts.SongPath;
                default: throw new ArgumentException("Incorrect image type");
            }
        }
    }
}
