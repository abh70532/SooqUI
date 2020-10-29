using System;
using System.Collections.Generic;

namespace WrokFlowWeb.Database
{
    public partial class TabMaster
    {
        public TabMaster()
        {
            QuestionMaster = new HashSet<QuestionMaster>();
        }

        public int TabMasterId { get; set; }
        public int ApprovalFormMasterId { get; set; }
        public string TabMasterName { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDelete { get; set; }

        public virtual ApprovalFormMaster ApprovalFormMaster { get; set; }
        public virtual ICollection<QuestionMaster> QuestionMaster { get; set; }
    }
}
