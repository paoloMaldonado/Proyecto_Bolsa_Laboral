using Newtonsoft.Json;
using ProyectoBolsaLaboral.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProyectoBolsaLaboral.Web.Repositories
{
    public class ProvinciaRepository
    {
        public static async Task<IEnumerable<Provincia>> ObtenerProvincia(int id)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient
                .GetAsync("http://localhost:19112/api/Provincia/GetProvinciaByDepId/" + id);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var provincias = JsonConvert.DeserializeObject<IEnumerable<Provincia>>(apiResponse);

            //using var data = new SalesContext();
            //var customers = await data.Customer.Where(x => x.Id == id).FirstOrDefaultAsync();
            return provincias;
        }
    }
}
