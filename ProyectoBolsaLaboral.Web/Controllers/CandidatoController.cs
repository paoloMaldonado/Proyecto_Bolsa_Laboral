using Microsoft.AspNetCore.Mvc;
using ProyectoBolsaLaboral.Web.Models;
using ProyectoBolsaLaboral.Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBolsaLaboral.Web.Controllers
{
    public class CandidatoController : Controller
    {
        public IActionResult Index()
        {
            return PartialView();
        }


        public IActionResult Register()
        {
            return PartialView();
        }

        public async Task<IActionResult> ListadoDepartamentos()
        {
            var departamentos = await DepartamentoRepository.ListadoAsincrono();
            return PartialView(departamentos);
        }

        public async Task<IActionResult> ListadoProvincias(int idDepartamento)
        {
            var provincias = await ProvinciaRepository.ObtenerProvincia(idDepartamento);
            return PartialView(provincias);
        }

        [HttpPost]
        public async Task<IActionResult> Grabar(string nombre, string apellido, string email, string password,
                DateTime fechaNacimiento, string genero, string telefono, string zipCode, bool tieneEstudio, bool tieneExperiencia,
                string estado)
        {
            var postulante = new Postulante()
            {
                Nombre = nombre,
                Apellido = apellido,
                Email = email,
                Password = password,
                FechaNacimiento = fechaNacimiento,
                Genero = genero,
                Telefono = telefono,
                ZipCode = zipCode,
                TieneEstudio = tieneEstudio,
                TieneExperiencia = tieneExperiencia,
                Estado = estado

            };

            bool exito;

            exito = await CandidatoRepository.Insertar(postulante);
            return Json(exito);
        }

        [HttpGet]
        public async Task<IActionResult> Validar(string email, string password)
        {
            bool response;
            response = await CandidatoRepository.ValidarCredenciales(email, password);
            return Json(response);
        }
    }
}
