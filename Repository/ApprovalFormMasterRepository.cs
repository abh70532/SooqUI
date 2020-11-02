using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.Database;
using WrokFlowWeb.Repository.Interface;

namespace WrokFlowWeb.Repository
{
    public class ApprovalFormMasterRepository: IApprovalFormMasterRepository
    {
        private readonly WrokFlowWebEntityContext context;
        public ApprovalFormMasterRepository(WrokFlowWebEntityContext dbContext)
        {
            this.context = dbContext;
        }

        public async Task<List<ApprovalFormMaster>> GetAllApprovalModules()
        {
            return await this.context.ApprovalFormMaster.Where(x => x.IsActive.Value).ToListAsync();
        }
    }
}
