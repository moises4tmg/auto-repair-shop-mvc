using System;
using Oficina.Data;
using Oficina.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Oficina.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly Context _context;

        public FuncionarioController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var funcionario = _context.Funcionario.Where(x => x.Id.ToString().Equals(HttpContext.Session.GetString("UserID"))).FirstOrDefault();
            ViewBag.FuncionarioNome = funcionario.Nome;
            return View();
        }

        /*public async Task<IActionResult> Index()
        {
            return View(await _context.Funcionario.ToListAsync());
        }*/

        public IActionResult Login()
        {
            return View(new Auth());
        }

        [HttpPost]
        public IActionResult Login([Bind("Usuario,Senha")] Auth auth)
        {
            string error = null;
            var login = _context.Funcionario.Where(x => x.Usuario == auth.Usuario).FirstOrDefault();
            if(login != null)
            {
                if(!string.IsNullOrEmpty(auth.Senha)){
                    if(BCrypt.Net.BCrypt.Verify(auth.Senha,login.Senha))
                    {
                        HttpContext.Session.SetString("SessionStatus", "loggedIn");
                        HttpContext.Session.SetString("UserID", login.Id.ToString());
                        HttpContext.Session.SetString("UserName", login.Nome.ToString());
                        return RedirectToAction("Index", "Funcionario");
                    }
                    else
                    {
                        error = "Usuário e/ou senha incorretos";
                    }
                }
                else
                {
                    error = "Usuário e/ou senha incorretos";
                }
            }
            else
            {
                error = "Usuário e/ou senha incorretos";
            }
            return View(new Auth(){AuthResposta = error});
        }

        public async Task<IActionResult> List() // GET: Funcionario/List
        {
            ViewBag.FuncionarioNome = HttpContext.Session.GetString("UserName");
            return View(await _context.Funcionario.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.FuncionarioNome = HttpContext.Session.GetString("UserName");
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        public IActionResult Create() // GET: Funcionario/Create
        {
            ViewBag.FuncionarioNome = HttpContext.Session.GetString("UserName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Usuario,Senha,Administrador")] Funcionario funcionario) // POST: Funcionario/Create
        {
            if (ModelState.IsValid)
            {
                funcionario.Senha = BCrypt.Net.BCrypt.HashPassword(funcionario.Senha);

                _context.Add(funcionario);
                await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(List));
            }
            ViewBag.FuncionarioNome = HttpContext.Session.GetString("UserName");
            return View(funcionario);
        }

        public async Task<IActionResult> Delete(int? id) // GET: Funcionario/Delete
        {
            ViewBag.FuncionarioNome = HttpContext.Session.GetString("UserName");

            if(id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario
                .FirstOrDefaultAsync(m => m.Id == id);

            if(funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) // POST: Funcionario/Delete
        {
            var funcionario = await _context.Funcionario.FindAsync(id);
            _context.Funcionario.Remove(funcionario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id) // GET: Funcionario/Edit
        {
            ViewBag.FuncionarioNome = HttpContext.Session.GetString("UserName");
            
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario.FindAsync(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Nome, Usuario, Senha, Administrador")] Funcionario funcionario) // POST: Funcionario/Edit
        {
            ViewBag.FuncionarioNome = HttpContext.Session.GetString("UserName");
            if (id != funcionario.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    funcionario.Senha = BCrypt.Net.BCrypt.HashPassword(funcionario.Senha);
                    _context.Update(funcionario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionarioExists(funcionario.Id))
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
            return View(funcionario);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/funcionario/login");
        }

        private bool FuncionarioExists(int id)
        {
            return _context.Funcionario.Any(e => e.Id == id);
        }
    }
}