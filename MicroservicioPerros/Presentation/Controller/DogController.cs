using MicroservicioPerros.Business.Services;
using MicroservicioPerros.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicioPerros.Presentation.Controller
{
    [EnableCors("AllowAny")]
    [Route("api/[controller]")] //http://ip:port/api/Dog
    [ApiController]
    public class DogController : ControllerBase
    {
        private readonly IDogService _dogService;

        public DogController(IDogService dogService)
        {
            _dogService = dogService;
        }

        [HttpPost]
        public IActionResult Insert(DogDTO dogDTO)
        {
            try
            {
                _dogService.Insert(dogDTO);
                return Created();
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_dogService.GetAll());
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _dogService.Delete(id);
                return Ok($"Perro eliminado {id}");
            }
            catch (Exception ex) { 
                return NotFound(ex.Message);
            }
        }

    }
}
