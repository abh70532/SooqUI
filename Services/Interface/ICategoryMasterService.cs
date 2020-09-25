using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.Database;
using WrokFlowWeb.ViewModel.CategoryMaster;

namespace WrokFlowWeb.Services.Interface
{
   public interface ICategoryMasterService
    {
        Task<long> Add(CategoryMasterViewModel categoryMasterView);
        Task<List<CategoryMasterViewModel>> GetAllCategories();
    }
}
