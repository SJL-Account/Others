using Spring.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Threading;
using DLOA.UI.Models;
using System.IO;
using log4net;
using System.Configuration;

namespace DLOA.UI
{
    //继承SpringMvcApplication,实现IOC
    public class MvcApplication : SpringMvcApplication    // System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();//读取了配置文件中关于Log4Net配置信息.
            

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //开启线程，扫描异常队列
            //定义写入路径
            string Path = Server.MapPath("/Log/");
            //开启线程池
            ThreadPool.QueueUserWorkItem(/*WaitCallback 委托变量，参数为object类型)*/ (a) => {
                 // 摘要: 
                //     表示线程池线程要执行的回调方法。
                //
                // 参数: 
                //   state:
                //     包含回调方法要使用的信息的对象
                //方法永远不停
                while(true)
                {
                    //队列中是否有数据
                    if(ExAttribute.ExQueue.Count>0)
                    {
                        //取出队列中的值
                        Exception ex = ExAttribute.ExQueue.Dequeue();
                        if (ex != null)
                        {
                            //异常写入文件
                            string fileName = DateTime.Now.ToString("yyyy-MM-dd")+".txt";
                           File.AppendAllText(Path + fileName, ex.ToString(), System.Text.Encoding.UTF8);
                            //ILog log = LogManager.GetLogger("errorLog");
                            //log.Error(ex.ToString());
                        }
                        else
                        {
                            //防止网站空转
                            Thread.Sleep(3000);
                        }
                    }
                    else
                    {
                        //防止网站空转
                        Thread.Sleep(3000);
                    }

                    
                }
            
            }, Path);


        }
    }
}
