using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.IBLL;
using App.Models;
using App.Common;
using App.IDAL;

namespace App.BLL
{
    public class SysExceptionBLL : BaseBLL,ISysExceptionBLL
    {
        public ISysExceptionRepository ExceptionRepository;

        public SysExceptionBLL(ISysExceptionRepository exceptionRepository)
        {
            this.ExceptionRepository = exceptionRepository;
        }

        public List<SysException> GetList(ref GridPager pager, string queryStr)
        {
            List<SysException> query = null;
            IQueryable<SysException> list = ExceptionRepository.GetList(dbContainer);
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                list = list.Where(a => a.Message.Contains(queryStr));
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
        public SysException GetById(string id)
        {
            return ExceptionRepository.GetById(id);
        }
    }
}
