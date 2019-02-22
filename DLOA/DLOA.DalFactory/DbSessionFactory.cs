using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLOA.IDAL;
using System.Runtime.Remoting.Messaging;
namespace DLOA.DalFactory
{
    public partial class DbSessionFactory
    {
        /// <summary>
        /// 创建唯一的Session对话
        /// </summary>
        /// <returns></returns>
        public static IDbSession GetDbSession()
        {

            IDbSession session = CallContext.GetData("DbSession") as IDbSession;
            if(session==null)
            {
                session = new DbSession();

            }
            return session; 
        }
    }
}
