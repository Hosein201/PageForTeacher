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
    [Route("api/Edu")]
    [ApiController]
    public class EduController : ControllerBase
    {
        private IEduService EduService;
        public EduController(IEduService _eduService)
        {
            EduService = _eduService;
        }

        [HttpPost(nameof(CreateEdu)), AllowAnonymous]
        public async Task<IActionResult> CreateEdu([FromBody] EduDto eduDto, CancellationToken cancellationToken)
        {
            eduDto.StudentId = User.Identity.GetUserId();
            await EduService.CreateEdu(eduDto, cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, null, ApiResultStatusCode.Success.ToDisplay()));
        }
    }
}
