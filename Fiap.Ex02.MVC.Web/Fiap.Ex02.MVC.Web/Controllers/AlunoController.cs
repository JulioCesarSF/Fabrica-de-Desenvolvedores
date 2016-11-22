using Fiap.Ex02.MVC.Web.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Ex02.MVC.Web.Controllers
{
    public class AlunoController : Controller
    {
        #region FIELDS
        private UnitOfWork _unit = new UnitOfWork();
        #endregion

        #region GETS

        public ActionResult Cadastrar(string mensagem, string tipoMensagem)
        {
            
            return View();
        }

        #endregion
    }
}