using System;
using System.Collections.Generic;

namespace WrokFlowWeb.Database
{
    public partial class SuplierTypeRequestMaster
    {
        public SuplierTypeRequestMaster()
        {
            SupplierRequest = new HashSet<SupplierRequest>();
        }

        public byte SuplierTypeRequestId { get; set; }
        public string SuplierTypeRequest { get; set; }

        public virtual ICollection<SupplierRequest> SupplierRequest { get; set; }
    }
}
