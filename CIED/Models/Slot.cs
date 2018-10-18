using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace CIED.Models
{
    public class Slot
    {
        public int SlotID { get; set; }
        [Required(ErrorMessage = "La descripcion es requerida.")]
        [StringLength(250)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El importe es requerido.")]
        public double Importe { get; set; }
        [Required(ErrorMessage = "La fecha es requerida.")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "El identificador es requerido.")]
        public int Identificador { get; set; }
        public Boolean Estatus { get; set; }


    }
}
