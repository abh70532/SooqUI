using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.Database;
using WrokFlowWeb.Repository;
using WrokFlowWeb.Repository.Interface;

namespace WrokFlowWeb.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WrokFlowWebEntityContext dbContext;
        public UnitOfWork(WrokFlowWebEntityContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private ISupplierRequestRepository _supplierRequest;
        public ISupplierRequestRepository SupplierRequest
        {
            get
            {
                if (this._supplierRequest == null)
                {
                    this._supplierRequest = new SupplierRequestRepository(dbContext);
                }
                return this._supplierRequest;
            }
        }

        public int Complete()
        {
            return dbContext.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

     

        public void Dispose() => dbContext.Dispose();
    }
}
