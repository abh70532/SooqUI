using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.Database;

namespace WrokFlowWeb.Repository.Interface
{
    public interface IUserRepository
    {
        Task<List<AspNetUsers>> GetAllUsers(String search);
        Task<List<Database.AspNetUsers>> GetExternalUsers();
        Task<AspNetUsers> GetUserListById(string id);
        Task<List<Database.AspNetUsers>> GetUserListByIds(List<string> id);
        void UpdateAll(List<Database.AspNetUsers> aspNetUsers);
        void Updateuser(AspNetUsers aspNetUsers);
    }
}
