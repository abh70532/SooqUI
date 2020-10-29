using System;
using System.Collections.Generic;

namespace WrokFlowWeb.Database
{
    public partial class DataSourceMaster
    {
        public DataSourceMaster()
        {
            QuestionMaster = new HashSet<QuestionMaster>();
            SourceMaster = new HashSet<SourceMaster>();
        }

        public int DataSourceMasterId { get; set; }
        public string DataSourceName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<QuestionMaster> QuestionMaster { get; set; }
        public virtual ICollection<SourceMaster> SourceMaster { get; set; }
    }
}
