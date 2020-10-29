using System;
using System.Collections.Generic;

namespace WrokFlowWeb.Database
{
    public partial class QuestionMaster
    {
        public long QuestionMasterId { get; set; }
        public int TabMasterId { get; set; }
        public int ControlMasterId { get; set; }
        public int? DataSourceMasterId { get; set; }
        public string QuestionText { get; set; }
        public string DefautText { get; set; }
        public bool? IsActive { get; set; }

        public virtual ControlMaster ControlMaster { get; set; }
        public virtual DataSourceMaster DataSourceMaster { get; set; }
        public virtual TabMaster TabMaster { get; set; }
    }
}
