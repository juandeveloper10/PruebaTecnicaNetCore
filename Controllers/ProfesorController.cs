using EscuelaMusica.Entidades;
using EscuelaMusica.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EscuelaMusica.Controllers
{
    public class ProfesorController(IProfesor _repository) : Controller
    {

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Profesor profesor)
        {
            await _repository.InsertProfesor(profesor);
            return CreatedAtAction(nameof(GetById), new { id = profesor.Profesor_Id }, profesor);
        }
        [HttpGet]
        public async Task<IEnumerable<Profesor>> GetAll()
        {
            return (IEnumerable<Profesor>)await _repository.GetProfesor();

        }
        [HttpGet("{id: int}")]
        public async Task<Profesor> GetById(int id)
        {
            return await _repository.GetProfesorById(id);

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Profesor profesor)
        {
            await _repository.UpdateProfesor(profesor);
            return NoContent();

        }

        [HttpPut("{id: int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteProfesor(id);
            return NoContent();

        }



    }
}
