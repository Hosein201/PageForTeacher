using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.FileManger
{
    //public class FileManeger : IFileManger
    //{
    //    public IConfiguration Configuration { get; }

    //    public FileManeger(IConfiguration _configuration)
    //    {
    //        Configuration = _configuration;
    //        siteSettings=Configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
    //    }
    //    public async Task<string> GetImgPath(IFormFile file ,string url)
    //    {
    //        if (CheckIfImageFile(file))
    //        {
    //            return await WriteImg(file ,url);
    //        }

    //        throw new Exception(ApiResultStatusCode.LogicError, "Invalid image file");
    //    }
    //    #region WriteImg
    //    private bool CheckIfImageFile(IFormFile file)
    //    {
    //        byte[] fileBytes;
    //        using (MemoryStream ms = new MemoryStream())
    //        {
    //            file.CopyTo(ms);
    //            fileBytes = ms.ToArray();
    //        }

    //        return GetImageFormat(fileBytes) != ImageFormat.unknown;
    //    }
    //    private async Task<string> WriteImg(IFormFile file , string Url)
    //    {
    //        string fileName = string.Empty;
    //        string path = string.Empty;
    //        string pathReturn = string.Empty;
    //        try
    //        {
    //            string extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
    //            fileName = Guid.NewGuid().ToString() + extension; //Create a new Name 
    //                                                              //for the file due to security reasons.
    //            pathReturn = Path.Combine(fileName);
    //            // path = Path.Combine(@"E:\githup\Vencer.me\Vencer.me\wwwroot\imagesUsers", fileName);
    //            path = Path.Combine( Url, fileName);

    //            using (FileStream bits = new FileStream(path, FileMode.Create))
    //            {
    //                await file.CopyToAsync(bits);
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            throw new AppException(ApiResultStatusCode.ServerError, e.Message);
    //        }

    //        return pathReturn;
    //    }
    //    public static ImageFormat GetImageFormat(byte[] bytes)
    //    {
    //        var bmp = Encoding.ASCII.GetBytes("BM");     // BMP
    //        var gif = Encoding.ASCII.GetBytes("GIF");    // GIF
    //        var png = new byte[] { 137, 80, 78, 71 };              // PNG
    //        var tiff = new byte[] { 73, 73, 42 };                  // TIFF
    //        var tiff2 = new byte[] { 77, 77, 42 };                 // TIFF
    //        var jpeg = new byte[] { 255, 216, 255, 224 };          // jpeg
    //        var jpeg2 = new byte[] { 255, 216, 255, 225 };         // jpeg canon

    //        if (bmp.SequenceEqual(bytes.Take(bmp.Length)))
    //            return ImageFormat.bmp;

    //        if (gif.SequenceEqual(bytes.Take(gif.Length)))
    //            return ImageFormat.gif;

    //        if (png.SequenceEqual(bytes.Take(png.Length)))
    //            return ImageFormat.png;

    //        if (tiff.SequenceEqual(bytes.Take(tiff.Length)))
    //            return ImageFormat.tiff;

    //        if (tiff2.SequenceEqual(bytes.Take(tiff2.Length)))
    //            return ImageFormat.tiff;

    //        if (jpeg.SequenceEqual(bytes.Take(jpeg.Length)))
    //            return ImageFormat.jpeg;

    //        if (jpeg2.SequenceEqual(bytes.Take(jpeg2.Length)))
    //            return ImageFormat.jpeg;

    //        return ImageFormat.unknown;
    //    }
    //    public enum ImageFormat
    //    {
    //        bmp,
    //        jpg,
    //        jpeg,
    //        gif,
    //        tiff,
    //        png,
    //        unknown
    //    }
    //    #endregion
    //}
}
