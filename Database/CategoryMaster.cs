using System;
using System.Collections.Generic;

namespace WrokFlowWeb.Database
{
    public partial class CategoryMaster
    {
        public byte CategoryMasterId { get; set; }
        public string Category { get; set; }
        public bool? IsActive { get; set; }
    }
}
