using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.IDAL;
using App.Models;

namespace App.DAL
{
    public class SysModuleOperateRepository : ISysModuleOperateRepository, IDisposable
    {

        public IQueryable<SysModuleOperate> GetList(DBContainer db)
        {
            IQueryable<SysModuleOperate> list = db.SysModuleOperates.AsQueryable();
            return list;
        }

        public int Create(SysModuleOperate entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.SysModuleOperates.AddObject(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                SysModuleOperate entity = db.SysModuleOperates.SingleOrDefault(a => a.Id == id);
                if (entity != null)
                {

                    db.SysModuleOperates.DeleteObject(entity);
                }
                return db.SaveChanges();
            }
        }

        public SysModuleOperate GetById(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                return db.SysModuleOperates.SingleOrDefault(a => a.Id == id);
            }
        }

        public bool IsExist(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                SysModuleOperate entity = GetById(id);
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
