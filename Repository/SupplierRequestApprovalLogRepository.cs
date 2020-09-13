using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.Database;
using WrokFlowWeb.Repository.Interface;

namespace WrokFlowWeb.Repository
{
    public class SupplierRequestApprovalLogRepository: ISupplierRequestApprovalLogRepository
    {

        private readonly WrokFlowWebEntityContext context;

        public SupplierRequestApprovalLogRepository(WrokFlowWebEntityContext dbContext)
        {
            this.context = dbContext;
        }

        public void Add(List<SupplierRequestApprovalLog> supplierRequestApprovalLogs)
        {
            context.SupplierRequestApprovalLog.AddRange(supplierRequestApprovalLogs);
        }

        public async Task<SupplierRequestApprovalLog> GetApprovalLogById(int supplierRequestApprovalId)
        {
           return await context.SupplierRequestApprovalLog.Where(x => x.SupplierRequestApprovalId == supplierRequestApprovalId).FirstOrDefaultAsync();
        }

        public  void Update(SupplierRequestApprovalLog supplierRequestApprovalLog)
        {
            context.SupplierRequestApprovalLog.Update(supplierRequestApprovalLog);
        }

        public async Task<List<SupplierRequestApprovalLog>> GetApprovalLogBySupplierRequestId(long supplierRequestId)
        {
            return await context.SupplierRequestApprovalLog.Where(x => x.SupplierRequestId == supplierRequestId).ToListAsync();
        }

        public async Task<List<SupplierRequestApprovalLog>> GetApprovedLogBySupplierRequestId(long supplierRequestId)
        {
            return await context.SupplierRequestApprovalLog.Where(x => x.SupplierRequestId == supplierRequestId && x.IsApproved != null).ToListAsync();
        }
    }
}
