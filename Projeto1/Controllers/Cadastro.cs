using Microsoft.AspNetCore.Mvc;
using Projeto1.Models;

namespace Projeto1.Controllers
{
    public class Cadastro : Controller
    {
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
                return RedirectToAction("Logn");
            }
            return View(usuario);
        }
    }
}
