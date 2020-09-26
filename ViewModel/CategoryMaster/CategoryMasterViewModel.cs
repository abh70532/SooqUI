using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WrokFlowWeb.ViewModel.CategoryMaster
{
    public class CategoryMasterViewModel
    {
        public byte CategoryMasterId { get; set; }

        [Required]
        [DisplayName("Category")]
        public string Category { get; set; }
        public string Description { get; set; }
        public bool IsSelected { get; set; }
    }
}
