using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoEN
{
    public class Productos
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "La cantidad debe ser un número positivo.")]


      
        public int CategoriaId { get; set; }

        public Categoria? categoria { get; set; }
    }
}
