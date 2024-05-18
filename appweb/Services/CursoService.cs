using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using appweb.Models;
using Newtonsoft.Json;

namespace appweb.Services
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