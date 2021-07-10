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
    public class EmpresaRepository
    {
        public static async Task<IEnumerable<Empresa>> ListadoAsincrono()
        {
            //using var data = new SalesContext();
            //var empresas = await data.Empresa.ToListAsync();

            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync("http://localhost:19112/api/Empresa/GetEmpresa");
            string apiResponse = await response.Content.ReadAsStringAsync();
            var empresas = JsonConvert.DeserializeObject<IEnumerable<Empresa>>(apiResponse);


            return empresas;
        }

        public static async Task<bool> Insertar(Empresa empresa)
        {
            bool exito = true;

            var json = JsonConvert.SerializeObject(empresa);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            using var response = await httpClient.PostAsync("http://localhost:19112/api/Empresa/PostEmpresa", data);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var empresas = JsonConvert.DeserializeObject<Empresa>(apiResponse);
            if (empresas == null)
                exito = false;

            return exito;
        }

        public static async Task<bool> ValidarCredenciales(string email, string password)
        {

            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync("http://localhost:19112/api/Empresa/GetEmpresaByCredentials/" + email + "/" + password);
            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }

    }
}
