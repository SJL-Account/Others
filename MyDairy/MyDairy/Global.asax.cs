using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using MyDiary.Models;

namespace MyDiary
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

           // Database.SetInitializer(new SampleData());
            DiaryDB db = new DiaryDB();
            if(db.Database.CreateIfNotExists())
            {
                creatData(db);

            }


        }

        void creatData(DiaryDB context)
        {

            context.Users.Add(new User
            {
                UserName = "sjl",
                Password = "12345",
                Diaries = new List<Diary> {

                    new Diary{Title="hello1",Content="This is the Content1",PubDate=DateTime.Now },
                    new Diary{Title="hello2",Content="This is the Content2",PubDate=DateTime.Now },
                    new Diary{Title="hello3",Content="This is the Content3",PubDate=DateTime.Now }

                }
            });

            context.Users.Add(new User
            {
                UserName = "sjl2",
                Password = "12345",
                Diaries = new List<Diary> {

                    new Diary{Title="hello4",Content="This is the Content4",PubDate=DateTime.Now },
                    new Diary{Title="hello5",Content="This is the Content5",PubDate=DateTime.Now },
                    new Diary{Title="hello6",Content="This is the Content6",PubDate=DateTime.Now }

                }
            });

            context.SaveChanges();
        }
    }
}