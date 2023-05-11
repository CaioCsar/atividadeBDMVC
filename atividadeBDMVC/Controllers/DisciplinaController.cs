using atividadeBDMVC.Data;
using atividadeBDMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace atividadeBDMVC.Controllers
{
    public class DisciplinaController : Controller
    {
        private readonly IESContext _context;

        public DisciplinaController(IESContext context)
        {
            this._context = context;
        }

        // GET: DisciplinaController
        public async Task<IActionResult> Index()
        {
            return View(await _context.Disciplinas.OrderBy(c => c.Nome).ToListAsync());

        }

        // GET: DisciplinaController/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var disciplina = await _context.Disciplinas.SingleOrDefaultAsync(d => d.DisciplinaID == id);
            if (disciplina == null)
            {
                return NotFound();
            }

            return View(disciplina);
        }

        // GET: DisciplinaController/Create
        public IActionResult Create()
        {
            // para que liste os Cursos em um dropdown list 
            var cursos = _context.Cursos.OrderBy(i => i.Nome).ToList();
            cursos.Insert(0, new Curso() { CursoID = 0, Nome = "Selecione o Curso" });
            ViewBag.cursos = cursos;
            return View();
        }

        // POST: DisciplinaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome")] Disciplina disciplina)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(disciplina);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(disciplina);

        }

        // GET: DisciplinaController/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var disciplina = await _context.Disciplinas.SingleOrDefaultAsync(d => d.DisciplinaID == id);
            if(disciplina == null)
            {
                return NotFound();
            }

            return View(disciplina);
        }

        // POST: DisciplinaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("DisciplinaID, Nome, CursoDisciplinaID")] Disciplina disciplina)
        {
            if (id != disciplina.DisciplinaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disciplina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisciplinaExists(disciplina.DisciplinaID))
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
            ViewBag.CursoDisciplinas = new SelectList(_context.CursoDisciplinas, "CursoDisciplina", "Nome",
                disciplina.CursoDisciplinas);
            return View(disciplina);
        }

        /* Para ilustrar problemas de concorrência, vamos a um exemplo trivial: imagine um usuário com desejo de reservar
uma passagem de um determinado voo. No momento em que ele acessa o site de reserva, existe um único assento
disponível. Ocorre, que neste mesmo momento, outros usuários estão visualizando a mesma situação, e todos
querem o último assento. Há então uma concorrência.
Todos confirmam o desejo pelo assento, mas há apenas uma vaga. Garantir que apenas essa vaga seja vendida é um
problema relacionado à concorrência. Em nosso exemplo, caso o EF retorne uma exceção desse tipo, é neste catch
que ela deverá ser trabalhada. Dentro do catch , existe a invocação ao método DepartamentoExists() , que está
implementado também no código a seguir. Esse método simplesmente verifica se há, na base de dados, algum objeto
com o ID do objeto recebido. */ 

        private bool DisciplinaExists (long? id)
        {
            return _context.Disciplinas.Any(e => e.DisciplinaID == id);
        }

        // GET: DisciplinaController/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var disciplina = await _context.Disciplinas.SingleOrDefaultAsync(d => d.DisciplinaID == id);
            if (disciplina == null)
            {
                return NotFound();
            }

            return View(disciplina);
        }

        // POST: DisciplinaController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var disciplina = await _context.Disciplinas.SingleOrDefaultAsync(m => m.DisciplinaID == id);
            _context.Disciplinas.Remove(disciplina);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
