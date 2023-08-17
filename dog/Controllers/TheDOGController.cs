using dog.infra;
using dog.infra.modelo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheDOGController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(int itens)
        {
            var cachorros = new List<Cachorro[]>();
            var retorno = new List<Cachorro>();
            if (itens > 0)
            {
                for (int i = 0; i <= itens; i++)
                {
                    cachorros.Add(new repositorio_de_dados().GetDOGS(new DogFilter(), itens));
                }

                retorno = TranslateCachorros(cachorros).ConfigList();

                return Ok(retorno);
            }

            else
            {
                return Ok("zero não pode");
            }
        }

        private static List<Cachorro> TranslateCachorros(List<Cachorro[]> cachorros)
        {
            List<Cachorro> retorno;
            retorno = (from c in cachorros
                select new Cachorro()
                {
                    height = c[0].height,
                    width = c[0].width,
                    url = c[0].url,
                    id = c[0].id
                }).ToList();
            return retorno;
        }
    }
}