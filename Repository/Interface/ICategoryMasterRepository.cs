using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.Database;

namespace WrokFlowWeb.Repository.Interface
{
    public interface ICategoryMasterRepository
    {
        void Add(CategoryMaster categoryMaster);
        Task<List<CategoryMaster>> GetAllCategories();
        Task<CategoryMaster> GetCategoryById(int categoryid);
        void Update(CategoryMaster categoryMaster);
    }
}
