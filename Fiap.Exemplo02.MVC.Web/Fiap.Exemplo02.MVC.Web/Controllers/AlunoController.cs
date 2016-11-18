using Fiap.Exemplo02.MVC.Web.Models;
using Fiap.Exemplo02.MVC.Web.UnitsOfWork;
using Fiap.Exemplo02.MVC.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exemplo02.MVC.Web.Controllers
{
    public class AlunoController : Controller
    {
        #region FIELD
        private UnitOfWork _unit = new UnitOfWork();
        #endregion

        #region GET
        // GET: Aluno
        [HttpGet]
        public ActionResult Cadastrar(string msg)
        {
            var viewModel = new AlunoViewModel()
            {
                ListaGrupo = ListarGrupos(),
                Mensagem = msg,
               // TipoMensagem = tipoMsg
                
                
            };

            return View(viewModel);
        }

        private SelectList ListarGrupos()
        {

            return new SelectList(_unit.GrupoRepository.Listar(), "Id", "Nome");
        }

        [HttpGet]
        public ActionResult Listar()
        {


            //include -> busca o relacionamento (preenche o grupo que o aluno possui), faz o join
            // IList<Aluno> _lista = new PortalContext().Aluno.Include("Grupo").ToList();

            // IList<Aluno> _lista = _unit.AlunoRepository.Listar();

            CarregarComboGrupos();
            return View(_unit.AlunoRepository.Listar());
        }

        [HttpGet]
        //(int id) para receber o id do view
        public ActionResult Editar(int id)
        {
            //buscar o objeto (aluno) no banco
            // var context = new PortalContext();
            // var aluno = context.Aluno.Find(id);
            //manda o aluno para a view
            return View(_unit.AlunoRepository.BuscarPorId(id));
        }

        [HttpGet]
        public ActionResult Buscar(String nomeBusca, int? idGrupo) //paramatro nao obrigatorio ?
        {
            //var context = new PortalContext();
            //var a = context.Aluno.Where(aa => aa.Nome.Contains(nomeBusca)).ToList();
            ICollection<Aluno> l;
            if (idGrupo == null)
            {
                l = _unit.AlunoRepository.BuscarPor(aa => aa.Nome.Contains(nomeBusca));
            }
            else
            {
                l = _unit.AlunoRepository.BuscarPor(aa => aa.Nome.Contains(nomeBusca) && aa.GrupoId == idGrupo);
            }

            CarregarComboGrupos();
            return View("Listar", l);
        }
        #endregion

        #region POST

        [HttpPost]
        public ActionResult Cadastrar(AlunoViewModel alunoViewModel)
        {

            var aluno = new Aluno()
            {
                Nome = alunoViewModel.Nome,
                DataNascimento = alunoViewModel.DataNascimento,
                Bolsa = alunoViewModel.Bolsa,
                Desconto = alunoViewModel.Desconto,
                GrupoId = alunoViewModel.GrupoId                
            };

            //var viewModel = new AlunoViewModel()
            //{
            //    TipoMensagem = "alert alert-success",
            //    Mensagem = "Cadastrado com sucesso!",
            //    ListaGrupo = ListarGrupos()
            //};

            _unit.AlunoRepository.Cadastrar(aluno);
            _unit.Save();

            return RedirectToAction("Cadastrar", new { msg = "Aluno Cadastrado" });
        }

        [HttpPost]
        public ActionResult Excluir(int id)
        {
            //var context = new PortalContext();
            //Aluno a = context.Aluno.Find(int.Parse(id));
            //context.Aluno.Remove(a);
            _unit.AlunoRepository.Remover(id);
            _unit.Save();
            TempData["tipoMensagem"] = "alert alert-success";
            TempData["mensagem"] = "Aluno exterminado!";
            return RedirectToAction("Listar");
        }

        [HttpPost]
        public ActionResult Editar(Aluno aluno)
        {
            /*
            context.Entry(aluno).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            */

            _unit.AlunoRepository.Alterar(aluno);

            //var context = new PortalContext();
            //var a = context.Aluno.Find(aluno.Id);
            //a.Nome = aluno.Nome;
            //a.DataNascimento = aluno.DataNascimento;
            //a.Bolsa = aluno.Bolsa;
            //a.Desconto = aluno.Desconto;
            _unit.Save();

            TempData["tipoMensagem"] = "alert alert-success";
            TempData["mensagem"] = "Aluno atualizado";
            return RedirectToAction("Listar");
        }

        #endregion

        #region PRIVATE

        private void CarregarComboGrupos()
        {
            //enviar para a tela os grupos para o "select"
            ViewBag.grupos = new SelectList(_unit.GrupoRepository.Listar(), "Id", "Nome");
        }
        #endregion

        #region DISPOSE
        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
        #endregion

    }
}