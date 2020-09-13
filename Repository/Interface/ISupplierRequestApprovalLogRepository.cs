using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.Database;

namespace WrokFlowWeb.Repository.Interface
{
    public interface ISupplierRequestApprovalLogRepository
    {
        void Add(List<SupplierRequestApprovalLog> supplierRequestApprovalLogs);
        Task<SupplierRequestApprovalLog> GetApprovalLogById(int supplierRequestApprovalId);
        void Update(SupplierRequestApprovalLog supplierRequestApprovalLog);
        Task<List<SupplierRequestApprovalLog>> GetApprovalLogBySupplierRequestId(long supplierRequestId);
        Task<List<SupplierRequestApprovalLog>> GetApprovedLogBySupplierRequestId(long supplierRequestId);
    }
}
