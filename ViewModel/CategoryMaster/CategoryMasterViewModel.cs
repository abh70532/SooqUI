using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WrokFlowWeb.ViewModel.CategoryMaster
{
    public class CategoryMasterViewModel
    {
        public byte CategoryMasterId { get; set; }
        public string Category { get; set; }
        public bool IsSelected { get; set; }
    }
}
