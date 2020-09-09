using System.Collections.Generic;

namespace WrokFlowWeb.ViewModel.SupplierRequest
{
    public class SupplierRequestListViewModel
    {
        public long SupplierRequestId { get; set; }

        public List<WrokFlowWeb.Database.SupplierRequest> SupplierRequests { get; set; }
    }
}
