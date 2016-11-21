using Fiap.Exemplo02.MVC.Web.Models;
using Fiap.Exemplo02.MVC.Web.UnitsOfWork;
using Fiap.Exemplo02.MVC.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public ActionResult Cadastrar(string msg, string tipoMsg)
        {
            var viewModel = new AlunoViewModel()
            {
                ListaGrupo = ListarGrupos(),
                DataNascimento = DateTime.Today,
                Mensagem = msg,
                TipoMensagem = tipoMsg
            };

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Listar(AlunoViewModel vM)
        {
            //include -> busca o relacionamento (preenche o grupo que o aluno possui), faz o join
            // IList<Aluno> _lista = new PortalContext().Aluno.Include("Grupo").ToList();

            // IList<Aluno> _lista = _unit.AlunoRepository.Listar();

            var viewModel = new AlunoViewModel()
            {
                Alunos = CarregarAlunos(),
                ListaGrupo = ListarGrupos()

            };

            return View(viewModel);
        }

        [HttpGet]
        //(int id) para receber o id do view
        public ActionResult Editar(int id)
        {            
            var aluno = _unit.AlunoRepository.BuscarPorId(id);
            Debug.WriteLine("Nome do aluno {0}", aluno.Nome);
            var viewModel = new AlunoViewModel()
            {
                ListaGrupo = ListarGrupos(),
                Nome = aluno.Nome,
                Bolsa = aluno.Bolsa,
                DataNascimento = aluno.DataNascimento,
                Desconto = aluno.Desconto,
                Id = aluno.Id,
                GrupoId = aluno.GrupoId
            };
            //buscar o objeto (aluno) no banco
            // var context = new PortalContext();
            // var aluno = context.Aluno.Find(id);
            //manda o aluno para a view
            
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Buscar(String nomeBusca, int? idBusca) //paramatro nao obrigatorio ?
        {
            var context = new PortalContext();
            //var a = context.Aluno.Where(aa => aa.Nome.Contains(nomeBusca)).ToList();

            var lista = _unit.AlunoRepository.BuscarPor(aa => 
                        aa.Nome.Contains(nomeBusca) && (aa.GrupoId == idBusca || idBusca == null));

            var viewModel = new AlunoViewModel()
            {
                Alunos = lista,
                ListaGrupo = ListarGrupos()
            };

           // viewModel.Alunos = _unit.AlunoRepository.BuscarPor(aa => aa.Nome.Contains(nomeBusca));
            

            //ICollection<Aluno> l;
            //if (idGrupo == null)
            //{
            //    viewModel.Alunos = _unit.AlunoRepository.BuscarPor(aa => aa.Nome.Contains(nomeBusca));
            //}
            //else
            //{
            //    viewModel.Alunos = _unit.AlunoRepository.BuscarPor(aa => aa.Nome.Contains(nomeBusca) && aa.GrupoId == idGrupo);        
            //}

            //viewModel.ListaGrupo = ListarGrupos();
           
            return View("Listar", viewModel);
        }
        #endregion

        #region POST

        [HttpPost]
        public ActionResult Cadastrar(AlunoViewModel alunoViewModel)
        {
            if (ModelState.IsValid)
            {
                var aluno = new Aluno()
                {
                    Nome = alunoViewModel.Nome,
                    DataNascimento = alunoViewModel.DataNascimento,
                    Bolsa = alunoViewModel.Bolsa,
                    Desconto = alunoViewModel.Desconto,
                    GrupoId = alunoViewModel.GrupoId
                };

                _unit.AlunoRepository.Cadastrar(aluno);
                _unit.Save();

                return RedirectToAction("Cadastrar", new { msg = "Aluno Cadastrado", tipoMsg = "alert alert-success" });
            }
            else
            {
                alunoViewModel.ListaGrupo = ListarGrupos();
                return View(alunoViewModel);
            }

            //var viewModel = new AlunoViewModel()
            //{
            //    TipoMensagem = "alert alert-success",
            //    Mensagem = "Cadastrado com sucesso!",
            //    ListaGrupo = ListarGrupos()
            //};
        }

        [HttpPost]
        public ActionResult Excluir(int id)
        {
            //var aluno = _unit.AlunoRepository.BuscarPorId(id);
            _unit.AlunoRepository.Remover(id);
            _unit.Save();
            var viewModel = new AlunoViewModel()
            {
                ListaGrupo = ListarGrupos(),
                Alunos = CarregarAlunos(),
                Mensagem = "Aluno deletado com sucesso!",
                TipoMensagem = "alert alert-success"
            };
            //var context = new PortalContext();
            //Aluno a = context.Aluno.Find(int.Parse(id));
            //context.Aluno.Remove(a);
            //_unit.AlunoRepository.Remover(id);
            //_unit.Save();
            //TempData["tipoMensagem"] = "alert alert-success";
            //TempData["mensagem"] = "Aluno exterminado!";
            return View("Listar", viewModel);
        }

        [HttpPost]
        public ActionResult Editar(Aluno aluno)
        {
            //ADICIONAR O VIEWMODEL


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

        private ICollection<Aluno> CarregarAlunos()
        {
            return _unit.AlunoRepository.Listar();
        }

        private SelectList ListarGrupos()
        {

            return new SelectList(_unit.GrupoRepository.Listar(), "Id", "Nome");
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