using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.Database;
using WrokFlowWeb.ViewModel;
using WrokFlowWeb.ViewModel.CategoryMaster;
using WrokFlowWeb.ViewModel.SupplierRequest;

namespace WrokFlowWeb.Services.Interface
{
   public interface ISupplierRequestService
    {
        Task<List<SupplierRequest>> GetSupplierRequests();
        void AddSupplierRequest(SupplierRequest supplierRequest);
        Task<Database.SupplierRequest> GetSupplierRequest(long id);
        Task<List<Database.SuplierTypeRequestMaster>> GetSupplierTypeRequestMaster();
        Task<List<Database.SupplierRequest>> GetSupplierRequestMaster();
        Task<List<Database.RequestTypeMaster>> GetRequestTypeMaster();
        Task<long> Add(SupplierViewModel supplierRequest);
        Task<List<CategoryMasterViewModel>> GetCategoryMaster();
        Task<List<Database.RoleApprovalMaster>> GetRoleApprovalMasterList(long moduleId);
        List<InboxListViewModel> GetInboxList(string emailid);
        Task<SupplierRequestApprovalLog> GetApprovalLogById(int supplierRequestApprovalId);
        Task ApproveUpdate(RequestApprovalViewModel requestApprovalViewModel, string user);

    }
}
