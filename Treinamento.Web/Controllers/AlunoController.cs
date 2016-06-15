using System.Threading.Tasks;
using System.Web.Mvc;
using Treinamento.Domain.Interfaces.Negocio;
using Treinamento.Web.Models;
using System.Linq;

namespace Treinamento.Web.Controllers
{
    public class AlunoController : Controller
    {
        private IAlunoNegocio _negocio;

        public AlunoController(IAlunoNegocio negocio)
        {
            _negocio = negocio;
        }

        // GET: Aluno
        public async Task<ActionResult> Index()
        {
            var retorno = (await _negocio.Listar()).Select(r => r.ToViewModel<AlunoViewModel>()).ToArray();
            return View(retorno);
        }

        // GET: Aluno/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var retorno = (await _negocio.ObterPorId(id)).ToViewModel<AlunoViewModel>();
            return View(retorno);
        }

        // GET: Aluno/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Convenios = await _negocio.ListarConvenios();
            return View();
        }

        // POST: Aluno/Create
        [HttpPost]
        public async Task<ActionResult> Create(AlunoViewModel aluno)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                await _negocio.Incluir(aluno);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Aluno/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var retorno = (await _negocio.ObterPorId(id)).ToViewModel<AlunoViewModel>();
            return View(retorno);
        }

        // POST: Aluno/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, AlunoViewModel aluno)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                await _negocio.Editar(aluno);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Aluno/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var retorno = (await _negocio.ObterPorId(id)).ToViewModel<AlunoViewModel>();
            return View(retorno);
        }

        // POST: Aluno/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                await _negocio.Excluir(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
