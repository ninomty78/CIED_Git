using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CIED.Models;


namespace CIED.Controllers.Interfaces
{
    interface ICreateList
    {
        void listOfItems(CIEDContext context, Controller controller);
    }
}
