using Microsoft.AspNetCore.Mvc;
using APP.Domain.Entities;
using APP.CadastroUsuario.Models;
using System.Text.Json;

namespace APP.CadastroUsuario.Controllers
{
    public class HomeController : Controller
    {
        private ConnectionApi _Request;

        public HomeController(ConnectionApi connectionApi)
        {
            this._Request = connectionApi;
        }
        public IActionResult Index()
        {
            try
            {
                List<Usuarios>? Lista = _Request.ListaDeUsuarios();

                return View(Lista);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);

            }
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Usuarios item)
        {
            try
            {
                var Insert = await _Request.PostAsync(item);
                Insert.EnsureSuccessStatusCode();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                
                item.Erro = ex.Message;
                return View("Create", item);
            }
        }
        [HttpPost]
        public IActionResult EditUsuario(int id)
        {
            try
            {
                Usuarios? item = _Request.UsuarioById(id);
                if (item == null)
                {
                    return NotFound();
                }

                return View(item);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Usuarios item)
        {
            try
            {
                var Update = await _Request.EnviarPutAsync(item);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                item.Erro = ex.Message;
                return View("EditUsuario", item);
            }
        }     
    }
}