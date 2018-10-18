using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CIED.Models;
using CIED.Controllers.Interfaces;

namespace CIED.Controllers.Util
{
    class CreateListTipoApunte: ICreateList
    {
        public void listOfItems(CIEDContext context, Controller controller)
        {
            List<TipoApunte> liTipoApunte = new List<TipoApunte>();

            liTipoApunte = context.TipoApunte.ToList();
            controller.ViewBag.listofitemsTipoApunte = liTipoApunte;
        }
    }
}
