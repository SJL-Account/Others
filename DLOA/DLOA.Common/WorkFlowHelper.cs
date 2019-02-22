using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using System.Activities.DurableInstancing;
using System.Runtime.DurableInstancing;
using System.Configuration;
namespace DLOA.Common
{
    /// <summary>
    /// 控制工作流的开启和暂停
    /// </summary>
    public  class WorkFlowHelper
    {
        /// <summary>
        /// 开启工作流
        /// </summary>
        public static Guid Run(Activity activity,Dictionary<string,object> dic)
        {
            //创建activity
            
            //创建Application对象
            WorkflowApplication app = new WorkflowApplication(activity, dic);
            
            
            //Func<WorkflowApplicationIdleEventArgs, PersistableIdleAction> 
            //设置空闲时卸载
            app.PersistableIdle = m => { return PersistableIdleAction.Unload; };
            
            
            //设置持久化储存
            string ConnStr=ConfigurationManager.ConnectionStrings["WFConnStr"].ConnectionString;
            SqlWorkflowInstanceStore store=new SqlWorkflowInstanceStore(ConnStr);
            app.InstanceStore = store;
            
            
            //开启工作流
            app.Run();

            return Guid.Parse(app.Id.ToString());
        }
        /// <summary>
        /// 重启工作流
        /// </summary>
        public  static  void Resume(Activity activity, Guid guid,string bookmarkName,object value)
        {


            //创建Application对象
            WorkflowApplication app = new WorkflowApplication(activity);


            //Func<WorkflowApplicationIdleEventArgs, PersistableIdleAction> 
            //设置空闲时卸载
            app.PersistableIdle = m => { return PersistableIdleAction.Unload; };


            //设置持久化储存
            string ConnStr = ConfigurationManager.ConnectionStrings["WFConnStr"].ConnectionString;
            SqlWorkflowInstanceStore store = new SqlWorkflowInstanceStore(ConnStr);
            app.InstanceStore = store;

            //加载数据库实例
            app.Load(guid);

            app.ResumeBookmark(bookmarkName,value);
            
        }

    }
}
