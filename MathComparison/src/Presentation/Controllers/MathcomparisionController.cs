using MathComparison.src.Application.DTOs;
using MathComparison.src.Application.Services;
using MathComparison.src.Domain.Entities;
using MathComparison.src.Domain.Interfaces;
using MathComparison.src.Domain.ValueObject;
using Microsoft.AspNetCore.Mvc;

namespace MathComparison.src.Presentation.Controllers
{
    [ApiController]
    [Route("api/math")]
    public class MathcomparisionController : ControllerBase
    {
        private readonly IMathExpressionService _service;

        public MathcomparisionController(IMathExpressionService service)
        {
            _service = service;
        }

        [HttpGet("generate")]
        public IActionResult Generate([FromQuery] string difficulty )
        {
            try
            {
                (string expression1, string expression2) = _service.GenerateExpressions(difficulty);
                return Ok(new { Expression1 = expression1, Expression2 = expression2 });
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("compare")]
        public IActionResult Compare([FromBody] ComparisionRequest request)
        {
            try
            {
                var valid = _service.EvaluateComparison(request);
                return Ok(new { Valid = valid });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }
    }
}
