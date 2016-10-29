using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exemplo01.MVC.Web.Controllers
{
    //chama o Home/Index da pasta Views
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //devolve uma tela, que esta dentro da pasta do controller com o mesmo nome do método
            return View();
        }

        
    }
}