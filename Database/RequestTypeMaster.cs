using System;
using System.Collections.Generic;

namespace WrokFlowWeb.Database
{
    public partial class RequestTypeMaster
    {
        public RequestTypeMaster()
        {
            SupplierRequest = new HashSet<SupplierRequest>();
        }

        public byte RequestTypeMasterId { get; set; }
        public string RequestType { get; set; }

        public virtual ICollection<SupplierRequest> SupplierRequest { get; set; }
    }
}
