
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proyectoDAL;
using proyectoEN;

namespace proyectoBL

{
    public class CategoriaBL
    {
        private readonly CategoriaDAL _categoriaDAL;

        public CategoriaBL(CategoriaDAL categoriaDAL)
        {
            _categoriaDAL = categoriaDAL;
        }

        public async Task<int> CreateCategoriaAsync(Categoria pCategoria)
        {
           

            return await _categoriaDAL.CreateCategoriaAsync(pCategoria);
        }

        public async Task<int> UpdateCategoriaAsync(Categoria pCategoria)
        {
           

            return await _categoriaDAL.UpdateCategoriaAsync(pCategoria);
        }

        public async Task<int> DeleteCategoriaAsync(int categoriaId)
        {
           

            var categoria = new Categoria { CategoriaId = categoriaId };
            return await _categoriaDAL.DeleteCategoriaAsync(categoria);
        }

        public async Task<Categoria> GetByIdAsync(int categoriaId)
        {
           
            var categoria = await _categoriaDAL.GetById(new Categoria { CategoriaId = categoriaId });

            return categoria;
        }

        public async Task<List<Categoria>> GetAllAsync()
        {
            return await _categoriaDAL.GetAllAsync(new Categoria());
        }
    }
}
