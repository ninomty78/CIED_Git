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
    public class CreateListEmpresa : ICreateList
    {
        public void listOfItems(CIEDContext context, Controller controller)
        {
            List<Empresa> liEmpresa = new List<Empresa>();

            liEmpresa = context.Empresa.ToList();
            controller.ViewBag.listofitemsEmpresa = liEmpresa;
            
        }
    }
}
