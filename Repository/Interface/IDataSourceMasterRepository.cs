using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.Database;

namespace WrokFlowWeb.Repository.Interface
{
    public interface IDataSourceMasterRepository
    {
        Task<List<DataSourceMaster>> GetAllDataSource();
        //Task<List<DataSourceMaster>> GetAllDataSourceBySourceid(int sourceId);
        Task<List<SourceMaster>> GetAllDataSourceBySourceid(int sourceId);
    }
}
