using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exemplo02.MVC.Web.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        public ActionResult Default()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Erro404()
        {
            return View();
        }
    }
}