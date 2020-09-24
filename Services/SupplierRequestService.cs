using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using WrokFlowWeb.Database;
using WrokFlowWeb.Repository.Interface;
using WrokFlowWeb.Services.Interface;
using WrokFlowWeb.UnitOfWork;
using WrokFlowWeb.ViewModel;
using WrokFlowWeb.ViewModel.CategoryMaster;
using WrokFlowWeb.ViewModel.Role;
using WrokFlowWeb.ViewModel.SupplierRequest;
using static WrokFlowWeb.Constants.Constants;

namespace WrokFlowWeb.Services
{
    public class SupplierRequestService: ISupplierRequestService, ICategoryMasterService
    {
        private readonly IUnitOfWork _context;
        public SupplierRequestService(IUnitOfWork Context)
        {
            this._context = Context;
        }

        public async Task<long> Add(SupplierViewModel model)
        {
            var request = new SupplierRequest()
            {
                SuplierTypeRequestId = model.SuplierTypeRequestId,
                RequestTypeMasterId = model.RequestTypeMasterId,
                RequesterName = model.RequesterName,
                Department = model.Department,
                SupplierName = model.SupplierName,
                Street = model.Street,
                Address1 = model.Address1,
                Address2 = model.Address2,
                City = model.City,
                PostalCode = model.PostalCode,
                Country = model.Country,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailId = model.EmailId,
                ContactPhone = model.ContactPhone ,
                IsApprovalPending = true,
            CreatedBy = model.CreatedBy};
            this._context.SupplierRequest.Add(request);
            await this._context.CompleteAsync();
            var categoryMaster = new List<SupplierRequestCategoryMapping>();
            foreach (var item in model.CategoryMaster)
            {
                if (item.IsSelected)
                    categoryMaster.Add(new SupplierRequestCategoryMapping() {
                        SupplierRequestId = request.SupplierRequestId,
                         CategoryMasterId = item.CategoryMasterId
                    }); ;
            }
            this._context.SupplierCategoryMappingRepository.Add(categoryMaster);
            await this._context.CompleteAsync();

            var roleApprovalList = await GetRoleApprovalMasterList(1);
            var roleApprovals = new List<SupplierRequestApprovalLog>();
            foreach (var item in roleApprovalList)
            {
                roleApprovals.Add(new SupplierRequestApprovalLog() {
                     SupplierRequestId = request.SupplierRequestId,
                    RoleApprovalMasterId = item.RoleApprovalMasterId,
                    OrderBy = item.OrderBy
                    
                });
            }
            this._context.SupplierRequestApprovalLog.Add(roleApprovals);
            await this._context.CompleteAsync();
            request.SupplierRequestApprovalId = roleApprovals.Where(x=>!x.IsApproved.GetValueOrDefault()).OrderBy(x => x.OrderBy).FirstOrDefault().SupplierRequestApprovalId;
            this._context.SupplierRequest.Update(request);
            await this._context.CompleteAsync();
            return  request.SupplierRequestId; 
        }

