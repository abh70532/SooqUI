using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.Database;
using WrokFlowWeb.Repository.Interface;

namespace WrokFlowWeb.Repository
{
    public class ControlMasterRepository:IControlMasterRepository
    {
        private readonly WrokFlowWebEntityContext context;
        public ControlMasterRepository(WrokFlowWebEntityContext dbContext)
        {
            this.context = dbContext;
        }
        public async Task<List<ControlMaster>> GetAllControls()
        {
            return await this.context.ControlMaster.Where(x => x.IsActive.Value).ToListAsync();
        }
    }
}
