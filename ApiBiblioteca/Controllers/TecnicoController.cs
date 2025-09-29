using ApiBiblioteca.Models;
using ApiBiblioteca.Repository.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiBiblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TecnicoController : ControllerBase
    {
        private readonly ITecnicoRepository _repository;

        public TecnicoController(ITecnicoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tecnicos = await _repository.GetAll();
            return Ok(tecnicos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tecnico = await _repository.GetById(id);
            if (tecnico == null) return NotFound();
            return Ok(tecnico);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Tecnico tecnico)
        {
            var newTecnico = await _repository.Add(tecnico);
            return CreatedAtAction(nameof(GetById), new { id = newTecnico.Id }, newTecnico);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Tecnico tecnico)
        {
            var updated = await _repository.Update(id, tecnico);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repository.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}