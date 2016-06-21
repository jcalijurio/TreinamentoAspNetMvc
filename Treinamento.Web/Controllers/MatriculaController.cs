using System.Threading.Tasks;
using System.Web.Mvc;
using Treinamento.Domain.Interfaces.Negocio;
using Treinamento.Domain.Interfaces.Repositorio;
using Treinamento.Web.Models;

namespace Treinamento.Web.Controllers
{
    public class MatriculaController : Controller
    {
        private IMatriculaNegocio _negocio;
        private ICursoRepository _cursoRepository;
        private IAlunoRepository _alunoRepository;
        public MatriculaController(IMatriculaNegocio negocio, ICursoRepository cursoRepository, IAlunoRepository alunoRepository)
        {
            _negocio = negocio;
            _cursoRepository = cursoRepository;
            _alunoRepository = alunoRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Listar()
        {
            var retorno = await _negocio.Listar();
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> ListarCursos()
        {
            var retorno = await _cursoRepository.Listar();
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> ListarAlunos()
        {
            var retorno = await _alunoRepository.Listar();
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> ListarTurmas(int cursoId)
        {
            var retorno = await _cursoRepository.ListarTurmas(cursoId);
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        // GET: Matricula/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Create(MatriculaViewModel matricula)
        {
            try
            {
                await _negocio.Incluir(matricula);

                return Json(new { Sucesso = true });
            }
            catch
            {
                return Json(new { Sucesso = false });
            }
        }


        [HttpPost]
        public async Task<ActionResult> Edit(MatriculaViewModel matricula)
        {
            try
            {
                await _negocio.Editar(matricula);

                return Json(new { Sucesso = true });
            }
            catch
            {
                return Json(new { Sucesso = false });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            await _negocio.Excluir(id);
            return Json(new { Sucesso = true });
        }
    }
}
