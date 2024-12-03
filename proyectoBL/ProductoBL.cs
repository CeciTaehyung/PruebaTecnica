using proyectoDAL;
using proyectoEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyectoBL
{
    public class ProductoBL
    {
        private readonly ProductoDAL _productosDAL;

        public ProductoBL(ProductoDAL productosDAL)
        {
            _productosDAL = productosDAL;
        }

        public async Task<int> CreateProductoAsync(Productos producto)
        {
          
            return await _productosDAL.CreateProductoAsync(producto);
        }

        public async Task<int> EditProductoAsync(Productos producto)
        {
          

            return await _productosDAL.EditProductoAsync(producto);
        }

        public async Task<Productos> GetByIdAsync(int id)
        {
           
            var producto = await _productosDAL.GetByIdAsync(new Productos { id = id });

           

            return producto;
        }

        public async Task<List<Productos>> GetAllAsync()
        {
            return await _productosDAL.GetAllAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            


            var producto = new Productos { id = id };

            return await _productosDAL.DeleteAsync(producto);
        }
    }
}
