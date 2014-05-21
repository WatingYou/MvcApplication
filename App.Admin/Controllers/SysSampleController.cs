using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.BLL;
using App.IBLL;
using App.Models.Sys;
using App.Common;

namespace App.Admin.Controllers
{
    public class SysSampleController : BaseController
    {
        //
        // GET: /SysSample/

        private ISysSampleBLL SysSampleBll;
        private ISysLogBLL SysLogBLL;
        ValidationErrors errors = new ValidationErrors();

        public SysSampleController(ISysSampleBLL sysSmapleBLL, ISysLogBLL sysLogBLL)
        {
            this.SysSampleBll = sysSmapleBLL;
            this.SysLogBLL = sysLogBLL;
        }

        [SupportFilter]
        public ActionResult Index()
        {
            ViewBag.Perm = GetPermission();
            return View();
        }
        [HttpPost]
        [SupportFilter(ActionName="Index")]
        public JsonResult GetList(GridPager pager)
        {
            List<SysSampleModel> list = SysSampleBll.GetList(ref pager);
            var json = new
            {
                total = list.Count,
                rows = (from r in list
                        select new SysSampleModel()
                        {
                            ID = r.ID,
                            Name = r.Name,
                            Age = r.Age,
                            Bir = r.Bir,
                            Photo = r.Photo,
                            Note = r.Note,
                            CreatTime = r.CreatTime,

                        }).ToArray()
            };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        #region 创建
        [SupportFilter]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 测试权限
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Test()
        {
            return View();
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Create(SysSampleModel model)
        {
            if (SysSampleBll.Create(ref errors, model))
            {
                SysLogBLL.WriteServiceLog("虚拟用户", "Id:" + model.ID + ",Name:" + model.Name, "成功", "创建", "样例程序");
                return Json(JsonHandler.CreateMessage(1, "插入成功"), JsonRequestBehavior.AllowGet);
            }
            else
            {
                string ErrorCol = errors.Error;
                SysLogBLL.WriteServiceLog("虚拟用户", "Id:" + model.ID + ",Name:" + model.Name + "," + ErrorCol, "失败", "创建", "样例程序");
                return Json(JsonHandler.CreateMessage(0, "插入失败" + ErrorCol), JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region 修改

        [SupportFilter]
        public ActionResult Edit(string id)
        {
            ViewBag.Perm = GetPermission();
            SysSampleModel entity = SysSampleBll.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Edit(SysSampleModel model)
        {
            if (SysSampleBll.Edit(model))
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region 详细
        [SupportFilter]
        public ActionResult Details(string id)
        {
            SysSampleModel entity = SysSampleBll.GetById(id);
            return View(entity);
        }

        #endregion

        #region 删除
        [HttpPost]
        [SupportFilter]
        public JsonResult Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                if (SysSampleBll.Delete(id))
                {
                    return Json(1, JsonRequestBehavior.AllowGet);
                }
                else
                {

                    return Json(0, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }


        }
        #endregion
    }
}
