﻿using Microsoft.EntityFrameworkCore;
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
            return await this.context.AspNetUsers.Where(x => x.UserType == 2).ToListAsync();
        }

        public async Task<List<AspNetUsers>> GetUserListByIds(List<string> id)
        {
            return await context.AspNetUsers.Where(x => id.Contains(x.Id)).ToListAsync();
        }

        public void UpdateAll(List<AspNetUsers> aspNetUsers)
        {
            context.AspNetUsers.UpdateRange(aspNetUsers);
        }

        public void Updateuser(AspNetUsers aspNetUsers)
        {
            context.AspNetUsers.Update(aspNetUsers);
        }

        public async Task<List<AspNetUsers>> GetAllUsers(String search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                return await this.context.AspNetUsers.Include(x => x.SupplierRequest).Where(x => x.Email.Contains(search)
            || x.PhoneNumber.Contains(search) || x.Department.Contains(search) || x.SupplierRequest.SupplierName.Contains(search)
            || x.SupplierRequest.SupplierRequestId.ToString().Contains(search)).ToListAsync();
            }
            else
            {
                return await this.context.AspNetUsers.Include(x=>x.SupplierRequest).ToListAsync();
            }
            
        }

        public async Task<AspNetUsers> GetUserListById(string id) => await context.AspNetUsers.Where(x => x.Id == id).FirstOrDefaultAsync();
    }
}
