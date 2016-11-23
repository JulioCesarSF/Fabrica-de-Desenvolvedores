using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Nome do Grupo")]
        [Required]
        [StringLength(150)]
        public string Nome { get; set; }
        [Display(Name = "Nota do Grupo")]
        public float Nota { get; set; }
        #endregion
    }
}