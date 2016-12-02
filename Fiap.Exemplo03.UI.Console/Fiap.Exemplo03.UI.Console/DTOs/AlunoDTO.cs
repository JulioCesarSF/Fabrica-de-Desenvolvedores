using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo03.UI.Console.DTOs
{
    public  class AlunoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public System.DateTime DataNascimento { get; set; }
        public bool Bolsa { get; set; }
        public Nullable<double> Desconto { get; set; }
        public int GrupoId { get; set; }
    }
}
