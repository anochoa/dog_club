using dog.infra;
using dog.infra.modelo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dog.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SaveTheDogController : ControllerBase
    {

        [HttpPost]
        public IActionResult SaveTheDog([FromBody] Cachorro dogueiros)
        {
            return Ok(new repositorio_de_dados().SaveTheDog(dogueiros));
        }
        [HttpPost(Name = "SaveLosDogs")]        
        public IActionResult SaveLosDogs([FromBody] Cachorro[] doguinhos)
        {

            foreach (var item in doguinhos)
            {
                new repositorio_de_dados().SaveTheDog(item);                
            }
            return Ok(true);
        }

    }
}
