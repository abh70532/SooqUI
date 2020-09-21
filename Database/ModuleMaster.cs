using System;
using System.Collections.Generic;

namespace WrokFlowWeb.Database
{
    public partial class ModuleMaster
    {
        public ModuleMaster()
        {
            RoleApprovalMaster = new HashSet<RoleApprovalMaster>();
        }

        public byte ModuleId { get; set; }
        public string ModuleName { get; set; }

        public virtual ICollection<RoleApprovalMaster> RoleApprovalMaster { get; set; }
    }
}
