using System;
using System.Collections.Generic;

namespace WrokFlowWeb.Database
{
    public partial class SourceMaster
    {
        public long SourceMasterId { get; set; }
        public int DataSourceMasterId { get; set; }
        public string Text { get; set; }
        public bool? IsActive { get; set; }

        public virtual DataSourceMaster DataSourceMaster { get; set; }
    }
}
