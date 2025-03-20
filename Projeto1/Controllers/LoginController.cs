using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Projeto1.Models;
using Projeto1.Repositorio;

namespace Projeto1.Controllers
{
    public class LoginController : Controller
    {
        //Criando Construtor
        private readonly UsuarioRepositorio _usuasioRepositorio;
        public LoginController(UsuarioRepositorio usuarioRepositorio)
        {
            _usuasioRepositorio = usuarioRepositorio;
        }
       
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            var usuario = _usuarioRepositoirio.ObterUsuario(email);
            if (usuario != null && usuario.Senha == senha)
            {
                //Autenticação Bem-Sucedida
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Email ou senha invalidos.");
            return View();

        }
        public IActionResult Cadastro()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Cadastro(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioRepositorio.AdicionarUsuario(usuario);
                return RedirectToAction("Login");
            }
            return View(usuario);

        }
    }   

}

