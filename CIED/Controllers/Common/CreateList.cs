using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CIED.Models;
using CIED.Controllers.Interfaces;

namespace CIED.Controllers.Common
{
     class CreateList
    {
        private ICreateList _createList;

        public CreateList(ICreateList createList)
        {
            _createList = createList;
        }
                
        public void LoadList(CIEDContext context, Controller controller)
        {
            _createList.listOfItems(context, controller);
        }

     

    }
}
