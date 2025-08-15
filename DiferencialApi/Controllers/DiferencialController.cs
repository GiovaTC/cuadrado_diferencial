using Microsoft.AspNetCore.Mvc;

namespace DiferencialApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiferencialController : ControllerBase
    {
        //Ejemplo: funcion f(x) = x^2 -> f'(x) = 2x
        [HttpGet]
        public IActionResult Calcular(double x, double dx)
        {
            double derivada = 2 * x; // f'(x)
            double dy = derivada * dx; // dy = f'(x) * dx

            return Ok(new
            {
                x,
                dx,
                derivada,
                dy
            });
        }
    }
}
