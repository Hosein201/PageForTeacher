using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System.Threading;
using System.Threading.Tasks;
using Utility.Utilities;

namespace Teachers.Controllers
{
    [Route("api/Student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService Service;
        public StudentController(IStudentService service)
        {
            Service = service;
        }

        [HttpGet(nameof(GetStudents)), AllowAnonymous]
        public async Task<IActionResult> GetStudents([FromQuery] int skip, int take, CancellationToken cancellationToken)
        {
            var result = await Service.GetStudents(skip, take, cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, result, ApiResultStatusCode.Success.ToDisplay()));
        }


        [HttpGet(nameof(GetPayment)), AllowAnonymous]
        public async Task<IActionResult> GetPayment([FromQuery] int userId, int skip, int take, CancellationToken cancellationToken)
        {
            var result = await Service.GetPayments(userId, skip, take, cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, result, ApiResultStatusCode.Success.ToDisplay()));
        }
    }
}
