using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIED.Models;

namespace CIED.Data
{
    public class DbInitializer
    {
        public static void Initialize (CIEDContext context)
        {
            context.Database.EnsureCreated();

        }
    }
}
