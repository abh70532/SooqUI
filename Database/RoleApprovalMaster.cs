using System;
using System.Collections.Generic;

namespace WrokFlowWeb.Database
{
    public partial class RoleApprovalMaster
    {
        public byte RoleApprovalMasterId { get; set; }
        public string RoleId { get; set; }
        public byte ModuleId { get; set; }
        public byte OrderBy { get; set; }

        public virtual AspNetRoles Role { get; set; }
    }
}
