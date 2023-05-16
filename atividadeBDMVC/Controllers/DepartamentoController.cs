using atividadeBDMVC.Data;
using atividadeBDMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace atividadeBDMVC.Controllers
{
    [Authorize]
    public class DepartamentoController : Controller
    {
        /*public IActionResult Index()
        {
            return View();
        }*/

        private readonly IESContext _context;

        public DepartamentoController(IESContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            //insercao da classe instituicao do relacionamento, para que o objeto do departamento recuperado já traga os dados da instituição relacionada a ele
            return View(await _context.Departamentos.Include(i => i.Instituicao).OrderBy(c => c.Nome).ToListAsync());
        }

        // GET
        public IActionResult Create()
        {
            // para que liste as instituicoes em um dropdown list 
            var instituicoes = _context.Instituicoes.OrderBy(i => i.Nome).ToList();
            instituicoes.Insert(0, new Instituicao() { InstituicaoID = 0, Nome = "Selecione a Instituicao" });
            ViewBag.Instituicoes = instituicoes;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome", "Campus", "InstituicaoID")] Departamento departamento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(departamento);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(departamento);
        }

        //GET EDIT
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var departamento = await _context.Departamentos.SingleOrDefaultAsync(m => m.DepartamentoID == id);
            if (departamento == null)
            {
                return NotFound();
            }
            //insercao dos dados de instituicao no edit
            ViewBag.Instituicoes = new SelectList(_context.Instituicoes.OrderBy(b => b.Nome), "InstituicaoID", "Nome",
                departamento.InstituicaoID);
            return View(departamento);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("DepartamentoID, Nome, Campus, InstituicaoID")] Departamento departamento)
        {
            if (id != departamento.DepartamentoID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamentoExists(departamento.DepartamentoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Instituicoes = new SelectList(_context.Instituicoes.OrderBy(b => b.Nome), "InstituicaoId", "Nome",
                departamento.InstituicaoID);
            return View(departamento);
        }
        private bool DepartamentoExists(long? id)
        {
            return _context.Departamentos.Any(e => e.DepartamentoID == id);
        }


        //GET Details
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var departamento = await _context.Departamentos.SingleOrDefaultAsync(mbox => mbox.DepartamentoID == id);
            /*O código a seguir traz a action Details que renderiza essa visão. Vamos usar: o SingleOrDefaultAsync() , que retorna
o primeiro registro que satisfaça a condição; e o Load() , que carrega o objeto desejado no contexto, ou seja, a
instituição do departamento procurado.*/
            _context.Instituicoes.Where(i => departamento.InstituicaoID == i.InstituicaoID).Load();
            if (departamento == null)
            {
                return NotFound();
            }
            return View(departamento);
        }

        // GET DELETE
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var departamento = await _context.Departamentos.SingleOrDefaultAsync(mbox => mbox.DepartamentoID == id);
            if (departamento == null)
            {
                return NotFound();
            }
            return View(departamento);
        }

        // POST: Departamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var departamento = await _context.Departamentos.SingleOrDefaultAsync(m => m.DepartamentoID == id);
            _context.Departamentos.Remove(departamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }



}
