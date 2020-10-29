using System;
using System.Collections.Generic;

namespace WrokFlowWeb.Database
{
    public partial class ControlMaster
    {
        public ControlMaster()
        {
            QuestionMaster = new HashSet<QuestionMaster>();
        }

        public int ControlMasterId { get; set; }
        public string ControlName { get; set; }
        public bool? IsDataSource { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<QuestionMaster> QuestionMaster { get; set; }
    }
}
