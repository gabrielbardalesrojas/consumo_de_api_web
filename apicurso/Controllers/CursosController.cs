using apicurso.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace apicurso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private static List<Curso> cursos = new List<Curso>
        {
            new Curso { Id = 1, Nombre = "Matemáticas", Profesor = "Profesor A", Ciclo = "2024-1" },
            new Curso { Id = 2, Nombre = "Historia", Profesor = "Profesor B", Ciclo = "2024-2" },
            new Curso { Id = 3, Nombre = "Ciencias", Profesor = "Profesor C", Ciclo = "2024-1" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Curso>> Get()
        {
            return Ok(cursos);
        }

        [HttpGet("{id}")]
        public ActionResult<Curso> GetById(int id)
        {
            var curso = cursos.Find(c => c.Id == id);
            if (curso == null)
            {
                return NotFound();
            }
            return Ok(curso);
        }

        [HttpPost]
        public ActionResult<Curso> Create(Curso curso)
        {
            curso.Id = cursos.Count + 1;
            cursos.Add(curso);
            return CreatedAtAction(nameof(GetById), new { id = curso.Id }, curso);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Curso curso)
        {
            var existingCurso = cursos.Find(c => c.Id == id);
            if (existingCurso == null)
            {
                return NotFound();
            }

            existingCurso.Nombre = curso.Nombre;
            existingCurso.Profesor = curso.Profesor;
            existingCurso.Ciclo = curso.Ciclo;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var curso = cursos.Find(c => c.Id == id);
            if (curso == null)
            {
                return NotFound();
            }

            cursos.Remove(curso);
            return NoContent();
        }
    }
}
