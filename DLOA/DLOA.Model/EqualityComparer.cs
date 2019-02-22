using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLOA.Model
{
    public class EqualityComparer:EqualityComparer<ActionInfo>
    {

        public override bool Equals(ActionInfo x, ActionInfo y)
        {
            return x.ActionId == y.ActionId;
        }

        public override int GetHashCode(ActionInfo obj)
        {
            return obj.GetHashCode();
        }
    }
}
