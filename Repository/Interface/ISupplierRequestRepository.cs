using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.Database;
using WrokFlowWeb.ViewModel;

namespace WrokFlowWeb.Repository.Interface
{
   public interface ISupplierRequestRepository
    {
        void AddSupplierRequest(SupplierRequest supplierRequest);
        Task<Database.SupplierRequest> GetSupplierRequest(long id);
        Task<List<Database.SupplierRequest>> GetSupplierRequests();
        Task<List<Database.SuplierTypeRequestMaster>> GetSupplierTypeRequestMaster();
        Task<List<Database.SupplierRequest>> GetSupplierRequestMaster();
        Task<List<Database.RequestTypeMaster>> GetRequestTypeMaster();
        void Add(SupplierRequest supplierRequest);
        void Update(SupplierRequest supplierRequest);
        Task<List<Database.CategoryMaster>> GetCategoryMaster();
        Task<DataSet> GetInboxList(string emailid);
        Task<List<SupplierRequest>> FetchSupplierReport(SupplierReportViewModel supplierReportViewModel);
    }
}
