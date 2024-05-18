using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace comsumoapi
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient;

        public Form1()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var data = await GetCursosAsync();
            dataGridView1.DataSource = data;
        }

        private async Task<List<Curso>> GetCursosAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:5042/api/Cursos");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<List<Curso>>();
        }
    }

   
}
