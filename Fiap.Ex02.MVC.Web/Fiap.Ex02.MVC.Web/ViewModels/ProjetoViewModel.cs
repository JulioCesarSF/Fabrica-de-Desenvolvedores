using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Ex02.MVC.Web.ViewModels
{
    public class ProjetoViewModel
    {

        public SelectList Grupos { get; set; }

        #region FIELDS

        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public int GrupoId { get; set; }

        #endregion
    }
}