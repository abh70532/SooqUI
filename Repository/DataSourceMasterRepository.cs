using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.Database;
using WrokFlowWeb.Repository.Interface;

namespace WrokFlowWeb.Repository
{
    public class DataSourceMasterRepository:IDataSourceMasterRepository
    {
        private readonly WrokFlowWebEntityContext context;
        public DataSourceMasterRepository(WrokFlowWebEntityContext dbContext)
        {
            this.context = dbContext;
        }

        public async Task<List<DataSourceMaster>> GetAllDataSource()
        {
            return await this.context.DataSourceMaster.Where(x => x.IsActive.Value).ToListAsync();
        }

        public async Task<List<SourceMaster>> GetAllDataSourceBySourceid(int sourceId)
        {
            return await this.context.SourceMaster.Where(x => x.IsActive.Value && x.DataSourceMasterId == sourceId).ToListAsync();
        }
    }
}
