using ListaCursos.Interfaces;
using ListaCursos.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ListaCursos.Providers
{
    public class WebApiCoursesProvider : ICoursesProvider
    {
        private readonly IHttpClientFactory httpClientFactory;

        public WebApiCoursesProvider(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public Task<(bool IsSuccess, int? Id)> AddSync(Course course)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Course>> GetAllAsync()
        {
            //coursesService es el nombre del idenficicador único que especificamos en Startup.cs
            var client = httpClientFactory.CreateClient("coursesService");

            var response = await client.GetAsync("api/courses");

            if(response.IsSuccessStatusCode)
            {
                //Obtenemos el Content de este respons como si fuera una Cadena
                var content = await response.Content.ReadAsStringAsync();

                //Vamos a deserializar los datos que están en JSon, esta api de JSon está incorporada
                //desde FW Core 3.0
                var results =  System.Text.Json.JsonSerializer.Deserialize<ICollection<Course>>(content, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return results;
            }
            return null;
        }

        public async Task<Course> GetAsync(int id)
        {
            //coursesService es el nombre del idenficicador único que especificamos en Startup.cs
            var client = httpClientFactory.CreateClient("coursesService");

            var response = await client.GetAsync($"api/courses/{id}");

            if (response.IsSuccessStatusCode)
            {
                //Obtenemos el Content de este respons como si fuera una Cadena
                var content = await response.Content.ReadAsStringAsync();

                //Vamos a deserializar los datos que están en JSon, esta api de JSon está incorporada
                //desde FW Core 3.0
                var result = System.Text.Json.JsonSerializer.Deserialize<Course>(content, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return result;
            }
            return null;
        }

        public async Task<ICollection<Course>> SearchAsync(string search)
        {
            //coursesService es el nombre del idenficicador único que especificamos en Startup.cs
            var client = httpClientFactory.CreateClient("coursesService");

            var response = await client.GetAsync($"api/courses/search/{search}");

            if (response.IsSuccessStatusCode)
            {
                //Obtenemos el Content de este respons como si fuera una Cadena
                var content = await response.Content.ReadAsStringAsync();

                //Vamos a deserializar los datos que están en JSon, esta api de JSon está incorporada
                //desde FW Core 3.0
                var results = System.Text.Json.JsonSerializer.Deserialize<ICollection<Course>>(content, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return results;
            }
            return null;
        }

        public async Task<bool> UpdateAsync(int id, Course coures)
        {
            //coursesService es el nombre del idenficicador único que especificamos en Startup.cs
            var client = httpClientFactory.CreateClient("coursesService");

            var body = new StringContent(System.Text.Json.JsonSerializer.Serialize(coures,typeof(Course), new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true }));


            var response = await client.PutAsync($"api/courses/{id}", body);

            if (response.IsSuccessStatusCode)
            {                
                return true;
            }
            return false;
        }
    }
}
