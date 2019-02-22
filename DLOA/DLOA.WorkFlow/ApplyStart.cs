using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace DLOA.WorkFlow
{

    public sealed class ApplyStart : CodeActivity
    {
        // 定义一个字符串类型的活动输入参数
        public InArgument<string> Reason { get; set; }
        public InArgument<int> Money { get; set; }





         //如果活动返回值，则从 CodeActivity<TResult>
         //派生并从 Execute 方法返回该值。
        protected override void Execute(CodeActivityContext context)
        {
            //Console.WriteLine("请输入报销理由");
            //string reason = Console.ReadLine();

            //context.SetValue(Reason,reason);


            //Console.WriteLine("请输入报销金额");
            //string money = Console.ReadLine();

            Console.WriteLine("原因为：{0}，金额：{1}",context.GetValue(Reason),context.GetValue(Money));
            //context.SetValue(Money, int.Parse(money));

        }
        //override子类具体实现方法
        //new 则隐藏，over重写，隐藏看类型，重写只管新
        //protected override void Execute(NativeActivityContext context)
        //{

        //    Bookmark bookmark = new Bookmark("");
        //}
    }
}
