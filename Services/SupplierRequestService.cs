using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using WrokFlowWeb.Database;
using WrokFlowWeb.Services.Interface;
using WrokFlowWeb.UnitOfWork;
using WrokFlowWeb.ViewModel;
using WrokFlowWeb.ViewModel.CategoryMaster;

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
                ContactPhone = model.ContactPhone };
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
    }
}
