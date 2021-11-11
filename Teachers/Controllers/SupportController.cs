using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Service.UserIdentityExtension;
using System.Threading;
using System.Threading.Tasks;
using Utility.Dto;
using Utility.Utilities;

namespace Teachers.Controllers
{
    [Route("api/Support")]
    [ApiController]
    public class SupportController : ControllerBase
    {
        private ISupportService SupportService;
        public SupportController(ISupportService supportService)
        {
            SupportService = supportService;
        }

        [HttpGet(nameof(GetSupports)), AllowAnonymous]
        public async Task<IActionResult> GetSupports([FromQuery] int skip, int take, CancellationToken cancellationToken)
        {
            if (User.Identity.IsAdmin())
            {
                var result = await SupportService.GetSupports(skip, take, cancellationToken);
                return Ok(new ApiResult(true, ApiResultStatusCode.Success, result, ApiResultStatusCode.Success.ToDisplay()));
            }
            else
            {
                var result = await SupportService.GetSupports(User.Identity.GetUserId(), skip, take, cancellationToken);
                return Ok(new ApiResult(true, ApiResultStatusCode.Success, result, ApiResultStatusCode.Success.ToDisplay()));
            }
        }

        [HttpPost(nameof(CreateSupport)),AllowAnonymous]
        public async Task<IActionResult> CreateSupport([FromBody] SupportCreateDto supportDto, CancellationToken cancellationToken)
        {
            await SupportService.CreateSupport(supportDto, 1, cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, null, ApiResultStatusCode.Success.ToDisplay()));
        }

        [HttpPost(nameof(UpdateSupport)), AllowAnonymous]
        public async Task<IActionResult> UpdateSupport([FromBody] UpdateSupportDto updateSupportDto, CancellationToken cancellationToken)
        {
            await SupportService.UpdateSupport(updateSupportDto, cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, null, ApiResultStatusCode.Success.ToDisplay()));
        }
    }
}