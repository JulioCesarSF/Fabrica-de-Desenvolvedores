using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo03.UI.Console.DTOs
{
    public class ProfessorDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Nullable<decimal> Salario { get; set; }
    }
}
