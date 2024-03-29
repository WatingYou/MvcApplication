﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.IBLL;
using App.Common;
using App.Models;
using App.Models.Sys;

namespace App.Admin.Controllers
{
    public class SysLogController : BaseController
    {
        ISysLogBLL LogBLL;
        public SysLogController(ISysLogBLL logBLL)
        {
            this.LogBLL = logBLL;
        }
        //
        // GET: /SysLog/

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetList(GridPager pager, string queryStr)
        {
            List<SysLog> list = LogBLL.GetList(ref pager, queryStr);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new SysLogModel()
                        {

                            Id = r.Id,
                            Operator = r.Operator,
                            Message = r.Message,
                            Result = r.Result,
                            Type = r.Type,
                            Module = r.Module,
                            CreateTime = r.CreateTime

                        }).ToArray()

            };

            return Json(json);
        }


        #region 详细

        public ActionResult Details(string id)
        {

            SysLog entity = LogBLL.GetById(id);
            SysLogModel info = new SysLogModel()
            {
                Id = entity.Id,
                Operator = entity.Operator,
                Message = entity.Message,
                Result = entity.Result,
                Type = entity.Type,
                Module = entity.Module,
                CreateTime = entity.CreateTime,
            };
            return View(info);
        }

        #endregion

    }
}
