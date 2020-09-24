using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.Database;
using WrokFlowWeb.Repository.Interface;

namespace WrokFlowWeb.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly WrokFlowWebEntityContext context;

        public UserRepository(WrokFlowWebEntityContext dbContext)
        {
            this.context = dbContext;
        }


        public async Task<List<AspNetUsers>> GetExternalUsers()
        {
            return await this.context.AspNetUsers.Where(x => x.UserType == 1).ToListAsync();
        }

        public async Task<List<AspNetUsers>> GetUserListByIds(List<string> id)
        {
            return await context.AspNetUsers.Where(x => id.Contains(x.Id)).ToListAsync();
        }

        public void UpdateAll(List<AspNetUsers> aspNetUsers)
        {
            context.AspNetUsers.UpdateRange(aspNetUsers);
        }
    }
}
