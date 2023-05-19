using atividadeBDMVC.Data;
using atividadeBDMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace atividadeBDMVC.Controllers
{
    public class AcademicoController : Controller
    {
        private readonly IESContext _context;

        public AcademicoController (IESContext context)
        {
            this._context = context;
        }

        /* GET: AcademicoController
        public ActionResult Index()
        {
            return View();
        }*/

        public async Task<IActionResult> Index()
        {
            return View(await _context.Academicos.OrderBy(c => c.Nome).ToListAsync());
        }

        // GET: InstituicaoController/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var academico = await _context.Academicos.SingleOrDefaultAsync(m => m.AcademicoID == id);
            if (academico == null)
            {
                return NotFound();
            }
            return View(academico);
        }

        // GET: InstituicaoController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InstituicaoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome")] Academico academico, IFormFile img)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //parte inserida para implementar a foto
                    var stream = new MemoryStream();
                    await img.CopyToAsync(stream);
                    academico.img = stream.ToArray();
                    academico.imgType = img.ContentType;

                    if (academico.AcademicoID == null)
                    {
                        _context.Academicos.Add(academico);
                    }
                    else
                    {
                        _context.Update(academico);
                    }
                    await _context.SaveChangesAsync();


                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(academico);
        }

        // GET: InstituicaoController/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var academico = await _context.Academicos.SingleOrDefaultAsync(m => m.AcademicoID == id);
            if (academico == null)
            {
                return NotFound();
            }
            return View(academico);
        }

        // POST: InstituicaoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("AcademicoID,Nome")] Academico
        academico, IFormFile foto)
        {
            if (id != academico.AcademicoID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    //parte inserida para implementar a foto
                    var stream = new MemoryStream();
                    await foto.CopyToAsync(stream);
                    academico.img = stream.ToArray();
                    academico.imgType = foto.ContentType;

                    if (academico.AcademicoID == null)
                    {
                        _context.Academicos.Add(academico);
                    }
                    else
                    {
                        _context.Update(academico);
                    }
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await AcademicoExists(academico.AcademicoID))
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
            return View(academico);
        }

        private async Task<bool> AcademicoExists(long? id)
        {
            return await _context.Academicos.FindAsync(id) !=null;
        }

        // GET: InstituicaoController/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var academico = await _context.Academicos.SingleOrDefaultAsync(m => m.AcademicoID == id);
            if (academico == null)
            {
                return NotFound();
            }
            return View(academico);
        }

        // POST: InstituicaoController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var academico = await _context.Academicos.FindAsync(id);
            _context.Academicos.Remove(academico);
            await _context.SaveChangesAsync();
            TempData["Message"] = "O Academico" + academico.Nome + "Foi removido com sucesso!";
            return RedirectToAction(nameof(Index));
        }
    }
}
