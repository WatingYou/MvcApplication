using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.IDAL;
using App.Models;
using System.Data;

namespace App.DAL
{
    public class SysSampleRepository : ISysSampleRepository, IDisposable
    {
        public IQueryable<SysSample> GetList(DBContainer db)
        {
            IQueryable<SysSample> list = db.SysSamples.AsQueryable();
            return list;
        }

        public int Create(SysSample entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.SysSamples.AddObject(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                SysSample entity = db.SysSamples.SingleOrDefault(a => a.ID == id);
                if (entity != null)
                {

                    db.SysSamples.DeleteObject(entity);
                }
                return db.SaveChanges();
            }
        }

        public int Edit(SysSample entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.SysSamples.Attach(entity);
                db.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                return db.SaveChanges();
            }
        }

        public SysSample GetById(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                return db.SysSamples.SingleOrDefault(a => a.ID == id);
            }
        }

        public bool IsExist(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                SysSample entity = GetById(id);
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
