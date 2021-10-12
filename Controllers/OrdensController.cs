using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Oficina.Data;
using Oficina.Models;

namespace Oficina.Controllers
{
    public class OrdensController : Controller
    {
        private readonly Context _context;

        public OrdensController(Context context)
        {
            _context = context;
        }

        // GET: Ordens
        public async Task<IActionResult> Index()
        {
            var context = _context.Ordem.Include(o => o.Cliente).Include(o => o.Funcionario);
            ViewBag.FuncionarioNome = HttpContext.Session.GetString("UserName");
            return View(await context.ToListAsync());
        }

        // GET: Ordens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordem = await _context.Ordem
                .Include(o => o.Cliente)
                .Include(o => o.Funcionario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordem == null)
            {
                return NotFound();
            }

            ViewBag.FuncionarioNome = HttpContext.Session.GetString("UserName");

            return View(ordem);
        }

        // GET: Ordens/Create
        public IActionResult Create()
        {
            ViewData["Clientes"] = new SelectList(_context.Cliente, "Id", "Nome");
            ViewData["Funcionarios"] = new SelectList(_context.Funcionario, "Id", "Nome");
            ViewBag.FuncionarioNome = HttpContext.Session.GetString("UserName");
            return View();
        }

        // POST: Ordens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,FuncionarioId,DescricaoDefeito,DescricaoSolucao,Placa,DataRegistro,DataPrazo,PrecoTotal")] Ordem ordem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Clientes"] = new SelectList(_context.Cliente, "Id", "Nome", ordem.ClienteId);
            ViewData["Funcionarios"] = new SelectList(_context.Funcionario, "Id", "Nome", ordem.FuncionarioId);
            ViewBag.FuncionarioNome = HttpContext.Session.GetString("UserName");
            return View(ordem);
        }

        // GET: Ordens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordem = await _context.Ordem.FindAsync(id);
            if (ordem == null)
            {
                return NotFound();
            }
            ViewData["Clientes"] = new SelectList(_context.Cliente, "Id", "Nome", ordem.ClienteId);
            ViewData["Funcionarios"] = new SelectList(_context.Funcionario, "Id", "Nome", ordem.FuncionarioId);
            ViewBag.FuncionarioNome = HttpContext.Session.GetString("UserName");
            return View(ordem);
        }

        // POST: Ordens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,FuncionarioId,DescricaoDefeito,DescricaoSolucao,Placa,DataRegistro,DataPrazo,PrecoTotal")] Ordem ordem)
        {
            if (id != ordem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdemExists(ordem.Id))
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
            ViewData["Clientes"] = new SelectList(_context.Cliente, "Id", "Nome", ordem.ClienteId);
            ViewData["Funcionarios"] = new SelectList(_context.Funcionario, "Id", "Nome", ordem.FuncionarioId);
            ViewBag.FuncionarioNome = HttpContext.Session.GetString("UserName");
            return View(ordem);
        }

        // GET: Ordens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordem = await _context.Ordem
                .Include(o => o.Cliente)
                .Include(o => o.Funcionario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordem == null)
            {
                return NotFound();
            }

            ViewBag.FuncionarioNome = HttpContext.Session.GetString("UserName");

            return View(ordem);
        }

        // POST: Ordens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordem = await _context.Ordem.FindAsync(id);
            _context.Ordem.Remove(ordem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdemExists(int id)
        {
            return _context.Ordem.Any(e => e.Id == id);
        }
    }
}
