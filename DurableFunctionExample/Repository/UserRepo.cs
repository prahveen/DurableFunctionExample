using DurableFunctionExample.DataContext;
using DurableFunctionExample.DataContext.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurableFunctionExample.Repository
{
    class UserRepo : IUserRepo
    {
        public UserRepo(ApplicationDbContext context)
        {
            this.Context = context;
        }

        private ApplicationDbContext Context { get; }

        public IEnumerable<User> GetAll()
        {
            var users = this.Context.User;
            return users;
        }

        public async Task<User> Add(User user)
        {
            var result = await this.Context.User.AddAsync(user);
            return result.Entity;
        }

        public async Task<User> Get(int userId)
        {
            var result = await this.Context.User.FirstOrDefaultAsync(user => user.Id == userId);
            return result;
        }

        public async Task SaveChanges()
        {
            await this.Context.SaveChangesAsync();
        }
    }
}
