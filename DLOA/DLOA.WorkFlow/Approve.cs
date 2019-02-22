using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace DLOA.WorkFlow
{

    public sealed class Approve : NativeActivity
    {

        public OutArgument<bool> Comment { get; set; }

   

        protected override void Execute(NativeActivityContext context)
        {
            Console.WriteLine("工作流已静止");
            Bookmark bookmark = context.CreateBookmark("approve", Func);

        }

        private void Func(NativeActivityContext context, Bookmark bookmark, object value)
        {
            Console.WriteLine("工作流已启动");

            context.SetValue(Comment,Convert.ToBoolean(value));

   }
        protected override bool CanInduceIdle
        {
            get
            {
                return true;
            }
        }
    }
}
