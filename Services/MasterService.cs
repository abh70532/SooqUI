using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.Database;
using WrokFlowWeb.Services.Interface;
using WrokFlowWeb.UnitOfWork;
using WrokFlowWeb.ViewModel.CategoryMaster;

namespace WrokFlowWeb.Services
{
    public class MasterService : IMasterService
    {
        private readonly IUnitOfWork _context;
        public MasterService(IUnitOfWork Context)
        {
            this._context = Context;
        }

        public async Task<int> AddCategory(CategoryMasterViewModel categoryMasterViewModel)
        {
            this._context.CategoryMasterRepository.Add(new Database.CategoryMaster()
            {
                Category = categoryMasterViewModel.Category,
                Description = categoryMasterViewModel.Description
            });
           return await this._context.CompleteAsync();
        }

        public async Task<int> UpdateCategory(CategoryMasterViewModel categoryMasterViewModel)
        {
            var response =  await this._context.CategoryMasterRepository.GetCategoryById(categoryMasterViewModel.CategoryMasterId);
            response.Category = categoryMasterViewModel.Category;
            response.Description = categoryMasterViewModel.Description;
            this._context.CategoryMasterRepository.Update(response);
            return await this._context.CompleteAsync();
        }

        public async Task<CategoryMaster> GetCategoryById(int categoryid) => await this._context.CategoryMasterRepository.GetCategoryById(categoryid);

    }    
}
