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
        private IControlMasterRepository _controlMasterRepository;
        private IDataSourceMasterRepository _dataSourceRepository;
        private ITabMasterRepository _tabMasterRepository;
        private IQuestionMasterRepository _questionMasterRepository;
        private IApprovalFormMasterRepository _approvalFormMasterRepository;

        public IApprovalFormMasterRepository ApprovalFormMasterRepository
        {
            get
            {
                if (this._approvalFormMasterRepository == null)
                {
                    this._approvalFormMasterRepository = new ApprovalFormMasterRepository(dbContext);
                }
                return this._approvalFormMasterRepository;
            }
        }

        public IQuestionMasterRepository QuestionMasterRepository
        {
            get
            {
                if (this._questionMasterRepository == null)
                {
                    this._questionMasterRepository = new QuestionMasterRepository(dbContext);
                }
                return this._questionMasterRepository;
            }
        }

        public ITabMasterRepository TabMasterRepository
        {
            get
            {
                if (this._tabMasterRepository == null)
                {
                    this._tabMasterRepository = new TabMasterRepository(dbContext);
                }
                return this._tabMasterRepository;
            }
        }

        public IControlMasterRepository ControlMasterRepository
        {
            get
            {
                if (this._controlMasterRepository == null)
                {
                    this._controlMasterRepository = new ControlMasterRepository(dbContext);
                }
                return this._controlMasterRepository;
            }
        }

        public IDataSourceMasterRepository DataSourceMasterRepository
        {
            get
            {
                if (this._dataSourceRepository == null)
                {
                    this._dataSourceRepository = new DataSourceMasterRepository(dbContext);
                }
                return this._dataSourceRepository;
            }
        }

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
