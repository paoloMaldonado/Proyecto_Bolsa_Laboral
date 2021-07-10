using Microsoft.AspNetCore.Mvc;
using ProyectoBolsaLaboral.Web.Models;
using ProyectoBolsaLaboral.Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBolsaLaboral.Web.Controllers
{
    public class EmpresaController : Controller
    {
        public IActionResult Index()
        {
            return PartialView();
        }
        public IActionResult RegistroEmpresa()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Grabar(string email, string password, string razonSocial, string ruc,
        string referenciaUbigeo, string descripcion, string website, string contactName, string telefono, string estado)
        {
            var empresa = new Empresa()
            {
                Email = email,
                Password = password,
                RazonSocial = razonSocial,
                Ruc = ruc,
                ReferenciaUbigeo = referenciaUbigeo,
                Descripcion = descripcion,
                Website = website,
                ContactName = contactName,
                Telefono = telefono,
                Estado = estado
            };

            bool exito;

            exito = await EmpresaRepository.Insertar(empresa);
            return Json(exito);
        }

        [HttpGet]
        public async Task<IActionResult> Validar(string email, string password)
        {
            bool response;
            response = await EmpresaRepository.ValidarCredenciales(email, password);
            return Json(response);
        }
    }
}
