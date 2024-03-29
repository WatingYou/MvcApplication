﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.IDAL;
using App.Models.Sys;
using App.Models;
using System.Data;

namespace App.DAL
{
    public class SysRightRepository : ISysRightRepository, IDisposable
    {
        /// <summary>
        /// 取角色模块的操作权限，用于权限控制
        /// </summary>
        /// <param name="accountid">acount Id</param>
        /// <param name="controller">url</param>
        /// <returns></returns>
        public List<PermModel> GetPermission(string accountid, string controller)
        {

            using (DBContainer db = new DBContainer())
            {
                List<PermModel> rights = (from r in db.P_Sys_GetRightOperate(accountid, controller)
                                          select new PermModel
                                          {
                                              KeyCode = r.KeyCode,
                                              IsValid = r.IsValid
                                          }).ToList();
                return rights;
            }
        }
        public void Dispose()
        {

        }

        public int UpdateRight(SysRightOperateModel model)
        {
            //转换
            SysRightOperate rightOperate = new SysRightOperate();
            rightOperate.Id = model.Id;
            rightOperate.RightId = model.RightId;
            rightOperate.KeyCode = model.KeyCode;
            rightOperate.IsValid = model.IsValid;
            //判断rightOperate是否存在，如果存在就更新rightOperate,否则就添加一条
            using (DBContainer db = new DBContainer())
            {
                SysRightOperate right = db.SysRightOperates.Where(a => a.Id == rightOperate.Id).FirstOrDefault();
                if (right != null)
                {
                    right.IsValid = rightOperate.IsValid;
                }
                else
                {
                    db.SysRightOperates.AddObject(rightOperate);
                    
                }
                if (db.SaveChanges() > 0)
                {
                    //更新角色--模块的有效标志RightFlag
                    var sysRight = (from r in db.SysRights
                                    where r.Id == rightOperate.RightId
                                    select r).First();
                    db.P_Sys_UpdateSysRightRightFlag(sysRight.ModuleId, sysRight.RoleId);
                    return 1;
                }
            }
            return 0;
        }
        //按选择的角色及模块加载模块的权限项
        public List<P_Sys_GetRightByRoleAndModule_Result> GetRightByRoleAndModule(string roleId, string moduleId)
        {
            List<P_Sys_GetRightByRoleAndModule_Result> result = null;
            using (DBContainer db = new DBContainer())
            {
                result = db.P_Sys_GetRightByRoleAndModule(roleId, moduleId).ToList();
            }
            return result;
        }
    }
}
