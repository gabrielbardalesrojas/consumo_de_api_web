using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using WorkerService.Models;

namespace WorkerService.Services
{
    public class CursoService
    {
        private readonly HttpClient _httpClient;

        public CursoService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Curso>> GetCursosAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:5042/api/Cursos");
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Curso>>(responseData);
        }
    }
}
