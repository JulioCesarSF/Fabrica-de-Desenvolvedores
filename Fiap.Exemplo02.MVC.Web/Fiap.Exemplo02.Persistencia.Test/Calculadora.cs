using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo02.Persistencia.Test
{
    public class Calculadora
    {
        public int Fatorial(int numero)
        {
            if (numero <= 1)
            {
                return 1;
            }                
            return numero * Fatorial(numero - 1);
        }
    }
}
