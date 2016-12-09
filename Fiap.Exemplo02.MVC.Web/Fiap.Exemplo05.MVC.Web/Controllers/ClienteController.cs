using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exemplo05.MVC.Web.Controllers
{
    [Authorize]//restrição de acesso para usuario logado
    public class ClienteController : Controller
    {
        [HttpGet]        
        public ActionResult Index()
        {
            return View();
        }
    }
}