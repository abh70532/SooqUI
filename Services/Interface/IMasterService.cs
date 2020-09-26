using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.Database;
using WrokFlowWeb.ViewModel.CategoryMaster;

namespace WrokFlowWeb.Services.Interface
{
    public interface IMasterService
    {
        Task<int> AddCategory(CategoryMasterViewModel categoryMasterViewModel);
        Task<CategoryMaster> GetCategoryById(int categoryid);
        Task<int> UpdateCategory(CategoryMasterViewModel categoryMasterViewModel);
    }
}
