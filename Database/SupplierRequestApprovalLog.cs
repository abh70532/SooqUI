using System;
using System.Collections.Generic;

namespace WrokFlowWeb.Database
{
    public partial class SupplierRequestApprovalLog
    {
        public int SupplierRequestApprovalId { get; set; }
        public long SupplierRequestId { get; set; }
        public bool IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedOn { get; set; }
        public string ApprovalComments { get; set; }
        public byte OrderBy { get; set; }

        public virtual SupplierRequest SupplierRequest { get; set; }
    }
}
