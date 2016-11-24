using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnderecoAjax.Ex01.MVC.Web.Controllers
{
    public class EnderecoController : Controller
    {
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }
    }
}