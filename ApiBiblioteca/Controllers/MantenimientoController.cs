using ApiBiblioteca.Models;
using ApiBiblioteca.Repository.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MantenimientoController : ControllerBase
    {
        private readonly IMantenimientoRepository _mantenimientoRepository;

       public MantenimientoController(IMantenimientoRepository mantenimientoRepository)
        {
            _mantenimientoRepository=mantenimientoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var mantenimientos = await _mantenimientoRepository.GetAll();
            return Ok(mantenimientos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var mantenimiento = await _mantenimientoRepository.GetById(id);
            if (mantenimiento == null) 
                return NotFound();
            
            return Ok(mantenimiento);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Mantenimiento mantenimiento)
        {
            var newMantenimiento = await _mantenimientoRepository.Add(mantenimiento);
            return CreatedAtAction(nameof(Get), new { id = newMantenimiento.Id }, newMantenimiento); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]  Mantenimiento mantenimiento)
        {
            if (id != mantenimiento.Id)
                return BadRequest("El id no coincide.");

            var updated = await _mantenimientoRepository.Update(mantenimiento);
            if(!updated)
                return NotFound();
            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _mantenimientoRepository.Delete(id);
            if(!deleted)
                return NotFound();

            return NoContent();
        }


    }
}
