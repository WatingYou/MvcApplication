﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Models;
using App.IDAL;

namespace App.DAL
{
    public class SysLogRepository : IDisposable, ISysLogRepository
    {
        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="db">数据库</param>
        /// <returns>集合</returns>
        public IQueryable<SysLog> GetList(DBContainer db)
        {
            IQueryable<SysLog> list = db.SysLogs.AsQueryable();
            return list;
        }
        /// <summary>
        /// 创建一个对象
        /// </summary>
        /// <param name="db">数据库</param>
        /// <param name="entity">实体</param>
        public int Create(SysLog entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.SysLogs.AddObject(entity);
                return db.SaveChanges();
            }

        }

        /// <summary>
        /// 删除对象集合
        /// </summary>
        /// <param name="db">数据库</param>
        /// <param name="deleteCollection">集合</param>
        public void Delete(DBContainer db, string[] deleteCollection)
        {
            IQueryable<SysLog> collection = from f in db.SysLogs
                                            where deleteCollection.Contains(f.Id)
                                            select f;
            foreach (var deleteItem in collection)
            {
                db.SysLogs.DeleteObject(deleteItem);
            }
        }
        /// <summary>
        /// 根据ID获取一个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SysLog GetById(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                return db.SysLogs.SingleOrDefault(a => a.Id == id);
            }
        }
        public void Dispose()
        {

        }
    }
}
