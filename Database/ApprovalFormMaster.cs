using System;
using System.Collections.Generic;

namespace WrokFlowWeb.Database
{
    public partial class ApprovalFormMaster
    {
        public int ApprovalFormMasterId { get; set; }
        public string ApprovalFormMasterName { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
