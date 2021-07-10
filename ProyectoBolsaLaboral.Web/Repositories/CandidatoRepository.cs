using Newtonsoft.Json;
using ProyectoBolsaLaboral.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBolsaLaboral.Web.Repositories
{
    public class CandidatoRepository
    {
        public static async Task<IEnumerable<Postulante>> ListadoAsincrono()
        {
            //using var data = new SalesContext();
            //var postulantes = await data.Postulante.ToListAsync();

            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync("http://localhost:19112/api/Postulante/GetPostulante");
            string apiResponse = await response.Content.ReadAsStringAsync();
            var postulantes = JsonConvert.DeserializeObject<IEnumerable<Postulante>>(apiResponse);


            return postulantes;
        }

        public static async Task<bool> Insertar(Postulante postulante)
        {
            bool exito = true;

            var json = JsonConvert.SerializeObject(postulante);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            using var response = await httpClient.PostAsync("http://localhost:19112/api/Postulante/PostPostulante", data);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var postulantes = JsonConvert.DeserializeObject<Postulante>(apiResponse);
            if (postulantes == null)
                exito = false;

            return exito;
        }
    }
}
