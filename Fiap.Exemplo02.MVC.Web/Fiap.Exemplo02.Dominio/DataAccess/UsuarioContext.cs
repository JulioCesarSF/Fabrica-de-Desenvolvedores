using Fiap.Exemplo02.Dominio.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo02.Dominio.DataAccess
{
    //gerenciar os usuário no banco e na aplicação
    public class UsuarioContext : IdentityDbContext<Usuario>
    {

    }
}
