using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
