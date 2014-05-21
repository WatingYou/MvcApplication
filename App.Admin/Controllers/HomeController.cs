using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Models;
using App.IBLL;
using App.Models.Sys;

namespace App.Admin.Controllers
{
    public class HomeController : BaseController
    {
        IHomeBLL HomeBLL;

        public HomeController(IHomeBLL homeBLL)
        {
            HomeBLL = homeBLL;
        }

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取导航菜单
        /// </summary>
        /// <param name="id">所属</param>
        /// <returns>树</returns>
        public JsonResult GetTree(string id)
        {
            if (GetAccount() != null)
            {
                List<SysModule> menus = HomeBLL.GetMenuByPersonId(GetUserId(), id);
                var jsonData = (
                        from m in menus
                        select new
                        {
                            id = m.Id,
                            text = m.Name,
                            value = m.Url,
                            showcheck = false,
                            complete = false,
                            isexpand = false,
                            checkstate = 0,
                            hasChildren = m.IsLast ? false : true,
                            Icon = m.Iconic
                        }
                    ).ToArray();
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("0", JsonRequestBehavior.AllowGet);
            }
        }
    }
}
