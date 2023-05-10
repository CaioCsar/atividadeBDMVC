using atividadeBDMVC.Data;
using atividadeBDMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        // GET: DisciplinaController/Create
        public IActionResult Create()
        {
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DisciplinaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DisciplinaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DisciplinaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
