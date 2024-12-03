using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoEN
{
    public class Categoria
    {
        public object productos;

        [Key]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        public string Nombre { get; set; }

        public Task<int> CreateCategoriaAsync(Categoria pCategoria)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateCategoriaAsync(Categoria pCategoria)
        {
            throw new NotImplementedException();
        }      
        public Task<int> DeleteCategoriaAsync(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Task GetById(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        [InverseProperty("Categoria")]
        public List<Productos> Productos { get; set; }

        public Task<List<Categoria>> GetAllAsync(Categoria categoria)
        {
            throw new NotImplementedException();
        }
    }
}
