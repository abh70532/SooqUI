using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.ViewModel.CategoryMaster;

namespace WrokFlowWeb.Services.Interface
{
    interface ICategoryMasterService
    {
        Task<long> Add(CategoryMasterViewModel categoryMasterView);
    }
}
