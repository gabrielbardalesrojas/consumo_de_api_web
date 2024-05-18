using appweb.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace appweb.Controllers
{

    public class CursosController : Controller
    {
        private readonly CursoService _cursoService;

        public CursosController()
        {
            _cursoService = new CursoService();
        }

        public async Task<IActionResult> Index()
        {
            var cursos = await _cursoService.GetCursosAsync();
            return View(cursos);
        }
    }
}
