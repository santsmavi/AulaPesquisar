using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AulaPesquisar.Controllers
{
    public class PessoasController : Controller
    {
        private readonly Contexto db;

        public PessoasController(Contexto _db)
        {
            db = _db;   
        }

        public IActionResult Index(string query, string itembusca)
        {
            if (string.IsNullOrEmpty(query))
            {
                return View(db.PESSOAS.ToList());
            }
            else
            {
                switch (itembusca)
                {
                    default:
                        return View(db.PESSOAS.Where(a => a.nome.Contains(query) || a.cpf.Contains(query) || a.rg.Contains(query) || a.idade.Contains(query)));

                    case "Idade":
                        return View(db.PESSOAS.Where(a => a.idade == query));
                    case "CPF":
                        return View(db.PESSOAS.Where(a => a.cpf == query));
                    case "RG":
                        return View(db.PESSOAS.Where(a => a.rg == query));
                    case "Nome":
                        return View(db.PESSOAS.Where(a => a.nome.Contains (query)));
                       
                }
            }
               
            
        }
    }
}
