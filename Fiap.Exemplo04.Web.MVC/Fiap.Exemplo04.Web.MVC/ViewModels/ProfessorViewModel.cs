using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo04.Web.MVC.ViewModels
{
    public class ProfessorViewModel
    {
        #region FIELDs
        [StringLength(100)]
        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Salário")]
        public Decimal Salario { get; set; }

        public string Mensagem { get; set; }
        public string TipoMensagem { get; set; }
        #endregion
    }
}
