using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.Database;
using WrokFlowWeb.ViewModel;

namespace WrokFlowWeb.Services.Interface
{
   public interface ISupplierRequestService
    {
        Task<List<SupplierRequest>> GetSupplierRequests();
        void AddSupplierRequest(SupplierRequest supplierRequest);
        SupplierRequest GetSupplierRequest(long id);
        Task<List<Database.SuplierTypeRequestMaster>> GetSupplierTypeRequestMaster();
        Task<List<Database.SupplierRequest>> GetSupplierRequestMaster();
        Task<List<Database.RequestTypeMaster>> GetRequestTypeMaster();
        Task Add(SupplierViewModel supplierRequest);

    }
}
