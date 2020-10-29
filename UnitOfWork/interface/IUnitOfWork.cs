using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.Repository.Interface;

namespace WrokFlowWeb.UnitOfWork
{
    public interface IUnitOfWork
    {
        ISupplierRequestRepository SupplierRequest { get; }
        ICategoryMasterRepository CategoryMasterRepository { get; }
        ISupplierCategoryMappingRepository SupplierCategoryMappingRepository { get; }
        ISupplierRequestApprovalLogRepository SupplierRequestApprovalLog { get; }
        IRoleApprovalMasterRepository RoleApprovalMasterRepository { get; }
        IControlMasterRepository ControlMasterRepository { get; }
        IDataSourceMasterRepository DataSourceMasterRepository { get; }
        ITabMasterRepository TabMasterRepository { get; }
        IUserRepository UserRepository { get; }
        IQuestionMasterRepository QuestionMasterRepository { get; }
        Task<int> CompleteAsync();
        int Complete();
    }
}
