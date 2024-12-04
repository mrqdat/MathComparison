using MathComparison.src.Application.DTOs;
using MathComparison.src.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MathComparison.src.Presentation.Controllers
{
    [ApiController]
    [Route("api/math")]
    public class MathcomparisionController :Controller
    {
        private readonly IMathExpressionService _service;

        public MathcomparisionController(IMathExpressionService service)
        {
            _service = service;
        }

        [HttpGet("generate")]
        public async Task<IActionResult> Generate([FromQuery] string difficulty)
        {
            try
            {
                var data = await _service.GenerateExpressions(difficulty);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [HttpPost("compare")]
        public async Task<IActionResult> Compare([FromBody]ComparisionRequest request)
        {
            try
            {
                var valid = await _service.EvaluateComparison(request);
                return Ok(new { Valid = valid });
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message) { StatusCode = 400 };
            }
        }
    }
}
