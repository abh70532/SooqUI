using System;
using System.Collections.Generic;

namespace WrokFlowWeb.Database
{
    public partial class CategoryMaster
    {
        public CategoryMaster()
        {
            SupplierRequestCategoryMapping = new HashSet<SupplierRequestCategoryMapping>();
        }

        public byte CategoryMasterId { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<SupplierRequestCategoryMapping> SupplierRequestCategoryMapping { get; set; }
    }
}
