using ApiCepCB.Facade.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiCepCB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CepController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync(
            [FromQuery( Name = "cep")] string cep,
            [FromServices] ICepFacade _cepFacade)
        {
            await _cepFacade.GetCep(cep);
            
            return Ok();
        }
    }
}