        public void AddSupplierRequest(SupplierRequest supplierRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RequestTypeMaster>> GetRequestTypeMaster()
        {
            return await this._context.SupplierRequest.GetRequestTypeMaster();

        }

       

        public async Task<List<SupplierRequest>> GetSupplierRequestMaster()
        {
            return await this._context.SupplierRequest.GetSupplierRequestMaster();
        }

        public async Task<List<SupplierRequest>> GetSupplierRequests()
        {
          return await  this._context.SupplierRequest.GetSupplierRequests();
        }

        public async Task<List<SuplierTypeRequestMaster>> GetSupplierTypeRequestMaster()
        {
            return await this._context.SupplierRequest.GetSupplierTypeRequestMaster();
        }

        public async Task<List<CategoryMasterViewModel>> GetCategoryMaster()
        {
            var response = new List<CategoryMasterViewModel>();
            var category = await this._context.SupplierRequest.GetCategoryMaster();
            foreach (var item in category)
            {
                response.Add(new CategoryMasterViewModel()
                {
                     Category = item.Category,
                     CategoryMasterId = item.CategoryMasterId
                });
            }
            return response;
        }

        Task<long> ICategoryMasterService.Add(CategoryMasterViewModel categoryMasterView)
        {
            throw new NotImplementedException();
        }

        public async Task<SupplierRequest> GetSupplierRequest(long id)
        {
            return await this._context.SupplierRequest.GetSupplierRequest(id);
        }

        public async Task<List<RoleApprovalMaster>> GetRoleApprovalMasterList(long moduleId)
        {
            return await this._context.RoleApprovalMasterRepository.GetRoleApprovalMasterList(moduleId);
        }

        public  List<InboxListViewModel> GetInboxList(string emailid)
        {
            var resposnse =   this._context.SupplierRequest.GetInboxList(emailid);
            var inboxList = new List<InboxListViewModel>();

            foreach (DataRow item in resposnse.Result.Tables[0].Rows)
            {
                inboxList.Add(new InboxListViewModel()
                {  RequestId = Convert.ToInt64(item["RequestId"]),
                    ModuleId = Convert.ToInt64(item["ModuleId"]),
                    ModuleName = item["ModuleName"].ToString()
                });
            }
            return inboxList;
        }

        public void Approve(long requestid, long moduleid)
        {
            switch (moduleid)
            {
                case (long)Module.SupplierRequest:

                default:
                    break;
            }
        }

        public async Task<SupplierRequestApprovalLog> GetApprovalLogById(int supplierRequestApprovalId)
        {
            return await this._context.SupplierRequestApprovalLog.GetApprovalLogById(supplierRequestApprovalId);
        }

        public async Task ApproveUpdate(RequestApprovalViewModel requestApprovalViewModel, string user)
        {
            var supplierRequest = await this._context.SupplierRequest.GetSupplierRequest(requestApprovalViewModel.InboxListViewModel.RequestId);
            var approvalLog = await this._context.SupplierRequestApprovalLog.GetApprovalLogById(supplierRequest.SupplierRequestApprovalId.GetValueOrDefault());
            approvalLog.IsApproved = requestApprovalViewModel.Approve.ToUpper() == "APPROVE";
            approvalLog.ApprovalComments = requestApprovalViewModel.Comments;
            approvalLog.ApprovedOn = DateTime.Now;
            approvalLog.ApprovedBy = user;
            this._context.SupplierRequestApprovalLog.Update(approvalLog);
            await this._context.CompleteAsync();
            var approvalLogList = await this._context.SupplierRequestApprovalLog.GetApprovalLogBySupplierRequestId(approvalLog.SupplierRequestId);
            supplierRequest.SupplierRequestApprovalId = approvalLogList.Where(x => !x.IsApproved.GetValueOrDefault()).OrderBy(x => x.OrderBy).FirstOrDefault()?.SupplierRequestApprovalId;
            if (!approvalLog.IsApproved.GetValueOrDefault())
            {
                supplierRequest.IsRejected = true;
                supplierRequest.IsApprovalPending = false;
                supplierRequest.SupplierRequestApprovalId = null;
            }

            if (supplierRequest.SupplierRequestApprovalId == null || supplierRequest.SupplierRequestApprovalId == 0)
            {
                supplierRequest.SupplierRequestApprovalId = null;
                supplierRequest.IsApprovalPending = false;
            }
            this._context.SupplierRequest.Update(supplierRequest);
            await this._context.CompleteAsync();
        }

        public async Task<List<SupplierRequestApprovalLog>> GetApprovedLogBySupplierRequestId(long supplierRequestId)
        {
           return await this._context.SupplierRequestApprovalLog.GetApprovedLogBySupplierRequestId(supplierRequestId);
         }

        public async Task<List<AspNetUsers>> GetExternalUsers()
        {
            return await this._context.UserRepository.GetExternalUsers();
        }

        public async Task<SupplierUserMappingViewModel> GetSUpplierUserMappingViewModel()
        {
            SupplierUserMappingViewModel supplierUserMappingViewModel = new SupplierUserMappingViewModel();
            List<UserViewModel> userViewModel = new List<UserViewModel>();
            List<SuppilerListViewModel> suppilerListViewModels = new List<SuppilerListViewModel>();
            var user = await this._context.UserRepository.GetExternalUsers();
            foreach (var item in user)
            {
                userViewModel.Add(new UserViewModel() { 
                     Email = item.Email,
                     Userid = item.UserId
                });
            }
            supplierUserMappingViewModel.UserViewModels = userViewModel;
            var supplier = await this._context.SupplierRequest.GetSupplierRequestMaster();
            foreach (var item in supplier)
            {
                suppilerListViewModels.Add(new SuppilerListViewModel()
                {
                     SupplierRequestId = item.SupplierRequestId,
                     SupplierName = string.Join('-',item.SupplierName,item.SupplierRequestId)
                });
            }
            supplierUserMappingViewModel.SuppilerListViewModel = suppilerListViewModels;
            return supplierUserMappingViewModel;
        }


        public async Task PostMapUserSupplier(SupplierUserMappingViewModel supplierUserMappingViewModel, string user)
        {
            var userList =  await this._context.UserRepository.GetUserListByIds(supplierUserMappingViewModel.UserViewModels.Where(x=>x.IsSelected).Select(x=>x.Userid).ToList());
            userList.ForEach(item =>
            {
                item.SupplierRequestId = supplierUserMappingViewModel.SelectedSupplierId;
             
            });
            this._context.UserRepository.UpdateAll(userList);
            await this._context.CompleteAsync();
        }
    }
}
