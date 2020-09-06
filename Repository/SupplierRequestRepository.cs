using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WrokFlowWeb.Database;
using WrokFlowWeb.Repository.Interface;

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

        public Database.SupplierRequest GetSupplierRequest(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Database.SupplierRequest>> GetSupplierRequests()
        {
            return await context.SupplierRequest.Include(x=>x.SuplierTypeRequest).Include(x=>x.RequestTypeMaster).ToListAsync();
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
    }
}
