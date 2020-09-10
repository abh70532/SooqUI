using System;
using System.Collections.Generic;

namespace WrokFlowWeb.Database
{
    public partial class SupplierRequestCategoryMapping
    {
        public byte SupplierRequestCategoryMappingId { get; set; }
        public long? SupplierRequestId { get; set; }
        public byte? CategoryMasterId { get; set; }

        public virtual CategoryMaster CategoryMaster { get; set; }
        public virtual SupplierRequest SupplierRequest { get; set; }
    }
}
