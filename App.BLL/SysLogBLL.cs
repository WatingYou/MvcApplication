using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.IDAL;
using App.Models;
using App.IBLL;
using App.Common;

namespace App.BLL
{
    public class SysLogBLL :BaseBLL, ISysLogBLL
    {
        public ISysLogRepository LogRepository;

        public SysLogBLL(ISysLogRepository logRepository)
        {
            this.LogRepository = logRepository;
        }

        public List<SysLog> GetList(ref GridPager pager, string queryStr)
        {
            List<SysLog> query = null;
            IQueryable<SysLog> list = LogRepository.GetList(dbContainer);
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                list = list.Where(a => a.Message.Contains(queryStr) || a.Module.Contains(queryStr));
                pager.totalRows = list.Count();
            }
            else
            {
                pager.totalRows = list.Count();
            }

            if (pager.order == "desc")
            {
                query = list.OrderByDescending(c => c.CreateTime).Skip((pager.page - 1) * pager.rows).Take(pager.rows).ToList();
            }
            else
            {
                query = list.OrderBy(c => c.CreateTime).Skip((pager.page - 1) * pager.rows).Take(pager.rows).ToList();
            }


            return query;
        }
        public SysLog GetById(string id)
        {
            return LogRepository.GetById(id);
        }

        public int Create(SysLog entity)
        {
            return LogRepository.Create(entity);
        }

        public void WriteServiceLog(string oper, string mes, string result, string type, string module)
        {
            SysLog entity = new SysLog();
            entity.Id = ResultHelper.NewId;
            entity.Operator = oper;
            entity.Message = mes;
            entity.Result = result;
            entity.Type = type;
            entity.Module = module;
            entity.CreateTime = ResultHelper.NowTime;

            this.Create(entity);

        }
    }
}
