using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace CIED.Models
{
    public class Apunte
    {
        public int ApunteID { get; set; }
        [Required(ErrorMessage = "La descripcion es requerida.")]
        [StringLength(250)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El importe es requerido.")]
        public double Importe { get; set; }
        [Required(ErrorMessage = "La fecha es requerida.")]
        public DateTime Fecha { get; set; }
        public Boolean Estatus { get; set; }
        [Required(ErrorMessage = "El tipo de apunte es requerido.")]
        [Display(Name = "Tipo de Apunte")]
        public int TipoApunteID { get; set; }        
        public  virtual TipoApunte TipoApunte { get; set; }
        [Required(ErrorMessage = "La empresa es requerida.")]
        [Display(Name = "Empresa")]
        public int EmpresaID { get; set; }
        public virtual Empresa Empresa { get; set; }
        [Required(ErrorMessage = "El Slot es requerido.")]
        [Display(Name = "Slot")]
        public int SlotID { get; set; }
        public virtual Slot Slot { get; set; }
    }
}
