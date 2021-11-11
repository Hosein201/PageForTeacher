using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System.Threading;
using System.Threading.Tasks;
using Utility.Utilities;

namespace Teachers.Controllers
{
    [Route("api/Teacher")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private ITeacherService Service;
        public TeacherController(ITeacherService service)
        {
            Service = service;
        }

        [HttpGet(nameof(GetTeachers)), AllowAnonymous]
        public async Task<IActionResult> GetTeachers([FromQuery] int skip, int take, CancellationToken cancellationToken)
        {
            var result = await Service.GetTeachers(skip, take, cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, result, ApiResultStatusCode.Success.ToDisplay()));
        }

        [HttpGet(nameof(GetTeacher)), AllowAnonymous]
        public async Task<IActionResult> GetTeacher([FromQuery] int userId, CancellationToken cancellationToken)
        {
            var result = await Service.GetTeacher(userId, cancellationToken);

            return Ok(new ApiResult(true, ApiResultStatusCode.Success, result, ApiResultStatusCode.Success.ToDisplay()));
        }

        [HttpGet(nameof(GetTeachersByField)), AllowAnonymous]
        public async Task<IActionResult> GetTeachersByField([FromQuery] int codeField, CancellationToken cancellationToken)
        {
            var result = await Service.GetTeachersByField(codeField, cancellationToken);

            return Ok(new ApiResult(true, ApiResultStatusCode.Success, result, ApiResultStatusCode.Success.ToDisplay()));
        }

        [HttpPost(nameof(CreateTeacher)), AllowAnonymous]
        public async Task<IActionResult> CreateTeacher() // TODO Create Panel
        {
            await Task.CompletedTask;
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, null, ApiResultStatusCode.Success.ToDisplay()));
        }
    }
}
