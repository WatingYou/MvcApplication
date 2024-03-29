﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Models;
using App.Common;

namespace App.IBLL
{
    public interface ISysLogBLL
    {
        List<SysLog> GetList(ref GridPager pager, string queryStr);
        SysLog GetById(string id);
        int Create(SysLog entity);
        void WriteServiceLog(string oper, string mes, string result, string type, string module);
    }
}
