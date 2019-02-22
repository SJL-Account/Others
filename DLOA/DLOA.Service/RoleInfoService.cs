using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLOA.IDAL;

namespace DLOA.Service
{
    public partial class RoleInfoService
    {
        public bool SetAction(int rid, string aids)
        {
            List<int> list1=new List<int>();
            string[] list2 = aids.Split(',');
            foreach (var item in list2)
            {
                list1.Add(int.Parse(item));
            }

            ((IRoleInfoDal) curDal).SetAction(rid, list1.ToArray());
            
            return dbsession.SaveChanges() > 0;
        }
    }
}
