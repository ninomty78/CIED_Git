using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CIED.Models;
using CIED.Controllers.Interfaces;

namespace CIED.Controllers.Util
{
    public class CreateListCategoria : ICreateList
    {
        public void listOfItems(CIEDContext context, Controller controller)
        {
            List<Categoria> liCategoria = new List<Categoria>();

            liCategoria = context.Categoria.ToList();
            controller.ViewBag.listofitemsCategoria = liCategoria;
        }
    }
}
