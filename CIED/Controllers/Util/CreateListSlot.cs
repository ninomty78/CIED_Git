
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CIED.Models;
using CIED.Controllers.Interfaces;

namespace CIED.Controllers.Util
{
    public class CreateListSlot : ICreateList
    {
        public void listOfItems(CIEDContext context, Controller controller)
        {
            List<Slot> liSlot = new List<Slot>();

            liSlot = context.Slot.ToList();
            controller.ViewBag.listofitemsSlot = liSlot;
        }
    }
}
