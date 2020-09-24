using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.ViewModel.SupplierRequest;

namespace WrokFlowWeb.ViewModel.Role
{
    public class SupplierUserMappingViewModel
    {
        public List<UserViewModel> UserViewModels { get; set; }

        public List<SuppilerListViewModel> SuppilerListViewModel { get; set; }


        [Required]
        [DisplayName("Supplier")]
        public long SelectedSupplierId { get; set; }
        [Required]
        [DisplayName("Users")]
        public List<long> SelectedUsers { get; set; }
    }
}
