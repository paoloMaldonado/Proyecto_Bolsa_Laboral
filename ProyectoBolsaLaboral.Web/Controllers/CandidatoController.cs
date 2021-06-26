using Microsoft.AspNetCore.Mvc;
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
    }
}
