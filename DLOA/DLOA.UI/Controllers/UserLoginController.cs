using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DLOA.Common;
using DLOA.Model;
using DLOA.IService;
using DLOA.UI.Models;
namespace DLOA.UI.Controllers
{
    public class UserLoginController : Controller
    {

        IUserInfoService service { get; set; }
        //
        // GET: /UserLogin/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCodeImage()
        {
            ValidateCode validCode = new ValidateCode();
            string code= validCode.CreateValidateCode(4);
            Session["validCode"] = code;
            byte[] buffer = validCode.CreateValidateGraphic(code);

            return File(buffer,"image/jpeg");
        }
        [HttpPost]
        public ActionResult Login(UserInfo userinfo)
        {
            //验证码验证
          string  validCode= Session["validCode"] != null ? Session["validCode"].ToString() : string.Empty;

          if (validCode!=Request.Form["vCode"]||string.IsNullOrEmpty(validCode))
          {
              return Content("unvalidVCode");
          }
              //密码 验证
          else
          {
              string UserPwd = MD5Helper.EncryptString(userinfo.UserPwd);
              UserInfo ui= service.GetList(u => u.UserName == userinfo.UserName && u.UserPwd ==UserPwd ).FirstOrDefault();
              if(ui!=null)
              {
                  //使用cookies+mm代替session
                  //Session["UserInfo"] = ui;

                  //使用分布式缓存进行登录操作
                  //1、创建标识
                  string guid = Guid.NewGuid().ToString();
                  //2、向客户端写标识
                  Response.Cookies.Add(new HttpCookie("LoginId", guid));
                  //3、向分布式缓存服务器写信息
                  MemcachedHelper mm = new MemcachedHelper();
                  mm.set(guid,ui,DateTime.Now.AddMinutes(20));
                  Data.userinfo = ui;
                  //return RedirectToAction("Index","Home");
                  return Content("ok");
              }
              else
              {
                  return Content("no");
              }
          }
          

         
        }
        
        public ActionResult LogOut()
        {
           
            if(Request.Cookies.Get("LoginId")!=null)
            {
                string key = Request.Cookies.Get("LoginId").Value;
                Request.Cookies.Get("LoginId").Expires = DateTime.Now.AddMinutes(-1);
                MemcachedHelper mm = new MemcachedHelper();
                mm.Delete(key);
            }
            return RedirectToAction("Index","UserLogin");
        }
	}
}