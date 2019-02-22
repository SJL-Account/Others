using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.Net
{
    public class UserInfoService : IUserInfoService
    {
        public string ShowMsg()
        {
            return "Hello world";
        }
    }
}
