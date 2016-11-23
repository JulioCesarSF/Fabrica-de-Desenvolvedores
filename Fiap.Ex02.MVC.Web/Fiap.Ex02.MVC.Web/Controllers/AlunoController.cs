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
        [HttpGet]
        public ActionResult Listar(AlunoViewModel viewModel)
        {
            var alunoViewModel = new AlunoViewModel()
            {
                ListaGrupo = ListarGrupos(),
                ListaAluno = ListarAluno()
            };
            return View(alunoViewModel);
        }
        [HttpGet]
        public ActionResult Buscar(string nomeBusca, int? idBusca)
        {
            var lista = _unit.AlunoRepository.BuscarPor(
                a=>a.Nome.Contains(nomeBusca) && (a.GrupoId == idBusca || idBusca == null));
            return PartialView("_tabela", lista);
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            var aluno = _unit.AlunoRepository.BuscarPorId(id);
            var viewModel = new AlunoViewModel()
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                DataNascimento = aluno.DataNascimento,
                Bolsa = aluno.Bolsa,
                Desconto = aluno.Desconto,
                GrupoId = aluno.GrupoId,
                ListaGrupo = ListarGrupos()
            };
            return View(viewModel);
        }
        #endregion

        #region POSTS
        //TODO: adicionar validações
        [HttpPost]
        public ActionResult Cadastrar(AlunoViewModel viewModel)
        {
            if (ModelState.IsValid)
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
            }else
            {
                viewModel.ListaGrupo = ListarGrupos();
                return View(viewModel);
            }
            
        }
        [HttpPost]
        public ActionResult Excluir(int id)
        {
            _unit.AlunoRepository.Remover(id);
            _unit.Save();
            var viewModel = new AlunoViewModel()
            {
                ListaGrupo = ListarGrupos(),
                ListaAluno = ListarAluno(),
                Mensagem = "Aluno excluído com sucesso!",
                TipoMensagem = "alert alert-success"                
            };
            return View("Listar", viewModel);
        }
        [HttpPost]
        public ActionResult Editar(Aluno aluno)
        {
            AlunoViewModel viewModel = null;
            try
            {
                _unit.AlunoRepository.Alterar(aluno);
                _unit.Save();
                viewModel = new AlunoViewModel()
                {
                    Mensagem = "Aluno atualizado!",
                    TipoMensagem = "alert alert-success",
                    ListaGrupo = ListarGrupos(),
                    ListaAluno = ListarAluno()
                };
                return View("Listar", viewModel);
            }
            catch (Exception e)
            {
                viewModel = new AlunoViewModel()
                {
                    Mensagem = e.GetType().ToString(),
                    TipoMensagem = "Erro ao atualizar",
                    Nome = aluno.Nome,
                    DataNascimento = aluno.DataNascimento,
                    Bolsa = aluno.Bolsa,
                    Desconto = aluno.Desconto,
                    GrupoId = aluno.GrupoId,
                    ListaGrupo = ListarGrupos()
                };
                return View(viewModel);
            }            
        }
        #endregion

        #region PRIVATE
        private SelectList ListarGrupos()
        {
            return new SelectList(_unit.GrupoRepository.Listar(), "Id", "Nome");
        }

        private ICollection<Aluno> ListarAluno()
        {
            return _unit.AlunoRepository.Listar();
        }
        #endregion
    }
}