using Libreria.Business.Services;
using Libreria.Data.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILibreriaService _libreriaService;

        public BooksController(ILibreriaService libreriaService)
        {
            _libreriaService = libreriaService;
        }

        [HttpPost]
        public IActionResult Create(LibrosDTO librosDTO)
        {
            try
            {
                var result = _libreriaService.Insert(librosDTO);

                return result > 0 ? Created() : BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_libreriaService.GetAll());
        }

        [HttpGet("books")]
        public IActionResult GetByBookName(string bookName)
        {
            return Ok(_libreriaService.GetByName(bookName));
        }

        [HttpGet("booksautor")]
        public IActionResult GetByAutorName(string autorName)
        {
            return Ok(_libreriaService.GetByAutor(autorName));
        }

    }
}
