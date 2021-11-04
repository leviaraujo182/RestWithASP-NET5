using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var sum = decimal.Parse(firstNumber) + decimal.Parse(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("sub/{first}/{second}")]
        public IActionResult Subtraction(string first, string second)
        {
            if (isNumeric(first) && isNumeric(second))
            {
                var sub = decimal.Parse(first) - decimal.Parse(second);
                return Ok(sub.ToString());

            }
                return BadRequest("Requisição inválida");
        }

        public IActionResult Divider(string first, string second)
        {
            if(isNumeric(first) && isNumeric(second))
            {
                var div = decimal.Parse(first) / decimal.Parse(second);
                return Ok(div.ToString());
            }
            return BadRequest("Requisição inválida");
        }

        private bool isNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, 
                System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo, 
                out number);
            return isNumber;
        }
        
    }
}