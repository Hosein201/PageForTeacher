using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System.Threading;
using System.Threading.Tasks;
using Utility.Dto;
using Utility.Utilities;

namespace Teachers.Controllers
{
    [Route("api/Field")]
    [ApiController]
    public class FieldController : ControllerBase
    {
        private IFieldService FialdService;

        public FieldController(IFieldService fialdService)
        {
            FialdService = fialdService;
        }

        [HttpGet(nameof(GetFields)), AllowAnonymous]
        public async Task<IActionResult> GetFields(CancellationToken cancellationToken)
        {
            var result = await FialdService.GetFields(cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, result, ApiResultStatusCode.Success.ToDisplay()));
        }

        [HttpGet(nameof(GetFieldByCode)), AllowAnonymous]
        public async Task<IActionResult> GetFieldByCode([FromQuery] int code, CancellationToken cancellationToken)
        {
            var result = await FialdService.GetFieldByCode(code, cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, result, ApiResultStatusCode.Success.ToDisplay()));
        }


        [HttpGet(nameof(GetFieldByName)), AllowAnonymous]
        public async Task<IActionResult> GetFieldByName([FromQuery] string name, CancellationToken cancellationToken)
        {
            var result = await FialdService.GetFieldByName(name, cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, result, ApiResultStatusCode.Success.ToDisplay()));
        }

        [HttpPost(nameof(CreateField)), AllowAnonymous]
        public async Task<IActionResult> CreateField([FromBody] FieldCreateDto fieldDto, CancellationToken cancellationToken)
        {
            await FialdService.CreateField(fieldDto, cancellationToken);
            return Ok(new ApiResult(true, ApiResultStatusCode.Success, null, ApiResultStatusCode.Success.ToDisplay()));
        }
    }
}
