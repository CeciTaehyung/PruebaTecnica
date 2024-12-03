using Microsoft.EntityFrameworkCore;
using proyectoEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoDAL
{
    public class ProductoDAL
    {
        private readonly SysProductoDBContext _sysProductoDBContext;
        public ProductoDAL(SysProductoDBContext sysProductoDBContext)
        {
            _sysProductoDBContext = sysProductoDBContext;
        }

        public async Task<int> CreateProductoAsync (Productos productos)
        {
            var producto = new Productos
            {
                Nombre = productos.Nombre,
                CategoriaId = productos.CategoriaId,
            };
            _sysProductoDBContext.productos.Add(producto);
            return await _sysProductoDBContext.SaveChangesAsync();
        }

        public async Task<int> EditProductoAsync (Productos productos)
        {
            var producto = await _sysProductoDBContext.productos.FirstOrDefaultAsync(p => p.id == productos.id);
            if (producto != null) 
            { 
                producto.Nombre = producto.Nombre;
                producto.CategoriaId = productos.CategoriaId;
                return await _sysProductoDBContext.SaveChangesAsync();
            };
            return 0;
        }
        
        public async Task<Productos> GetByIdAsync ( Productos pProductos)
        {
            var productos = await _sysProductoDBContext.productos
                .Include(p => p.categoria)
                .FirstOrDefaultAsync(p => p.id == pProductos.id);

            if(productos != null)
            {
                return new Productos
                {
                    id = productos.id,
                    Nombre = productos.Nombre,
                    CategoriaId = productos.CategoriaId,
                };
            }
            return new Productos();
        }

        public async Task<List<Productos>> GetAllAsync()
        {
            var producto = await _sysProductoDBContext.productos.ToListAsync();
            if (producto != null && producto.Count > 0)
            {
                var list = new List<Productos>();
                producto.ForEach(p => list.Add(new Productos
                    {
                     id =p.id,
                     Nombre = p.Nombre,
                     CategoriaId =p.CategoriaId,
                    }));
                return list;
            }
            return new List<Productos>();
        }

        public async Task<int> DeleteAsync (Productos productos)
        {
            var producto = await _sysProductoDBContext.productos.FirstOrDefaultAsync(p => p.id == productos.id);
            if (productos != null)
            {
                _sysProductoDBContext.productos.Remove(producto);
                return await _sysProductoDBContext.SaveChangesAsync();
            }
            return 0;
        }
    }
}
