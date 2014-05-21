using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Models.Sys;
using App.Common;
using App.Models;

namespace App.IBLL
{
    public interface ISysRightBLL
    {
        int UpdateRight(SysRightOperateModel model);
        List<P_Sys_GetRightByRoleAndModule_Result> GetRightByRoleAndModule(string roleId, string moduleId);
    }
}
