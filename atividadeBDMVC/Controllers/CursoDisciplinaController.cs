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
    public class CursoDisciplinaController : Controller
    {
        private readonly IESContext _context;

        public CursoDisciplinaController(IESContext context)
        {
            this._context = context;
        }

        //GET INDEX
        public async Task<IActionResult> Index()
        {
            return View(await _context.CursoDisciplinas.Include(i => i.Curso).OrderBy(c => c.CursoID).ToListAsync());
        }

        // GET: CursoController/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var curso = await _context.Cursos.SingleOrDefaultAsync(m => m.CursoID == id);
            _context.Departamentos.Where(i => curso.DepartamentoID == i.DepartamentoID).Load();
            if (curso == null)
            {
                return NotFound();
            }
            return View(curso);
        }

        // GET: CursoController/Create
        public async Task<ActionResult> Create()
        {
            var departamento = _context.Departamentos.OrderBy(i => i.Nome).ToList();
            var disciplina = _context.Disciplinas.OrderBy(i => i.Nome).ToList();
            departamento.Insert(0, new Departamento() { DepartamentoID = 0, Nome = "Selecione o Departamento" });
            ViewBag.Departamentos = departamento;
            disciplina.Insert(0, new Disciplina() { DisciplinaID = 0, Nome = "Selecione a Disciplina" });
            ViewBag.disciplina = disciplina;
            return View();
        }

        // POST: CursoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Nome", "Turno", "NumeroAlunos", "DepartamentoID")] Curso curso)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(curso);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Nào foi possivel inserir os dados solicitados");
            }
            return View(curso);
        }

        // GET: CursoController/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var curso = await _context.Cursos.SingleOrDefaultAsync(m => m.CursoID == id);
            if (curso == null)
            {
                return NotFound();
            }
            ViewBag.Departamentos = new SelectList(_context.Departamentos.OrderBy(b => b.Nome), "DepartamentoID", "Nome", curso.DepartamentoID);
            return View(curso);
        }

        // POST: CursoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(long? id, [Bind("Nome", "Turno", "NumeroAlunos", "DepartamentoID")] Curso curso)
        {
            if (id != curso.CursoID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoExists(curso.CursoID))
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
            ViewBag.Departamentos = new SelectList(_context.Departamentos.OrderBy(b => b.Nome), "DepartamentoID", "Nome", curso.DepartamentoID);
            return View(curso);
        }

        private bool CursoExists(long? id)
        {
            return _context.Cursos.Any(e => e.CursoID == id);
        }

        // GET: CursoController/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var curso = await _context.Cursos.SingleOrDefaultAsync(m => m.CursoID == id);
            if (curso == null)
            {
                return NotFound();
            }
            return View(curso);
        }

        //POST: CursoController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var curso = await _context.Cursos.SingleOrDefaultAsync(m => m.CursoID == id);
            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
