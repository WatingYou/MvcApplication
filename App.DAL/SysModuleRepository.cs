using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.IDAL;
using App.Models;
using System.Data;

namespace App.DAL
{
    public class SysModuleRepository : IDisposable, ISysModuleRepository
    {
        public IQueryable<SysModule> GetList(DBContainer db)
        {
            IQueryable<SysModule> list = db.SysModules.AsQueryable();
            return list;
        }

        public IQueryable<SysModule> GetModuleBySystem(DBContainer db, string parentId)
        {
            return db.SysModules.Where(a => a.ParentId == parentId).AsQueryable();
        }

        public int Create(SysModule entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.SysModules.AddObject(entity);
                return db.SaveChanges();
            }
        }

        public void Delete(DBContainer db, string id)
        {
            SysModule entity = db.SysModules.SingleOrDefault(a => a.Id == id);
            if (entity != null)
            {

                //删除SysRight表数据
                var sr = db.SysRights.AsQueryable().Where(a => a.ModuleId == id);
                foreach (var o in sr)
                {
                    //删除SysRightOperate表数据
                    var sro = db.SysRightOperates.AsQueryable().Where(a => a.RightId == o.Id);
                    foreach (var o2 in sro)
                    {
                        db.SysRightOperates.DeleteObject(o2);
                    }
                    db.SysRights.DeleteObject(o);
                }
                //删除SysModuleOperate数据
                var smo = db.SysModuleOperates.AsQueryable().Where(a => a.ModuleId == id);
                foreach (var o3 in smo)
                {
                    db.SysModuleOperates.DeleteObject(o3);
                }
                db.SysModules.DeleteObject(entity);
            }
        }

        public int Edit(SysModule entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.SysModules.Attach(entity);
                db.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                return db.SaveChanges();
            }
        }

        public SysModule GetById(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                return db.SysModules.SingleOrDefault(a => a.Id == id);
            }
        }

        public bool IsExist(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                SysModule entity = GetById(id);
                if (entity != null)
                    return true;
                return false;
            }
        }
        public void Dispose()
        {

        }
    }
}
