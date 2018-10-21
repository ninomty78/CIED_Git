using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CIED.Models
{
    public class Presupuesto
    {
        public int PresupuestoID { get; set; }
        [Required(ErrorMessage = "La descripcion es requerida.")]
        [StringLength(250)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }       
        [Required(ErrorMessage = "El Año es requerido.")]
        public int Anio { get; set; }
        public virtual List<PresupuestoDetalle> PresupuestoDetalle { get; set; }
    }
}
