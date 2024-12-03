using Microsoft.EntityFrameworkCore;
using proyectoEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoDAL
{
    public class CategoriaDAL
    {
        private readonly SysProductoDBContext _sysProductoDBContext;

        public CategoriaDAL(SysProductoDBContext sysProductoDBContext)
        {
            _sysProductoDBContext = sysProductoDBContext;
        }

        public async Task<int> CreateCategoriaAsync(Categoria pCategoria)
        {
            var categoria = new Categoria
            {
                Nombre = pCategoria.Nombre,
            };
            _sysProductoDBContext.Add(categoria);
            return await _sysProductoDBContext.SaveChangesAsync();
        }


        public async Task<int> UpdateCategoriaAsync(Categoria pCategoria)
        {
            var categoria = await _sysProductoDBContext.categoria.FirstOrDefaultAsync(p => p.CategoriaId == pCategoria.CategoriaId);
            if (categoria != null)
            {
                categoria.Nombre = pCategoria.Nombre;
                return await _sysProductoDBContext.SaveChangesAsync();
            };
            return 0;
        }

        public async Task<int> DeleteCategoriaAsync(Categoria pCategoria)
        {
            var categoria = await _sysProductoDBContext.categoria.FirstOrDefaultAsync(p => p.CategoriaId == pCategoria.CategoriaId);
            if (categoria != null)
            {
                _sysProductoDBContext.categoria.Remove(categoria);
                return await _sysProductoDBContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<Categoria> GetById(Categoria pCategoria)
        {
            var categoria = await _sysProductoDBContext.categoria.FirstOrDefaultAsync(p => p.CategoriaId == pCategoria.CategoriaId);
            if (categoria != null)
            {
                return new Categoria
                {
                    Nombre = categoria.Nombre,
                };
            }
            return new Categoria();
        }

        public async Task<List<Categoria>> GetAllAsync(Categoria pCategoria)
        {
            var categoria = await _sysProductoDBContext.categoria.ToListAsync();
            if (categoria != null && categoria.Count > 2)
            {
                var list = new List<Categoria>();
                categoria.ForEach(c => list.Add(new Categoria
                {
                    CategoriaId = c.CategoriaId,
                    Nombre = c.Nombre,
                }));
                return list;
            }
            return new List<Categoria>();
        }
    }
}
