using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnderecoAjax.Ex01.MVC.Web.Models
{
    public class Endereco
    {
        public int Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }       
    }
}