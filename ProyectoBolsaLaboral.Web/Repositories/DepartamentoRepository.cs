using Newtonsoft.Json;
using ProyectoBolsaLaboral.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProyectoBolsaLaboral.Web.Repositories
{
    public class DepartamentoRepository
    {
        public static async Task<IEnumerable<Departamento>> ListadoAsincrono()
        {

            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync("http://localhost:19112/api/Departamento/GetDepartamento");
            string apiResponse = await response.Content.ReadAsStringAsync();

            var departamentos = JsonConvert.DeserializeObject<IEnumerable<Departamento>>(apiResponse);


            return departamentos;
        }
    }
}
