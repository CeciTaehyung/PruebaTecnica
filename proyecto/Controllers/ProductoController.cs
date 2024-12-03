using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoBL;
using proyectoEN;

namespace proyecto.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ProductoBL _productoBL;

        public ProductoController(ProductoBL productoBL)
        {
            _productoBL = productoBL;
        }
        public async Task<IActionResult> Index()
        {
            var productos = await _productoBL.GetAllAsync();
            return View(productos);
        }
        public async Task<IActionResult> Create(Productos pProductos)
        {
            if (string.IsNullOrEmpty(pProductos.Nombre))
            {
                ModelState.AddModelError("Nombre", "El nombre del producto es obligatorio.");
                return View(pProductos);
            }

            int result = await _productoBL.CreateProductoAsync(pProductos);
            return Redirect("/Producto/Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var productos = await _productoBL.GetByIdAsync(id);
            if (productos == null)
            {
                return NotFound();
            }
            return View(productos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Productos pProductos)
        {
            if (string.IsNullOrEmpty(pProductos.Nombre))
            {
                ModelState.AddModelError("Nombre", "El nombre del producto es obligatorio.");
                return View(pProductos); 
            }

            int result = await _productoBL.EditProductoAsync(pProductos);
            return Redirect("/Producto/Index");
        }


        public async Task<IActionResult> Delete(int id)
        {
            var productos = await _productoBL.GetByIdAsync(id);
            if (productos == null)
            {
                return NotFound();
            }
            return View(productos);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productoBL.DeleteAsync(id);
            return Redirect("/Producto/Index");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var categoria = await _productoBL.GetByIdAsync(id);
            return View(categoria);
        }
    }
}
