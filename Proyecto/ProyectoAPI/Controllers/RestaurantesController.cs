using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoAPI.Controllers
{
    [Route("api/v1/XamarinCurso/[Controller]")]
    public class RestaurantesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
