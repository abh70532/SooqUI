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
    }
}
