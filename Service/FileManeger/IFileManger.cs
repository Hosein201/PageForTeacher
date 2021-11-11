using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Service.FileManger
{
    public interface IFileManger
    {
        Task<string> GetImgPath(IFormFile file , string url);
    }
}
