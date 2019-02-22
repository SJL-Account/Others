using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using  DLOA.UI.Models;
using DLOA.IService;
using DLOA.Model;
using DLOA.Service;
using DLOA.Common;
using DLOA.WorkFlow;
using System.Activities;
using System.Linq.Expressions;

namespace DLOA.UI.Controllers
{
    public class ApplyExpenseController : BaseController
    {



        //
        // GET: /ApplyExpense/
        public ActionResult Index()
        {
            int a;
            IQueryable<UserInfo> userinfoList = userinfoservice.GetList(m => m.IsDeleted == false);
            ViewData["selectList"]= new SelectList(userinfoList, "UserId", "UserName");
            return View();
        }

        public ActionResult ApplyStart(ExpenseFormData e )
        {
            string Result = "no";
            Activity activity = new ApplyExpense();
            Guid guid = WorkFlowHelper.Run(activity, new Dictionary<string, object> { 
            {"M",e.Money},{"R",e.Reason}
            });

            WorkFlowInstance wfi=new WorkFlowInstance { 
            InstantTitle=e.InstanceTitle,

            InstanceGuid=guid.ToString(),
            InstanceState=Convert.ToInt32(InstanceState.State.Approve),
            SubBy=CurrentLoginUserInfo.UserId,
            SubTime=DateTime.Now,
            Remark = "报销事由：" + e.Reason + "           金额：" + e.Money

            };

            wfi.WorkFlowStep.Add(new WorkFlowStep
            { 
            NextId=e.NextId,
            SubBy = CurrentLoginUserInfo.UserId,
            SubTime = DateTime.Now,
            Remark = "报销事由：" + e.Reason + "      金额：" + e.Money,


            });
            if (workFlowInstanceService.Add(wfi))
           {
               Result = "ok";
           }

           return Content(Result);
         
        }

        public ActionResult ApplyList()
        {
            //获取待审批的列表
            ViewData["workFlowStepWaittingList"] = workFlowStepService.GetList(m => (m.NextId == CurrentLoginUserInfo.UserId)&&(m.IsOver==false));
            //申请人 申请时间 申请标题 申请详细 
        //获取审批完成的列表

           //Expression<Func<WorkFlowStep, bool>>


            ViewData["workFlowStepOverList"] = workFlowStepService.GetList(m => (m.SubBy == CurrentLoginUserInfo.UserId) && (m.IsOver == true));
            //   (WorkFlowStep m) => {  
            //    if (m.WorkFlowInstance.InstanceId != m.SubBy)
            //     return (m.SubBy == CurrentLoginUserInfo.UserId) && (m.IsOver == true);
            //    else
            //     return false;
            //});
            //    if (m.WorkFlowInstance.InstanceId != m.SubBy)
            //    { return (m.SubBy == CurrentLoginUserInfo.UserId) && (m.IsOver == true);}
            //    else
            //    { return false;}

            //});
            ViewBag.UserName = userinfoservice;
            return View();
        }

        public ActionResult ApplyDetails(int InstanceId, int StepId)
        {
            var Details = workFlowStepService.GetById(StepId);
            //获取全部列表
            return View(Details);
        }

        public ActionResult ApplyAprrove(int InstanceId,int StepId)
        {
       
           var StepDetails=  workFlowStepService.GetList(m=>m.StepId==StepId).FirstOrDefault();
            //审批
           IQueryable<UserInfo> userinfoList = userinfoservice.GetList(m => m.IsDeleted == false);
           //ViewData["selectList"] = new SelectList(userinfoList, "UserId", "UserName",);
           ViewData["InstanceId"] = InstanceId;
           return View(StepDetails);
        }

        [HttpPost]
        public ActionResult ApplyAprrove()
        {
            int StepId=Convert.ToInt32( Request.Form["StepId"]);
            int InstanceId=Convert.ToInt32( Request.Form["InstanceId"]);

            string Result = "no";
            var Step = workFlowStepService.GetList(m => m.StepId == StepId).FirstOrDefault();
            //判断下一审批人是否为0和是否同意
            //如果为0 state=Approl -->end
            int Comment=int.Parse( Request.Form["Comment"]);
            string Remark=Request.Form["Remark"];
            int NextId = int.Parse(Request.Form["NextId"]);

            WorkFlowStep wfs = workFlowStepService.GetById(StepId);
            wfs.IsOver = true;
            //无下一审批人
            if (NextId == 0)
            {
                //同意
                if(Comment!=0)
                {
                    //开启工作流 
                      Activity activity = new ApplyExpense();
                   string guid=Step.WorkFlowInstance.InstanceGuid;
                   WorkFlowHelper.Resume(activity, Guid.Parse(guid), "approve", true);
                    Step.WorkFlowInstance.InstanceState = Convert.ToInt32(InstanceState.State.End);

                }
                    //驳回
                else
                {
                    Activity activity = new ApplyExpense();
                    string guid = Step.WorkFlowInstance.InstanceGuid;
                    WorkFlowHelper.Resume(activity, Guid.Parse(guid), "approve", false);
                    Step.WorkFlowInstance.InstanceState = Convert.ToInt32(InstanceState.State.Reject);

                }

            }
            //有下一审批人
            else
            {


            }
            //新增Step
            if(workFlowStepService.Add(new WorkFlowStep() { 
            Remark=Remark,
            SubBy=CurrentLoginUserInfo.UserId,
            SubTime=DateTime.Now,
            NextId=NextId,
            InstanceId = InstanceId,
            Comment=Convert.ToBoolean(Comment),
            IsOver=false
           
            

            })&&workFlowStepService.Edit(wfs))
            {
                 Result = "ok";
            }

            return Content(Result);
            

        }


	}
}