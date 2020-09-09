using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using WrokFlowWeb.Database;
using WrokFlowWeb.Services.Interface;
using WrokFlowWeb.UnitOfWork;
using WrokFlowWeb.ViewModel;

namespace WrokFlowWeb.Services
{
    public class SupplierRequestService: ISupplierRequestService
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

        public SupplierRequest GetSupplierRequest(long id)
        {
            throw new NotImplementedException();
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
    }
}
