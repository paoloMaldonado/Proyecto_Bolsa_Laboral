using Microsoft.AspNetCore.Mvc;
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
    }
}
