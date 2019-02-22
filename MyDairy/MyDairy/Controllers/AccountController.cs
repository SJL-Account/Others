using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyDiary.Models;

namespace MyDiary.Controllers
{
    public class AccountController : Controller
    {
        //
        DiaryDB db = new DiaryDB();

        //B
        // GET: /Account/
        //既能接受post请求，又能接受get请求
        public ActionResult Login()
        {

            return View();
        }

        //[HttpPost]//只能接受post请求 优先处理post请求
        //public ActionResult Login(User user)
        //{

        //    if(user.UserName!=null)
        //    {
        //        var item = db.Users.FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
        //        ////Linq表达式强类型
        //        // List<User> lu = (db.Users.Where(u => u.UserName == user.UserName && u.Password == user.Password)).ToList();
        //        // User item = lu.FirstOrDefault();
        //        //linq表达式弱类型
        //        //var lu = db.Users.Where(u => u.UserName == user.UserName && u.Password == user.Password);
        //        //var item = lu.FirstOrDefault();
        //        //弱类型linq表达式的另一种写法，比较灵活
        //        //var lu = from u in db.Users
        //        //         where u.UserName == user.UserName && u.Password == user.Password
        //        //         select u;
        //        //var item = lu.FirstOrDefault();
        //        //强类型linq表达式的另一种写法
        //        //List<User> lu = (from u in db.Users
        //        //         where u.UserName == user.UserName && u.Password == user.Password
        //        //         select u).ToList();
        //        //User item = lu.FirstOrDefault();

        //        if (item != null)
        //        {
        //            Session["User"] = item;
        //            return RedirectToAction("Index", "Home");
        //        }
        //        //返回错误信息
        //        ModelState.AddModelError("", "Login Error");
        //        //返回user信息
        //        return View(user);
        //    }
        //    return View();
           
            
        //}


        [HttpPost]//只能接受post请求 优先处理post请求
        public ActionResult Login(string UserName,string Password)
        {

            if (UserName != null)
            {
                var item = db.Users.FirstOrDefault(u => u.UserName == UserName && u.Password == Password);
                ////Linq表达式强类型
                // List<User> lu = (db.Users.Where(u => u.UserName == user.UserName && u.Password == user.Password)).ToList();
                // User item = lu.FirstOrDefault();
                //linq表达式弱类型
                //var lu = db.Users.Where(u => u.UserName == user.UserName && u.Password == user.Password);
                //var item = lu.FirstOrDefault();
                //弱类型linq表达式的另一种写法，比较灵活
                //var lu = from u in db.Users
                //         where u.UserName == user.UserName && u.Password == user.Password
                //         select u;
                //var item = lu.FirstOrDefault();
                //强类型linq表达式的另一种写法
                //List<User> lu = (from u in db.Users
                //         where u.UserName == user.UserName && u.Password == user.Password
                //         select u).ToList();
                //User item = lu.FirstOrDefault();

                if (item != null)
                {
                    Session["User"] = item;
                    return RedirectToAction("Index", "Home");
                }
                //返回错误信息
                ModelState.AddModelError("", "Login Error");
                //返回user信息
                
            }
            return View();


        }
        public ActionResult Logoff()  
        {

            Session.Clear();
            return RedirectToAction("Login","Account");
        }

        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {

            if(db.Users.FirstOrDefault(n=>n.UserName==user.UserName)==null)
            {
                db.Users.Add(user);

                db.SaveChanges();               
            }
            else
            {
                ModelState.AddModelError("","Repeat UserName!");
            }



            return View();
        }

    }
}
