using Fiap.Ex02.MVC.Web.Models;
using Fiap.Ex02.MVC.Web.UnitsOfWork;
using Fiap.Ex02.MVC.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Ex02.MVC.Web.Controllers
{
    public class GrupoController : Controller
    {
        #region FIELDS
        private UnitOfWork _unit = new UnitOfWork();
        #endregion

        #region GETS
        [HttpGet]
        public ActionResult Cadastrar(string mensagem, string tipoMensagem)
        {
            var viewModel = new GrupoViewModel()
            {
                Mensagem = mensagem,
                TipoMensagem = tipoMensagem            
            };

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Listar()
        {
            var viewModel = new GrupoViewModel()
            {
                Grupos = ListarGrupos()
            };
            return View(viewModel);
        }

        private ICollection<Grupo> ListarGrupos()
        {
            return _unit.GrupoRepository.Listar();
        }

        [HttpGet]
        public ActionResult BuscarNome(string nome)
        {
            var grupo = _unit.GrupoRepository.BuscarPor(g => g.Nome == nome);
            return Json(new { ok = grupo.Any() }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region POSTS
        [HttpPost]
        public ActionResult Cadastrar(GrupoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var grupo = new Grupo()
                {
                    Nome = viewModel.Nome,
                    Nota = viewModel.Nota
                };
                _unit.GrupoRepository.Cadastrar(grupo);
                _unit.Save();
                return RedirectToAction("Cadastrar",
                    new { mensagem = "Cadastro Realizado!", tipoMensagem = "alert alert-success" });
            }else
            {
                return View(viewModel);
            }
            
        }
        #endregion
    }
}