using Fiap.Ex02.MVC.Web.UnitsOfWork;
using Fiap.Ex02.MVC.Web.ViewModels;
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

        [HttpGet]
        public ActionResult Cadastrar(string mensagem, string tipoMensagem)
        {
            var viewModel = new AlunoViewModel()
            {
                DataNascimento = DateTime.Now,
                Mensagem = mensagem,
                TipoMensagem = tipoMensagem,
                ListaGrupo = ListarGrupos()
            };
            return View(viewModel);
        }

        #endregion

        #region PRIVATE
        private SelectList ListarGrupos()
        {
            return new SelectList(_unit.GrupoRepository.Listar(), "Id", "Nome");
        }
        #endregion
    }
}