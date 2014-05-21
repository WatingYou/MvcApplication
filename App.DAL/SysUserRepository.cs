using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.IDAL;
using App.Models;
using System.Data;

namespace App.DAL
{
    public class SysUserRepository : ISysUserRepository, IDisposable
    {

        public IQueryable<SysUser> GetList(DBContainer db)
        {
            IQueryable<SysUser> list = db.SysUsers.AsQueryable();
            return list;
        }

        public int Create(SysUser entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.SysUsers.AddObject(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                SysUser entity = db.SysUsers.SingleOrDefault(a => a.Id == id);
                if (entity != null)
                {

                    db.SysUsers.DeleteObject(entity);
                }
                return db.SaveChanges();
            }
        }

        public void Delete(DBContainer db, string[] deleteCollection)
        {
            IQueryable<SysUser> collection = from f in db.SysUsers
                                             where deleteCollection.Contains(f.Id)
                                             select f;
            foreach (var deleteItem in collection)
            {
                db.SysUsers.DeleteObject(deleteItem);
            }
        }

        public int Edit(SysUser entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.SysUsers.Attach(entity);
                db.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                return db.SaveChanges();
            }
        }

        public SysUser GetById(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                return db.SysUsers.SingleOrDefault(a => a.Id == id);
            }
        }

        public bool IsExist(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                SysUser entity = GetById(id);
                if (entity != null)
                    return true;
                return false;
            }
        }
        public void Dispose()
        {

        }

        

        public IQueryable<P_Sys_GetRoleByUserId_Result> GetRoleByUserId(DBContainer db, string userId)
        {
            return db.P_Sys_GetRoleByUserId(userId).AsQueryable();
        }

        public void UpdateSysRoleSysUser(string userId, string[] roleIds)
        {
            using (DBContainer db = new DBContainer())
            {
                db.P_Sys_DeleteSysRoleSysUserByUserId(userId);
                foreach (string roleid in roleIds)
                {
                    if (!string.IsNullOrWhiteSpace(roleid))
                    {
                        db.P_Sys_UpdateSysRoleSysUser(roleid, userId);
                    }
                }
                db.SaveChanges();
            }
        }
    }
}
