using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fiap.Exemplo02.Persistencia.Test
{
    [TestClass]
    public class CalculadoraTest
    {
        [TestMethod]
        public void Calcular_Fatorial_Ok()
        {
            //Inicializar os objetos
            Calculadora calc = new Calculadora();
            //chamar o método que será testado
            var resultado = calc.Fatorial(5);
            //valida ro resultado obtido
            Assert.AreEqual(120, resultado);
        }

        [TestMethod]
        public void Calcular_Fatorial_Zero()
        {
            Calculadora calc = new Calculadora();
            var resultado = calc.Fatorial(0);
            Assert.AreEqual(1, resultado);
        }
    }


}
