using Fiap.Exemplo02.Dominio.Models;
using Fiap.Exemplo02.MVC.Web.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fiap.Exemplo02.Services.Controllers
{
    public class ProfessorController : ApiController
    {
        #region FIELDS

        private UnitOfWork _unit = new UnitOfWork();

        #endregion

        //GET api/professor
        public ICollection<Professor> Get()
        {
            return _unit.ProfessorRepository.Listar();
        }

        //GET api/professor/{id}
        public Professor Get(int id)
        {
            return _unit.ProfessorRepository.BuscarPorId(id);
        }
    }
}
