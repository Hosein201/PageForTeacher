using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using Service.UserIdentityExtension;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Utility;
using Utility.Dto;
using Utility.Utilities;

namespace Teachers.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration Configuration { get; }
        private IUserService UserService;
        private SiteSettings siteSettings;

        public UserController(IUserService userService, IConfiguration configuration)
        {
            this.UserService = userService;
            this.Configuration = configuration;
            this.siteSettings = Configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
        }

        [HttpPost(nameof(Regsiter)), AllowAnonymous]
        public async Task<IActionResult> Regsiter([FromBody] UserRegsiterDto regsiterDto,
        CancellationToken cancellationToken)
        {
            var token = await UserService.Regsiter(regsiterDto, cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, token, ApiResultStatusCode.Success.ToDisplay()));
        }

        [HttpPost(nameof(Login)), AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto, CancellationToken cancellationToken)
        {
            var token = await UserService.Login(loginDto, cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, token, ApiResultStatusCode.Success.ToDisplay()));
        }

        [HttpGet(nameof(GetCurrentUser)), Authorize]
        public async Task<IActionResult> GetCurrentUser()
        {
            var user = await UserService.GetCurrentUser(User.Identity.Name, User.Identity.GetRoleOfUser());
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, user, ApiResultStatusCode.Success.ToDisplay()));
        }

        [HttpPost(nameof(SaveImgUser)), AllowAnonymous]
        public async Task<IActionResult> SaveImgUser([FromBody]IFormFile file)
        {
            byte[] fileBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }

            if (FileHelpr.GetImageFormat(fileBytes) != ImgFormat.unknown)
            {
                string fileName = string.Empty;
                string path = string.Empty;
                string pathReturn = string.Empty;
                try
                {
                    string extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                    fileName = Guid.NewGuid().ToString() + extension; //Create a new Name 
                                                                      //for the file due to security reasons.
                    pathReturn = Path.Combine(fileName);
                    // path = Path.Combine(@"E:\githup\Vencer.me\Vencer.me\wwwroot\imagesUsers", fileName);
                    path = Path.Combine(siteSettings.UrlImage.Url, fileName);

                    using (FileStream bits = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(bits);
                    }
                }
                catch (Exception e)
                {
                    throw new AppException(ApiResultStatusCode.ServerError, e.Message);
                }

                return Ok(new ApiResult(true, ApiResultStatusCode.Success, pathReturn, ApiResultStatusCode.Success.ToDisplay()));
            }
            return BadRequest(new ApiResult(true, ApiResultStatusCode.BadRequest, null, "فرمت فایل مجاز نیست"));
        }
    }
}
