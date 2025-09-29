using ApiBiblioteca.Models;
using ApiBiblioteca.Repository.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiBiblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibroController : ControllerBase
    {
        private readonly ILibroRepository _libroRepository;

        public LibroController(ILibroRepository libroRepository)
        {
            _libroRepository = libroRepository;
        }

        // GET api/libro
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var libros = await _libroRepository.GetAll();
            return Ok(libros);
        }

        // GET api/libro/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var libro = await _libroRepository.GetById(id);
            if (libro == null)
                return NotFound();

            return Ok(libro);
        }

        // POST api/libro
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Libro libro)
        {
            var newLibro = await _libroRepository.Add(libro);
            return CreatedAtAction(nameof(Get), new { id = newLibro.Id }, newLibro);
        }
    

    // PUT api/libro/
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Libro libro)
        {
            if (id != libro.Id)
                return BadRequest("El ID del libro no coincide.");

            var updated = await _libroRepository.Update(libro);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        // DELETE api/libro/
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _libroRepository.Delete(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }

}
