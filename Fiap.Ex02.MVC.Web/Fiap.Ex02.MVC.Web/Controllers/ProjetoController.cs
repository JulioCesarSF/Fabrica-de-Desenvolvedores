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
    public class ProjetoController : Controller
    {
        #region FIELDS
        private UnitOfWork _unit = new UnitOfWork();
        #endregion

        #region GETS

        [HttpGet]
        public ActionResult Cadastrar(string mensagem, string tipoMensagem)
        {
            var viewModel = new ProjetoViewModel()
            {
                Mensagem = mensagem,
                TipoMensagem = tipoMensagem,
                DataInicio = DateTime.Now,                
                Grupos = ListarGrupos()
            };
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Listar(ProjetoViewModel projetoViewModel)
        {
            var viewModel = new ProjetoViewModel()
            {
                ListaProjeto = _unit.ProjetoRepository.Listar()
            };
            return View(viewModel);
        }

        #endregion

        #region POSTS

        [HttpPost]
        public ActionResult Cadastrar(ProjetoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var projeto = new Projeto()
                {
                    Id = viewModel.GrupoId,
                    Nome = viewModel.Nome,
                    Descricao = viewModel.Descricao,
                    DataInicio = viewModel.DataInicio,
                    DataTermino = (viewModel.DataTermino.ToString() == null) ? null : viewModel.DataTermino,
                    Grupo = _unit.GrupoRepository.BuscarPorId(viewModel.GrupoId)
                };

                _unit.ProjetoRepository.Cadastrar(projeto);
                _unit.Save();

                return RedirectToAction("Cadastrar", 
                    new { mensagem = "Cadastro Realizado!", tipoMensagem = "alert alert-success" });
            }else
            {
                viewModel.Grupos = ListarGrupos();
                return View(viewModel);
            }           
        }

        #endregion

        #region PRIVATE

        public SelectList ListarGrupos()
        {
            return new SelectList(_unit.GrupoRepository.Listar(), "Id", "Nome");
        }
        #endregion
    }
}