using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WrokFlowWeb.Repository.Interface
{
    public interface IUserRepository
    {
        Task<List<Database.AspNetUsers>> GetExternalUsers();
        Task<List<Database.AspNetUsers>> GetUserListByIds(List<long> id);
        void UpdateAll(List<Database.AspNetUsers> aspNetUsers);
    }
}
