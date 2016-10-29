using Fiap.Aula01.UI.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Aula01.UI.Model
{
    public class PessoaFisica : Pessoa, IContribuinte
    {
        //prop -> tab tab
        public string Cpf { get; set; }

        public decimal Renda { get; set; }

        public PessoaFisica(string nome):base(nome)
        {

        }

        public override void Comprar(string item)
        {
            Console.WriteLine("PF Comprando: " + item);
        }

        public decimal CalcularImposto()
        {
            //Validação para Lançar exceção (exception)
            if(Renda == 0)
            {
                throw new RendaInvalidaException("Renda não pode ser 0");
            }

            return 0.27m*Renda;
        }
    }
}
