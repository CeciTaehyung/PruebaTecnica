using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyectoBL;
using proyectoEN;

namespace proyecto.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly CategoriaBL _categoriaBL;

        public CategoriaController(CategoriaBL categoriaBL)
        {
            _categoriaBL = categoriaBL;
        }


        public async Task<IActionResult> Index()
        {
            var categoria = await _categoriaBL.GetAllAsync();
            return View(categoria);
        }


        public async Task<IActionResult> Details(int id)
        {
            var categoria = await _categoriaBL.GetByIdAsync(id);
            return View(categoria);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Categoria pCategoria)
        {

            await _categoriaBL.CreateCategoriaAsync(pCategoria);
            return Redirect("/Categoria/Index");

        }


        public async Task<IActionResult> Edit(int id)
        {
            var categoria = await _categoriaBL.GetByIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Categoria pCategoria)
        {
            await _categoriaBL.UpdateCategoriaAsync(pCategoria);
            return Redirect("/Categoria/Index");
        }


        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _categoriaBL.GetByIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoriaBL.DeleteCategoriaAsync(id);
            return Redirect("/Categoria/Index");
        }
    }
}
