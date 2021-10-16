using MusicWeb.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Interfaces.Files
{
    public interface IFileService
    {
        Task<string> UploadFile(byte[] fileBytes, string dir);
        void DeleteFile(string name, string dir);
    }
}
