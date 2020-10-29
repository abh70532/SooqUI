using System;
using System.Collections.Generic;

namespace WrokFlowWeb.Database
{
    public partial class ApprovalFormMaster
    {
        public ApprovalFormMaster()
        {
            TabMaster = new HashSet<TabMaster>();
        }

        public int ApprovalFormMasterId { get; set; }
        public string ApprovalFormMasterName { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDelete { get; set; }

        public virtual ICollection<TabMaster> TabMaster { get; set; }
    }
}
