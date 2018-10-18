using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CIED.Models
{
    public class CIEDContext : DbContext
    {
        public CIEDContext (DbContextOptions<CIEDContext> options)
            : base(options)
        {
        }

        public DbSet<CIED.Models.Apunte> Apunte { get; set; }
        public DbSet<CIED.Models.Slot> Slot { get; set; }
        public DbSet<CIED.Models.TipoApunte> TipoApunte { get; set; }
        public DbSet<CIED.Models.Empresa> Empresa { get; set; }
    }
}
