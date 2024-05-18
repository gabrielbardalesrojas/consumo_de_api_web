using appweb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using appweb.Models;

namespace appweb.Pages.Cursos
{
    public class IndexModel : PageModel
    {
        private readonly CursoService _cursoService;

        public IndexModel()
        {
            _cursoService = new CursoService();
        }

        public List<Curso> Cursos { get; set; }

        public async Task OnGetAsync()
        {
            Cursos = await _cursoService.GetCursosAsync();
        }
    }
}
