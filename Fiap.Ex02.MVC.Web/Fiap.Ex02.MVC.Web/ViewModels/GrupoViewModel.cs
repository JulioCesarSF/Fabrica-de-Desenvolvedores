using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fiap.Ex02.MVC.Web.ViewModels
{
    public class GrupoViewModel
    {
        public string Mensagem { get; set; }
        public string TipoMensagem { get; set; }
        #region FIELDS
        public int Id { get; set; }
        public string Nome { get; set; }
        public float Nota { get; set; }
        #endregion
    }
}