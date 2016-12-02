using Fiap.Exemplo03.UI.Console.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo03.UI.Console.Repositories
{
    public class ProfessorRepository
    {
        public Uri Cadastrar(ProfessorDTO professor)
        {
            using (var prof = new HttpClient())
            {
                prof.BaseAddress = new Uri("http://localhost:59253/");
                HttpResponseMessage response = prof.PostAsJsonAsync("api/professor", professor).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Headers.Location;
                }
                else
                {
                    return null;
                }
            }
        }

        public IEnumerable<ProfessorDTO> Listar()
        {
            using (var prof = new HttpClient())
            {
                prof.BaseAddress = new Uri("http://localhost:59253/");
                prof.DefaultRequestHeaders.Accept.Clear();
                prof.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json")
                    );

                HttpResponseMessage response = prof.GetAsync("api/professor").Result;

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<IEnumerable<ProfessorDTO>>().Result;
                }
                else
                {
                    return null;
                }
            }


        }

    }
}
