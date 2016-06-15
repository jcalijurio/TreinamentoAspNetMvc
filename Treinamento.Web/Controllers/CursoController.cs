using System.Globalization;
using System.Threading.Tasks;
using System.Web.Mvc;
using Treinamento.Domain.Interfaces.Negocio;
using Treinamento.Web.Models;

namespace Treinamento.Web.Controllers
{
    public class CursoController : Controller
    {
        private ICursoNegocio _negocio;

        public CursoController(ICursoNegocio negocio)
        {
            _negocio = negocio;
        }

        // GET: Curso
        public async Task<ActionResult> Index()
        {
            var retorno = await _negocio.Listar();
            return View(retorno);
        }

        // GET: Curso/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var retorno = await _negocio.ObterPorId(id);
            return View(retorno);
        }

        // GET: Curso/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Curso/Create
        [HttpPost]
        public async Task<ActionResult> Create(CursoViewModel curso)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Error = "Tá inválida essa bagaça";
                    return View(curso);
                }

                await _negocio.Incluir(curso);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Curso/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");

            var curso = (await _negocio.ObterPorId(id)).ToViewModel<CursoViewModel>();
            return View(curso);
        }

        // POST: Curso/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, CursoViewModel curso)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Error = "Dados inválidos";
                    return View(curso);
                }

                await _negocio.Editar(curso);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Curso/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var retorno = await _negocio.ObterPorId(id);
            return View(retorno);
        }

        // POST: Curso/Delete/5
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
