using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace CIED.Models
{
    public class Categoria
    {
        public int CategoriaID { get; set; }
        [Required(ErrorMessage = "La descripcion es requerida.")]
        [StringLength(250)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        public Boolean Estatus { get; set; }
    }
}
