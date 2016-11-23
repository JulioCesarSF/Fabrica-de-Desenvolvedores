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

        #region POSTS

        [HttpPost]
        public ActionResult Cadastrar(AlunoViewModel viewModel)
        {
            var aluno = new Aluno()
            {
                Nome = viewModel.Nome,
                DataNascimento = viewModel.DataNascimento,
                Bolsa = viewModel.Bolsa,
                Desconto = viewModel.Desconto,
                GrupoId = viewModel.GrupoId
            };

            _unit.AlunoRepository.Cadastrar(aluno);
            _unit.Save();
            return RedirectToAction("Cadastrar", 
                new { mensagem = "Cadastro realizado!", tipoMensagem = "alert alert-success" });
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