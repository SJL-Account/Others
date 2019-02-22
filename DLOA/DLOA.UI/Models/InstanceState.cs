using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DLOA.UI.Models
{
    public static class InstanceState
    {
        public enum State
        {
            Start,
            Approve,
            Reject,
            End
        }
    }
}