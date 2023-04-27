using atividadeBDMVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace atividadeBDMVC.Controllers
{
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

        public async Task<ActionResult> Index()
        {
            return View(await _context.Departamentos.OrderBy(c => c.Nome).ToListAsync());
        }
    }
}
