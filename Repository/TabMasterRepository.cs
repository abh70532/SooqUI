using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.Database;
using WrokFlowWeb.Repository.Interface;

namespace WrokFlowWeb.Repository
{
    public class TabMasterRepository:ITabMasterRepository
    {
        private readonly WrokFlowWebEntityContext context;
        public TabMasterRepository(WrokFlowWebEntityContext dbContext)
        {
            this.context = dbContext;
        }

        public async Task<List<TabMaster>> GetAllTabSource()
        {
            return await this.context.TabMaster.Where(x => x.IsActive.Value).ToListAsync();
        }
    }
}
