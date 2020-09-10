using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.Database;
using WrokFlowWeb.Repository.Interface;

namespace WrokFlowWeb.Repository
{
    public class SupplierRequestCategoryMappingRepository : ISupplierCategoryMappingRepository
    {
        private readonly WrokFlowWebEntityContext context;

        public SupplierRequestCategoryMappingRepository(WrokFlowWebEntityContext dbContext)
        {
            this.context = dbContext;
        }
        public void Add(List<SupplierRequestCategoryMapping> supplierRequestCategoryMapping)
        {
            context.SupplierRequestCategoryMapping.AddRange(supplierRequestCategoryMapping);
        }
    }
}
