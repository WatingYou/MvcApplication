using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.IDAL;
using App.IBLL;
using App.Models.Sys;
using App.Common;
using App.Models;
using App.BLL.Core;
using System.Transactions;

namespace App.BLL
{
    public class SysRightBLL : BaseBLL, ISysRightBLL
    {
        ISysRightRepository m_Rep;
        public SysRightBLL(ISysRightRepository SysRightRepository)
        {
            this.m_Rep = SysRightRepository;
        }
        
        public int UpdateRight(SysRightOperateModel model)
        {
            return m_Rep.UpdateRight(model);
        }

        public List<P_Sys_GetRightByRoleAndModule_Result> GetRightByRoleAndModule(string roleId, string moduleId)
        {
            return m_Rep.GetRightByRoleAndModule(roleId, moduleId);
        }
    }
}
