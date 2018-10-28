using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace CIED.Models
{
    public class PresupuestoDetalle
    {
        public int PresupuestoDetalleID { get; set; }
        [Required(ErrorMessage = "El presupuesto es requerido.")]
        [Display(Name = "Presupuesto")]
        public int PresupuestoID { get; set; }
        public virtual Presupuesto Presupuesto { get; set; }
        [Required(ErrorMessage = "La categoria es requerida.")]
        [Display(Name = "Categoria")]
        public int CategoriaID { get; set; }
        public virtual Categoria Categoria { get; set; }
        [Required(ErrorMessage = "La partida es requerida.")]
        public decimal Partida { get; set; }
        public decimal Real { get; set; }
        public decimal CantidadRestante { get; set; }
        public decimal PorcentajeRestante { get; set; }
       
    }
}
