using Fiap.Exercicio03.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exercicio03.MVC.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private ProdutoContext pContext = new ProdutoContext();
        // GET: Produto
        public ActionResult Index()
        {
            return View();
        }
    }
}