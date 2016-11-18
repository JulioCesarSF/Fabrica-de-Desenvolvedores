using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo02.MVC.Web.ViewModels
{
    public class AlunoViewModel
    {
        #region Aluno Properties
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Nullable<double> Desconto { get; set; }
        public bool Bolsa { get; set; }
        public int GrupoId { get; set; }
        #endregion
    }
}
