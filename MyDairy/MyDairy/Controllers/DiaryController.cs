using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyDiary.Models;

namespace MyDiary.Controllers
{
    public class DiaryController : Controller
    {
        DiaryDB db = new DiaryDB();

        //
        // GET: /Diary/



        public ActionResult Add()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            Diary d = new Diary();
            d.PubDate = DateTime.Now;
            d.Title=Request.Form["C_Title"];
            d.Content=Request.Form["C_Content"];
            d.UserId = ((MyDiary.Models.User)Session["User"]).Id;
            db.Diaries.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        
        public ActionResult Remove(int id)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            Diary item = db.Diaries.FirstOrDefault(m=>m.Id==id);
            db.Diaries.Remove(item);
            //Diary item = new Diary() {Id=""};
            
            /*db.Entry<Diary>(item).State这一步获取到了存在的对象 */ /*= System.Data.EntityState.Deleted;*打了个删除标记*/
            
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        
        public ActionResult Edit(int id)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            try
            {
                //数据绑定方式数据只能过来id的值
                //form表单提交title 和content 的值为空
                //数据绑定的过程到底是什么

                Diary item = db.Diaries.FirstOrDefault(m => m.Id == id);

                item.Title = Request.Form["Title"];
                item.Content = Request.Form["Content"];
                db.Entry<Diary>(item).State = System.Data.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                
                throw;
            }

            return RedirectToAction("Details","Diary");
        }

        public ActionResult Details(int id)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            Diary item = db.Diaries.FirstOrDefault(m => m.Id == id);

            return View(item);
           
        }
    }
}
