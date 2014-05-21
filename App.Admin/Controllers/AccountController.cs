using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.IBLL;
using App.Common;
using App.Models;
using App.Models.Sys;
using System.Web.Security;

namespace App.Admin.Controllers
{
    public class AccountController : BaseController
    {
        IAccountBLL AccountBLL;
        public AccountController(IAccountBLL accountBLL)
        {
            this.AccountBLL = accountBLL;
        }
        //
        // GET: /Account/
        [AllowAnonymous]
        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        
        public JsonResult Login(string UserName, string Password, string Code, string returnUrl)
        {
            if (Session["Code"] == null)
            {
                return Json(JsonHandler.CreateMessage(0, "请重新刷新验证码"), JsonRequestBehavior.AllowGet);
            }

            if (Session["Code"].ToString().ToLower() != Code.ToLower())
            {
                return Json(JsonHandler.CreateMessage(0, "验证码错误"), JsonRequestBehavior.AllowGet);
            }
            SysUser user = AccountBLL.Login(UserName, ValueConvert.MD5(Password));
            if (user == null)
            {
                return Json(JsonHandler.CreateMessage(0, "用户名或密码错误"), JsonRequestBehavior.AllowGet);
            }
            else if (!Convert.ToBoolean(user.State))//被禁用
            {
                return Json(JsonHandler.CreateMessage(0, "账户被系统禁用"), JsonRequestBehavior.AllowGet);
            }

            //验证成功
            AccountModel account = new AccountModel();
            account.Id = user.Id;
            account.TrueName = user.TrueName;
            Session["Account"] = account;

            FormsAuthentication.SetAuthCookie(UserName, true);

            string path = "/Home/Index";
            if (Url.IsLocalUrl(returnUrl))
            {
                path = returnUrl;
            }

            return Json(JsonHandler.CreateMessage(1, path), JsonRequestBehavior.AllowGet);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Account");
        }
    }
}
