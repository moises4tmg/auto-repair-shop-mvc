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

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/funcionario/login");
        }
    }
}