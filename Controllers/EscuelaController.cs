using EscuelaMusica.Entidades;
using EscuelaMusica.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EscuelaMusica.Controllers
{
    public class EscuelaController(IEscuela _repository) : Controller
    {

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Escuela escuela)
        {
            await _repository.InsertEscuela(escuela);
            return CreatedAtAction(nameof(GetById), new { id = escuela.Escuela_Id }, escuela);
        }
        [HttpGet]
        public async Task<IEnumerable<Escuela>> GetAll()
        {
            return await _repository.GetEscuela();

        }
        [HttpGet("{id: int}")]
        public async Task<Escuela> GetById(int id)
        {
            return await _repository.GetEscuelaById(id);

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Escuela escuela)
        {
            await _repository.UpdateEscuela(escuela);
            return NoContent();

        }

        [HttpPut("{id: int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteEscuela(id);
            return NoContent();

        }



    }


}
