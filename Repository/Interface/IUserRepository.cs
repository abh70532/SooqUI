using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WrokFlowWeb.Repository.Interface
{
    public interface IUserRepository
    {
        Task<Database.AspNetUsers> GetSupplierRequest(long id);
    }
}
