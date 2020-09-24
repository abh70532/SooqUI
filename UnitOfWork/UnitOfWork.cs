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
        private ISupplierCategoryMappingRepository _supplierCategoryMappingRepository;
        private ICategoryMasterRepository _categoryMasterRepository;
        private ISupplierRequestApprovalLogRepository _supplierRequestApprovalLog;
        private IRoleApprovalMasterRepository _roleApprovalMasterRepository;
        private IUserRepository _userRepository;
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

        public ICategoryMasterRepository CategoryMasterRepository
        {
            get
            {
                if (this._categoryMasterRepository == null)
                {
                    this._categoryMasterRepository = new CategoryMasterRepository(dbContext);
                }
                return this._categoryMasterRepository;
            }
        }

        public ISupplierCategoryMappingRepository SupplierCategoryMappingRepository
        {
            get
            {
                if (this._supplierCategoryMappingRepository == null)
                {
                    this._supplierCategoryMappingRepository = new SupplierRequestCategoryMappingRepository(dbContext);
                }
                return this._supplierCategoryMappingRepository;
            }
        }

        public ISupplierRequestApprovalLogRepository SupplierRequestApprovalLog
        {
            get
            {
                if (this._supplierRequestApprovalLog == null)
                {
                    this._supplierRequestApprovalLog = new SupplierRequestApprovalLogRepository(dbContext);
                }
                return this._supplierRequestApprovalLog;
            }
        }

        public IRoleApprovalMasterRepository RoleApprovalMasterRepository
        {
            get
            {
                if (this._roleApprovalMasterRepository == null)
                {
                    this._roleApprovalMasterRepository = new RoleApprovalMasterRepository(dbContext);
                }
                return this._roleApprovalMasterRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (this._userRepository == null)
                {
                    this._userRepository = new UserRepository(dbContext);
                }
                return this._userRepository;
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
