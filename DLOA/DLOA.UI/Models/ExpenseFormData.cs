using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DLOA.UI.Models
{
    public class ExpenseFormData
    {
        public string InstanceTitle { get; set; }
        public string Reason { get; set; }
        public int Money { get; set; }
        public int NextId { get; set; }

    }
}