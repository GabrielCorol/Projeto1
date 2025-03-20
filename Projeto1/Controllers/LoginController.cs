using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Projeto1.Repositorio;

namespace Projeto1.Controllers
{
    public class LoginController : Controller
    {
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
            ModelState.AddModelError("", "Email ou senha invalidos.";
            return View();

            }
        }   

 }

