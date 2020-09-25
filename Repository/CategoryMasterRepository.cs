﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.Database;
using WrokFlowWeb.Repository.Interface;

namespace WrokFlowWeb.Repository
{
    public class CategoryMasterRepository : ICategoryMasterRepository
    {
        private readonly WrokFlowWebEntityContext context;

        public CategoryMasterRepository(WrokFlowWebEntityContext dbContext)
        {
            this.context = dbContext;
        }
        public void Add(CategoryMaster categoryMaster)
        {
            context.CategoryMaster.Add(categoryMaster);
        }

        public async Task<List<CategoryMaster>> GetAllCategories()
        {
            return await this.context.CategoryMaster.Where(x=>x.IsActive).ToListAsync();
        }
    }
}
