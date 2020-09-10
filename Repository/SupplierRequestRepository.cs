using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WrokFlowWeb.Database;
using WrokFlowWeb.Repository.Interface;
using WrokFlowWeb.Services.Interface;
using WrokFlowWeb.ViewModel.CategoryMaster;

namespace WrokFlowWeb.Repository
{
    public class SupplierRequestRepository: ISupplierRequestRepository
    {
        private readonly WrokFlowWebEntityContext context;

        public SupplierRequestRepository(WrokFlowWebEntityContext dbContext)
        {
            this.context = dbContext;
        }

        public void AddSupplierRequest(Database.SupplierRequest supplierRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<Database.SupplierRequest> GetSupplierRequest(long id)
        {
            return await context.SupplierRequest.Where(x=>x.SupplierRequestId == id).Include(x => x.SuplierTypeRequest).Include(x => x.RequestTypeMaster).Include(x => x.SupplierRequestCategoryMapping).ThenInclude(x => x.CategoryMaster).FirstOrDefaultAsync();
        }

        public async Task<List<Database.SupplierRequest>> GetSupplierRequests()
        {
            return await context.SupplierRequest.Include(x=>x.SuplierTypeRequest).Include(x=>x.RequestTypeMaster).Include(x=>x.SupplierRequestCategoryMapping).ThenInclude(x=>x.CategoryMaster).ToListAsync();
        }

        public async Task<List<Database.SuplierTypeRequestMaster>> GetSupplierTypeRequestMaster()
        {
            return await context.SuplierTypeRequestMaster.ToListAsync();
            
        }

        public async Task<List<Database.RequestTypeMaster>> GetRequestTypeMaster()
        {
            return await context.RequestTypeMaster.ToListAsync();
        }

        public Task<List<SupplierRequest>> GetSupplierRequestMaster()
        {
            throw new NotImplementedException();
        }

        public void  Add(SupplierRequest supplierRequest)
        {
            context.SupplierRequest.Add(supplierRequest);
        }

        public async Task<List<Database.CategoryMaster>> GetCategoryMaster()
        {
            return await context.CategoryMaster.Where(x=>x.IsActive).ToListAsync();
        }

        public Task<long> Add(CategoryMasterViewModel categoryMasterView)
        {
            throw new NotImplementedException();
        }
    }
}
