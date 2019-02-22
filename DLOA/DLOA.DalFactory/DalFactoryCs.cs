using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLOA.IDAL;
using DLOA.DAL;
using System.Reflection;
using System.Configuration;

namespace DLOA.DalFactory
{
    public partial class DalFactoryCs
    {
        //简单工厂
        public static IUserInfoDal GetUserInfoDal ()
        {
            return new UserInfoDal();
        }

        //抽象工厂
        public static IUserInfoDal GetUserInfoDalAbstract()
        {

            //从配置文件读取程序集的名字和实例的名字
            string s= ConfigurationManager.AppSettings["UserInfoDal"];
            string assembly = s.Split(',')[0];
            string instance = s.Split(',')[1];
            //创建程序集
            Assembly a1 = Assembly.Load(assembly);

            //创建实例
            return a1.CreateInstance(instance) as IUserInfoDal;

        }
    }
}
