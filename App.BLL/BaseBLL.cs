using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Models;

namespace App.BLL
{
    public class BaseBLL
    {
        protected readonly  DBContainer dbContainer;
        public BaseBLL()
        {
            dbContainer = new DBContainer();
        }
    }
}
