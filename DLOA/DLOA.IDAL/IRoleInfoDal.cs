﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLOA.IDAL
{
    public partial interface IRoleInfoDal
    {
        int SetAction(int rid, int[] aids);
    }
}
