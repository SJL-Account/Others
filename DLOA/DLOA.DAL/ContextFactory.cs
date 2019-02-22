using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;
using DLOA.Model;
namespace DLOA.DAL
{
    public partial class ContextFactory
    {
        public static DbContext  CreateContext()
        {

            DbContext context = CallContext.GetData("OAContainer") as DbContext;

            if(context==null)
            {
                context = new DLOAContainer();
                CallContext.SetData("OAContainer", context);
            }
            return context;
        }

    }
}
